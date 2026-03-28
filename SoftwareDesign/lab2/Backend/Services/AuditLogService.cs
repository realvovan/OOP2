using Microsoft.EntityFrameworkCore;
using SoftwareDesign.lab2.Models;
using SoftwareDesign.lab2.Storage;

namespace SoftwareDesign.lab2.Services;

public class AuditLogService(DatabaseContext dbContext) {
	public readonly DatabaseContext _db = dbContext;

	public async Task LogMessageCreationAsync(Message message) {
		this._db.AuditLogEntries.Add(new AuditLogEntry(message.SenderId,@$"Message sent: [
	Sender: {message.Sender.Username} ({message.SenderId}),
	Channel: {message.ChannelId},
	Contenxt: {message.Content}
]"));
		await this._db.SaveChangesAsync();
	}
	public async Task LogMessageDeletionAsync(Message message) {
		this._db.AuditLogEntries.Add(new AuditLogEntry(message.SenderId,@$"Message deleted: [
	Sender: {message.Sender.Username} ({message.SenderId}),
	Channel: {message.ChannelId},
	Contenxt: {message.Content}
]"));
		await this._db.SaveChangesAsync();
	}
	public async Task<IEnumerable<AuditLogEntry>> GetAllEntriesAsync(int limit = 100,int offset = 0) {
		return await this._db.AuditLogEntries
			.Skip(offset)
			.Take(limit)
			.ToListAsync();
	}
	public async Task<IEnumerable<AuditLogEntry>> GetEntriesForUserAsync(Guid userId,int limit = 100,int offset = 0) {
		return await this._db.AuditLogEntries
			.Where(e => e.UserWhoTriggeredId == userId)
			.Skip(offset)
			.Take(limit)
			.ToListAsync();
	}
}
