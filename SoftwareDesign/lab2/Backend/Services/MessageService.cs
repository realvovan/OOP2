using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SoftwareDesign.lab2.Models;
using SoftwareDesign.lab2.Storage;

namespace SoftwareDesign.lab2.Services;

public class MessageService(
	DatabaseContext dbContext,
	QueueService queueService,
	UserService userService,
	AuditLogService logService,
	IHubContext<ChatHub> hub
	) {
	private readonly DatabaseContext _db = dbContext;
	private readonly QueueService _queueService = queueService;
	private readonly UserService _userService = userService;
	private readonly AuditLogService _logService = logService;
	private readonly IHubContext<ChatHub> _hub = hub;

	public DatabaseContext DatabaseContext => this._db;

	public async Task<MessageChannel> CreateChannelAsync(Guid creatorId) {
		var user = await this._db.Users.FirstOrDefaultAsync(u => u.Id == creatorId)
			?? throw new InvalidOperationException($"No user with given id exists [{creatorId}]");
		var channel = new MessageChannel();
		this._db.Channels.Add(channel);
		this._db.ChannelMembers.Add(new ChannelMember(user.Id,channel.Id));
		await this._db.SaveChangesAsync();
		return channel;
	}
	public async Task AddChannelMemberAsync(Guid userId,Guid channelId) {
		var user = await this._db.Users.FirstOrDefaultAsync(u => u.Id == userId)
			?? throw new InvalidOperationException($"No user with given id exists [{userId}]");
		var channel = await this._db.Channels.FirstOrDefaultAsync(c => c.Id == channelId)
			?? throw new InvalidOperationException($"No channel with given id exists [{channelId}]");
		this._db.ChannelMembers.Add(new ChannelMember(user.Id,channel.Id));
		await this._db.SaveChangesAsync();
	}
	public async Task<MessageChannel?> GetChannelAsync(Guid channelId) {
		return await this._db.Channels.FirstOrDefaultAsync(c => c.Id == channelId);
	}
	public async Task<Message> SendMessageAsync(Guid senderId,Guid channelId,string content) {
		if (string.IsNullOrWhiteSpace(content)) throw new InvalidOperationException("Cannot send an empty message.");
		var message = new Message {
			Content = content.Trim(),
			SenderId = senderId,
			ChannelId = channelId,
			Sender = (await this._userService.GetUserFromGuidAsync(senderId))!
		};
		await this._queueService.EnqueueAsync(message);
		return message;
	}
	public async Task<IEnumerable<Message>> GetMessagesAsync(Guid channelId,Guid userId) {
		return await this._db.Messages
			.Where(m => m.ChannelId == channelId && !this._db.DeletedForMeRecords.Any(r => r.UserId == userId && r.MessageId == m.Id))
			.OrderByDescending(m => m.SendTime)
			//.Skip(offset)
			//.Take(MESSAGE_PAGE_SIZE)
			.Select(m => new Message {
				Id = m.Id,
				SenderId = m.SenderId,
				ChannelId = m.ChannelId,
				IsDeleted = m.IsDeleted,
				SendTime = m.SendTime,
				Content = m.IsDeleted ? string.Empty : m.Content,
				Sender = this._userService.GetUserFromGuidAsync(m.SenderId).GetAwaiter().GetResult() ?? new User("Deleted user")
			})
			.ToListAsync();
	}
	public async Task<IEnumerable<MessageChannel>> GetAllChannelsAsync(Guid userId) {
		var channels = await this._db.Channels
			.Where(c => this._db.ChannelMembers.Any(m => m.ChannelId == c.Id && m.UserId == userId))
			.ToListAsync();
		foreach (var channel in channels) {
			channel.Members = await this._db.Users
				.Where(u => this._db.ChannelMembers.Any(m => m.ChannelId == channel.Id && m.UserId == u.Id))
				.ToListAsync();
		}
		return channels;
	}
	public async Task<bool> ChannelExistsAsync(Guid channelId) {
		return (await this._db.Channels.FirstOrDefaultAsync(c => c.Id == channelId)) is not null;
	}
	public async Task DeleteMessageAsync(Guid messageId) {
		var message = await this._db.Messages.FirstOrDefaultAsync(m => m.Id == messageId)
			?? throw new InvalidOperationException($"No message with id {messageId}");
		message.IsDeleted = true;
		await this._db.SaveChangesAsync();
		await this._hub.Clients
			.Group(message.ChannelId.ToString())
			.SendAsync("MessageDeleted",message);
		await this._logService.LogMessageDeletionAsync(message);
	}
	public async Task DeleteForMeAsync(Guid messageId,Guid userId) {
		var message = await this._db.Messages.FirstOrDefaultAsync(m => m.Id == messageId)
			?? throw new InvalidOperationException($"No message with id {messageId}");
		var user = await this._db.Users.FirstOrDefaultAsync(u => u.Id == userId)
			?? throw new InvalidOperationException($"No user with id {messageId}");
		this._db.DeletedForMeRecords.Add(new DeletedForMeRecord(messageId,userId));
		await this._db.SaveChangesAsync();
	}
	public async Task UpdateUserTypingStateAsync(Guid userId,Guid channelId,bool state) {
		var user = await this._userService.GetUserFromGuidAsync(userId) ?? throw new InvalidOperationException($"No user with id {userId}");
		var channel = await this.GetChannelAsync(channelId) ?? throw new InvalidOperationException($"No channel with id {channelId}");
		await this._hub.Clients
			.Group(channel.Id.ToString())
			.SendAsync("TypingStateUpdate",user,state);
	}
	internal async Task processQueueAsync() {
		await foreach (var message in this._queueService.DequeueAllAsync()) {
			var channel = await this._db.Channels.FirstOrDefaultAsync(c => c.Id == message.ChannelId);
			var sender = await this._db.Users.FirstOrDefaultAsync(u => u.Id == message.SenderId);
			if (channel is null || sender is null) continue;
			this._db.Messages.Add(message);
			await this._db.SaveChangesAsync();
			await this._hub.Clients
				.Group(channel.Id.ToString())
				.SendAsync("MessageSent",message);
			await this._logService.LogMessageCreationAsync(message);
		}
	}
}