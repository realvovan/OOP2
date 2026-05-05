using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SoftwareDesign.lab2.Models;
using SoftwareDesign.lab2.Storage;

namespace SoftwareDesign.lab2.Services;

/// <summary>
/// Service for managing messaging operations including channels, messages, and real-time updates.
/// Handles message creation, retrieval, deletion, and user typing state notifications via SignalR.
/// </summary>
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

	/// <summary>
	/// Creates a new message channel with the specified creator.
	/// </summary>
	/// <param name="creatorId">The ID of the user creating the channel.</param>
	/// <returns>Returns the created MessageChannel object.</returns>
	/// <exception cref="InvalidOperationException">Thrown when the user ID does not exist.</exception>
	public async Task<MessageChannel> CreateChannelAsync(Guid creatorId) {
		var user = await this._db.Users.FirstOrDefaultAsync(u => u.Id == creatorId)
			?? throw new InvalidOperationException($"No user with given id exists [{creatorId}]");
		var channel = new MessageChannel();
		this._db.Channels.Add(channel);
		this._db.ChannelMembers.Add(new ChannelMember(user.Id,channel.Id));
		await this._db.SaveChangesAsync();
		return channel;
	}

	/// <summary>
	/// Adds a user as a member to an existing message channel.
	/// </summary>
	/// <param name="userId">The ID of the user to add to the channel.</param>
	/// <param name="channelId">The ID of the channel to add the user to.</param>
	/// <exception cref="InvalidOperationException">Thrown when the user ID or channel ID does not exist.</exception>
	public async Task AddChannelMemberAsync(Guid userId,Guid channelId) {
		var user = await this._db.Users.FirstOrDefaultAsync(u => u.Id == userId)
			?? throw new InvalidOperationException($"No user with given id exists [{userId}]");
		var channel = await this._db.Channels.FirstOrDefaultAsync(c => c.Id == channelId)
			?? throw new InvalidOperationException($"No channel with given id exists [{channelId}]");
		this._db.ChannelMembers.Add(new ChannelMember(user.Id,channel.Id));
		await this._db.SaveChangesAsync();
	}

	/// <summary>
	/// Retrieves a message channel by its ID.
	/// </summary>
	/// <param name="channelId">The ID of the channel to retrieve.</param>
	/// <returns>Returns the MessageChannel object if found; otherwise returns null.</returns>
	public async Task<MessageChannel?> GetChannelAsync(Guid channelId) {
		return await this._db.Channels.FirstOrDefaultAsync(c => c.Id == channelId);
	}

	/// <summary>
	/// Sends a new message to a specific channel.
	/// The message is enqueued for processing and will be broadcast to channel members via SignalR.
	/// </summary>
	/// <param name="senderId">The ID of the user sending the message.</param>
	/// <param name="channelId">The ID of the channel to send the message to.</param>
	/// <param name="content">The message content text.</param>
	/// <returns>Returns the created Message object.</returns>
	/// <exception cref="InvalidOperationException">Thrown when the message content is empty or whitespace.</exception>
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

	/// <summary>
	/// Retrieves all messages from a specific channel, excluding messages marked as deleted for the requesting user.
	/// </summary>
	/// <param name="channelId">The ID of the channel to retrieve messages from.</param>
	/// <param name="userId">The ID of the user requesting the messages (used to filter deleted-for-me records).</param>
	/// <returns>Returns a collection of Message objects ordered by send time (newest first).</returns>
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

	/// <summary>
	/// Retrieves all message channels that a user is a member of.
	/// </summary>
	/// <param name="userId">The ID of the user to retrieve channels for.</param>
	/// <returns>Returns a collection of MessageChannel objects with their members populated.</returns>
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

	/// <summary>
	/// Checks if a message channel exists in the database.
	/// </summary>
	/// <param name="channelId">The ID of the channel to check.</param>
	/// <returns>Returns true if the channel exists; otherwise returns false.</returns>
	public async Task<bool> ChannelExistsAsync(Guid channelId) {
		return (await this._db.Channels.FirstOrDefaultAsync(c => c.Id == channelId)) is not null;
	}

	/// <summary>
	/// Permanently deletes a message from a channel.
	/// Notifies all channel members of the deletion via SignalR and logs the action.
	/// </summary>
	/// <param name="messageId">The ID of the message to delete.</param>
	/// <exception cref="InvalidOperationException">Thrown when the message ID does not exist.</exception>
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

	/// <summary>
	/// Marks a message as deleted for a specific user only, keeping it visible to others.
	/// </summary>
	/// <param name="messageId">The ID of the message to delete.</param>
	/// <param name="userId">The ID of the user for whom to delete the message.</param>
	/// <exception cref="InvalidOperationException">Thrown when the message ID or user ID does not exist.</exception>
	public async Task DeleteForMeAsync(Guid messageId,Guid userId) {
		var message = await this._db.Messages.FirstOrDefaultAsync(m => m.Id == messageId)
			?? throw new InvalidOperationException($"No message with id {messageId}");
		var user = await this._db.Users.FirstOrDefaultAsync(u => u.Id == userId)
			?? throw new InvalidOperationException($"No user with id {messageId}");
		this._db.DeletedForMeRecords.Add(new DeletedForMeRecord(messageId,userId));
		await this._db.SaveChangesAsync();
	}

	/// <summary>
	/// Updates the typing state of a user in a specific channel and broadcasts it to all channel members via SignalR.
	/// </summary>
	/// <param name="userId">The ID of the user whose typing state is being updated.</param>
	/// <param name="channelId">The ID of the channel where the typing state is being updated.</param>
	/// <param name="state">True if the user is typing, false otherwise.</param>
	/// <exception cref="InvalidOperationException">Thrown when the user ID or channel ID does not exist.</exception>
	public async Task UpdateUserTypingStateAsync(Guid userId,Guid channelId,bool state) {
		var user = await this._userService.GetUserFromGuidAsync(userId) ?? throw new InvalidOperationException($"No user with id {userId}");
		var channel = await this.GetChannelAsync(channelId) ?? throw new InvalidOperationException($"No channel with id {channelId}");
		await this._hub.Clients
			.Group(channel.Id.ToString())
			.SendAsync("TypingStateUpdate",user,state);
	}

	/// <summary>
	/// Internal method that processes queued messages by storing them in the database and broadcasting them to channel members.
	/// Called to flush messages from the queue and persist them with audit logging.
	/// </summary>
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