using Microsoft.AspNetCore.SignalR;

namespace SoftwareDesign.lab2.Models;

public class ChatHub : Hub {
	public async Task JoinChannel(Guid chatId) {
		await this.Groups.AddToGroupAsync(this.Context.ConnectionId,chatId.ToString());
	}
	public async Task LeaveChannel(Guid chatId) {
		await this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId,chatId.ToString());
	}
}