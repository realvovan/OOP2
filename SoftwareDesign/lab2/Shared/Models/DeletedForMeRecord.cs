using System.Text.Json.Serialization;

namespace SoftwareDesign.lab2.Models;
public class DeletedForMeRecord {
	public Guid MessageId { get; set; }
	public Guid UserId { get; set; }
	[JsonConstructor]
	public DeletedForMeRecord() { }

	public DeletedForMeRecord(Guid messageId,Guid userId) {
		this.MessageId = messageId;
		this.UserId = userId;
	}
}
