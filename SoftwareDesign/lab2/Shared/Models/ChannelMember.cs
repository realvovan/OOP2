using System.Text.Json.Serialization;

namespace SoftwareDesign.lab2.Models;

public class ChannelMember {
	public Guid UserId { get; set; }
	public Guid ChannelId { get; set; }

	[JsonConstructor]
	public ChannelMember() { }
	public ChannelMember(Guid userId,Guid channelId) {
		this.UserId = userId;
		this.ChannelId = channelId;
	}
}