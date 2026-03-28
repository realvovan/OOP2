namespace SoftwareDesign.lab2.Models;

public class MessageChannel {
	public Guid Id { get; init; } = Guid.NewGuid();
	public List<User> Members { get; set; } = new();
}