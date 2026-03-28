using SoftwareDesign.lab2.Models;
using System.Net.Http.Json;

namespace SoftwareDesign.lab2.Main;

partial class Messenger {
	const string MESSAGES_CONTROLLER_ENDPOINT = "/api/messages";

	public async Task<MessageChannel?> CreateDmAsync(Guid creatorId,string other) {
		var result = await this._client.PostAsync(
			BASE_URL + MESSAGES_CONTROLLER_ENDPOINT + $"/create_dm?creatorId={creatorId}&other={other}",
			null
		);
		if (result.StatusCode == System.Net.HttpStatusCode.OK) {
			return await result.Content.ReadFromJsonAsync<MessageChannel>();
		}
		MessageBox.Show(
			text: await result.Content.ReadAsStringAsync(),
			caption: "Couldn't sign you up!",
			icon: MessageBoxIcon.Error,
			buttons: MessageBoxButtons.OK
		);
		return null;
	}
	public async Task<IEnumerable<MessageChannel>> GetAllDmsAsync(Guid userId) {
		var result = await this._client.GetAsync(BASE_URL + MESSAGES_CONTROLLER_ENDPOINT + $"/dms/{userId}");
		if (result.StatusCode == System.Net.HttpStatusCode.OK) {
			return await result.Content.ReadFromJsonAsync<IEnumerable<MessageChannel>>() ?? throw new Exception("Couldn't deserialize message channels");
		}
		MessageBox.Show(
			text: await result.Content.ReadAsStringAsync(),
			caption: "Oops!",
			icon: MessageBoxIcon.Error,
			buttons: MessageBoxButtons.OK
		);
		return [];
	}
	public async Task<List<Models.Message>> GetAllChannelMessagesAsync(Guid channelId,Guid userId) {
		var result = await this._client.GetAsync(BASE_URL + MESSAGES_CONTROLLER_ENDPOINT + $"/?channelId={channelId}&userId={userId}");
		if (result.StatusCode == System.Net.HttpStatusCode.OK) {
			return await result.Content.ReadFromJsonAsync<List<Models.Message>>() ?? throw new Exception("Couldn't deserialize messages");
		}
		MessageBox.Show(
			text: await result.Content.ReadAsStringAsync(),
			caption: "Oops!",
			icon: MessageBoxIcon.Error,
			buttons: MessageBoxButtons.OK
		);
		return [];
	}
	public async Task<Models.Message?> SendMessageAsync(Guid channelId,Guid senderId,string content) {
		if (string.IsNullOrWhiteSpace(content)) return null;
		var result = await this._client.PostAsJsonAsync(BASE_URL + MESSAGES_CONTROLLER_ENDPOINT,new Models.Message {
			Content = content,
			SenderId = senderId,
			ChannelId = channelId,
		});
		if (result.StatusCode == System.Net.HttpStatusCode.OK) {
			return await result.Content.ReadFromJsonAsync<Models.Message>();
		}
		MessageBox.Show(
			text: await result.Content.ReadAsStringAsync(),
			caption: "Oops!",
			icon: MessageBoxIcon.Error,
			buttons: MessageBoxButtons.OK
		);
		return null;
	}
	public async Task<ActionResult> DeleteMessageAsync(Guid messageId) {
		var result = await this._client.PutAsync(BASE_URL + MESSAGES_CONTROLLER_ENDPOINT + $"/delete_message?messageId={messageId}",null);
		if (result.StatusCode == System.Net.HttpStatusCode.OK) {
			return Ok();
		}
		string content = await result.Content.ReadAsStringAsync();
		MessageBox.Show(
			text: content,
			caption: "Oops!",
			icon: MessageBoxIcon.Error,
			buttons: MessageBoxButtons.OK
		);
		return Fail(content);
	}
	public async Task<ActionResult> DeleteForMeAsync(Guid messageId,Guid userId) {
		var result = await this._client.PostAsync(
			BASE_URL + MESSAGES_CONTROLLER_ENDPOINT + $"/delete_for_me?messageId={messageId}&userId={userId}",
			null
		);
		if (result.StatusCode == System.Net.HttpStatusCode.OK) {
			return Ok();
		}
		string content = await result.Content.ReadAsStringAsync();
		MessageBox.Show(
			text: content,
			caption: "Oops!",
			icon: MessageBoxIcon.Error,
			buttons: MessageBoxButtons.OK
		);
		return Fail(content);
	}
	public async Task SetUserTypingState(Guid channelId,Guid userId,bool state) {
		await this._client.PostAsync(
			BASE_URL + MESSAGES_CONTROLLER_ENDPOINT + $"/set_user_typing_state?userId={userId}&channelId={channelId}&state={state}",
			null
		);
	}
}