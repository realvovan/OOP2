namespace SoftwareDesign.lab2.Models;

public class Message {
	public Guid Id { get; init; } = Guid.NewGuid();
	public Guid SenderId { get; set; }
	public Guid ChannelId { get; set; }
	public DateTime SendTime { get; set; } = DateTime.UtcNow;
	public string Content { get; set; } = string.Empty;
	public bool IsDeleted { get; set; } = false;

	public User Sender { get; set; } = new User("");
}