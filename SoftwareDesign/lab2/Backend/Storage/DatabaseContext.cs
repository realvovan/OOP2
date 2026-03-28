using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftwareDesign.lab2.Models;

namespace SoftwareDesign.lab2.Storage;

public class DatabaseContext(DbContextOptions options) : DbContext(options) {
	public DbSet<Message> Messages { get; set; }
	public DbSet<User> Users { get; set; }
	public DbSet<ChannelMember> ChannelMembers { get; set; }
	public DbSet<MessageChannel> Channels { get; set; }
	public DbSet<DeletedForMeRecord> DeletedForMeRecords { get; set; }
	public DbSet<AuditLogEntry> AuditLogEntries { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		// User
		modelBuilder.Entity<User>()
			.HasIndex(u => u.Username)
			.IsUnique();
		modelBuilder.Entity<User>()
			.HasKey(u => u.Id);
		// ChannelMemer
		modelBuilder.Entity<ChannelMember>()
			.HasKey(cm => new { cm.UserId,cm.ChannelId });
		modelBuilder.Entity<ChannelMember>()
			.HasOne<User>()
			.WithMany()
			.HasForeignKey(cm => cm.UserId);
		modelBuilder.Entity<ChannelMember>()
			.HasOne<MessageChannel>()
			.WithMany()
			.HasForeignKey(cm => cm.ChannelId);
		// Message
		modelBuilder.Entity<Message>()
			.HasOne<User>()
			.WithMany()
			.HasForeignKey(m => m.SenderId);
		modelBuilder.Entity<Message>()
			.HasOne<MessageChannel>()
			.WithMany()
			.HasForeignKey(m => m.ChannelId);
		modelBuilder.Entity<Message>()
			.HasKey(m => m.Id);
		modelBuilder.Entity<Message>()
			.Ignore(m => m.Sender);
		// MeessageChannel
		modelBuilder.Entity<MessageChannel>()
			.HasKey(c => c.Id);
		modelBuilder.Entity<MessageChannel>()
			.Ignore(c => c.Members);
		// DeletedForMeRecord
		modelBuilder.Entity<DeletedForMeRecord>()
			.HasKey(r => new { r.UserId,r.MessageId });
		// AuditLogEntry
		modelBuilder.Entity<AuditLogEntry>()
			.HasKey(e => e.Id);

		var guidConverter = new ValueConverter<Guid,byte[]>(
			v => v.ToByteArray(),
			v => new Guid(v)
		);
		foreach (var entity in modelBuilder.Model.GetEntityTypes()) {
			foreach (var property in entity.GetProperties()) {
				if (property.ClrType == typeof(Guid)) {
					property.SetValueConverter(guidConverter);
					property.SetAnnotation("Relational:ColumnType","BLOB");
				}
			}
		}

		base.OnModelCreating(modelBuilder);
	}
}