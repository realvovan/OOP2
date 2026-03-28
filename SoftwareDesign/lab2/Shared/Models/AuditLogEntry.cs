using System.Text.Json.Serialization;

namespace SoftwareDesign.lab2.Models;
public class AuditLogEntry {
	public Guid Id { get; init; } = Guid.NewGuid();
	public Guid UserWhoTriggeredId { get; set; }
	public string Message { get; set; } = null!;

	[JsonConstructor]
	public AuditLogEntry() { }
	public AuditLogEntry(Guid userWhoTriggeredId,string message) {
		this.UserWhoTriggeredId = userWhoTriggeredId;
		this.Message = message;
	}
}
