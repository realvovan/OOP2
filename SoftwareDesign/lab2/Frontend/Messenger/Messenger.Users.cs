using System.Net;
using System.Net.Http.Json;
using SoftwareDesign.lab2.Models;

namespace SoftwareDesign.lab2.Main;

partial class Messenger {
	const string USER_CONTROLLER_ENDPOINT = "/api/users";
	public async Task<ActionResult<User>> SignupAsync(string username) {
		var result = await this._client.PostAsJsonAsync(BASE_URL + USER_CONTROLLER_ENDPOINT + "/register",username);
		if (result.StatusCode == HttpStatusCode.OK) {
			return Ok(await result.Content.ReadFromJsonAsync<User>());
		} else if (result.StatusCode == HttpStatusCode.Conflict || result.StatusCode == HttpStatusCode.BadRequest) {
			return Fail<User>(await result.Content.ReadAsStringAsync());
		} else {
			var content = await result.Content.ReadAsStringAsync();
			MessageBox.Show(
				text: content,
				caption: "Couldn't sign you up!",
				icon: MessageBoxIcon.Error,
				buttons: MessageBoxButtons.OK
			);
			return Fail<User>(null);
		}
	}
	public async Task<ActionResult<User>> LoginAsync(string username) {
		if (string.IsNullOrWhiteSpace(username)) return Fail<User>("Invalid username");
		var result = await this._client.GetAsync(BASE_URL + USER_CONTROLLER_ENDPOINT + $"/{username}");
		if (result.StatusCode == HttpStatusCode.OK) {
			return Ok(await result.Content.ReadFromJsonAsync<User>());
		} else if (result.StatusCode == HttpStatusCode.NotFound) {
			return Fail<User>("User not found");
		} else {
			var content = await result.Content.ReadAsStringAsync();
			MessageBox.Show(
				text: content,
				caption: "Couldn't log you in!",
				icon: MessageBoxIcon.Error,
				buttons: MessageBoxButtons.OK
			);
			return Fail<User>("Error!");
		}
	}
	public async Task<ActionResult> EditUserAsync(User newUser) {
		var result = await this._client.PutAsJsonAsync(BASE_URL + USER_CONTROLLER_ENDPOINT + "/update_info",newUser);
		if (result.StatusCode == HttpStatusCode.OK) {
			return Ok();
		} else if (result.StatusCode == HttpStatusCode.Conflict || result.StatusCode == HttpStatusCode.BadRequest) {
			return Fail(await result.Content.ReadAsStringAsync());
		} else {
			var content = await result.Content.ReadAsStringAsync();
			MessageBox.Show(
				text: content,
				caption: "Couldn't edit your user!",
				icon: MessageBoxIcon.Error,
				buttons: MessageBoxButtons.OK
			);
			return Fail("Error!");
		}
	}
}