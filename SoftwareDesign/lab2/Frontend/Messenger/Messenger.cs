using Microsoft.AspNetCore.SignalR.Client;
using SoftwareDesign.lab2.Models;

namespace SoftwareDesign.lab2.Main;

public sealed partial class Messenger : IDisposable {
	const string BASE_URL = "http://localhost:5251";
	private readonly HttpClient _client;
	private readonly HubConnection _hubConnection;

	public event Action<Models.Message>? MessageReceived;
	public event Action<Models.Message>? MessageDeleted;
	public event Action<User>? UserStartedTyping;
	public event Action<User>? UserStoppedTyping;

	public void Dispose() => this._client.Dispose();
	public async Task ListenForMessagesAsync() {
		await this._hubConnection.StartAsync();
	}
	public async Task JoinHubChannelAsync(Guid chatId) {
		await this._hubConnection.InvokeAsync("JoinChannel",chatId);
	}
	public async Task LeaveHubChannelAsync(Guid chatId) {
		await this._hubConnection.InvokeAsync("LeaveChannel",chatId);
	}
	internal static ActionResult Ok(string message = "") => ActionResult.Ok(message);
	internal static ActionResult<T> Ok<T>(string message = "",T? data = default) => ActionResult<T>.Ok(data,message);
	internal static ActionResult<T> Fail<T>(string message = "",T? data = default) => ActionResult<T>.Fail(data,message);
	internal static ActionResult<T> Ok<T>(T? data = default) => ActionResult<T>.Ok(data,string.Empty);
	internal static ActionResult<T> Fail<T>(T? data = default) => ActionResult<T>.Fail(data,string.Empty);

	internal static ActionResult Fail(string message = "") => ActionResult.Fail(message);

	public Messenger() {
		this._client = new HttpClient();
		this._hubConnection = new HubConnectionBuilder()
			.WithUrl(BASE_URL + "/chat_hub")
			.Build();
		this._hubConnection.On<Models.Message>("MessageSent",msg => this.MessageReceived?.Invoke(msg));
		this._hubConnection.On<Models.Message>("MessageDeleted",msg => this.MessageDeleted?.Invoke(msg));
		this._hubConnection.On<User,bool>("TypingStateUpdate",(user,state) => {
			if (state) {
				this.UserStartedTyping?.Invoke(user);
			} else {
				this.UserStoppedTyping?.Invoke(user);
			}
		});
	}
}