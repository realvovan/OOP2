using System.Text.Json.Serialization;

namespace SoftwareDesign.lab2.Models;
#nullable disable
public class User {
	public Guid Id { get; init; } = Guid.NewGuid();
	public string Username { get; set; }
	public string DisplayName { get; set; }

	public override int GetHashCode() {
		return this.Id.GetHashCode();
	}
	public override bool Equals(object obj) {
		return obj is User user && this.Id == user.Id;
	}

	[JsonConstructor]
	public User() { }
	public User(string username) {
		this.Username = username;
		this.DisplayName = username;
	}
	public User(string username,string display) {
		this.Username = username;
		this.DisplayName = display;
	}
}