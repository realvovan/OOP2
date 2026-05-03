using Microsoft.AspNetCore.Mvc.Testing;
using SoftwareDesign.lab2.Models;
using System.Net.Http.Json;
using System.Text;

namespace SoftwareDesign.lab2.Tests;

public class IntegrationTest : IClassFixture<TestWebApplicationFactory> {
	private readonly HttpClient _client;

	public IntegrationTest(TestWebApplicationFactory factory) {
		this._client = factory.CreateClient();
	}

	[Fact]
	public async Task SendMessage_RetrieveHistory_MessageExists() {
		// create user A
		var userAResponse = await _client.PostAsync(
			"/api/users/register",
			new StringContent("\"userA\"",Encoding.UTF8,"application/json")
		);
		userAResponse.EnsureSuccessStatusCode();
		var userA = await userAResponse.Content.ReadFromJsonAsync<User>();
		Assert.NotNull(userA);
		// create user B
		var userBResponse = await _client.PostAsync(
			"/api/users/register",
			new StringContent("\"userB\"",Encoding.UTF8,"application/json")
		);
		userBResponse.EnsureSuccessStatusCode();
		var userB = await userBResponse.Content.ReadFromJsonAsync<User>();
		Assert.NotNull(userB);
		// create channel
		var channelResponse = await _client.PostAsync($"/api/messages/create_dm?creatorId={userA.Id}&other={userB.Username}",null);
		Console.WriteLine($"STATUS: {channelResponse.StatusCode}");
		Console.WriteLine($"BODY: {await channelResponse.Content.ReadAsStringAsync()}");
		Console.WriteLine(new string('=',20));
		channelResponse.EnsureSuccessStatusCode();
		var channel = await channelResponse.Content.ReadFromJsonAsync<MessageChannel>();
		Assert.NotNull(channel);
		// send message
		var messageToSend = new Message {
			Content = "Test Message",
			SenderId = userA.Id,
			ChannelId = channel.Id,
		};
		var sendReponse = await _client.PostAsJsonAsync("/api/messages",messageToSend);
		sendReponse.EnsureSuccessStatusCode();
		// retrieve messages
		var messages = await _client.GetFromJsonAsync<IEnumerable<Message>>(
			$"/api/messages?channelId={channel.Id}&userId={userA.Id}"
		);
		Assert.NotNull(messages);
		Assert.Contains(messages,m =>
			m.Content == messageToSend.Content
			&& m.SenderId == messageToSend.SenderId
			&& m.ChannelId == messageToSend.ChannelId
		);
	}
}
