using System.Net.Http.Json;

namespace lab3.PL;

public sealed class SimplifiedHttpClient : IDisposable {
	private readonly HttpClient _httpClient = new();

	public void Dispose() => this._httpClient.Dispose();

	public async Task<T?> GetAsync<T>(string requestUrl) {
		try {
			var response = await this._httpClient.GetAsync(requestUrl);
			return await _deserializeResponse<T>(response);
		} catch (Exception e) {
			_showErrorMessage(e.Message);
			return default;
		}
	}
	public async Task<TOut?> PostAsync<TOut,TIn>(string requestUrl,TIn body) {
		try {
			var response = await this._httpClient.PostAsJsonAsync(requestUrl,body);
			return await _deserializeResponse<TOut>(response);
		} catch (Exception e) {
			_showErrorMessage(e.Message);
			return default;
		}
	}
	public async Task<bool> PostAsync<TIn>(string requestUrl,TIn body) {
		try {
			var response = await this._httpClient.PostAsJsonAsync(requestUrl,body);
			if (!response.IsSuccessStatusCode) {
				_showErrorMessage(await response.Content.ReadAsStringAsync());
				return false;
			}
			return true;
		} catch (Exception e) {
			_showErrorMessage(e.Message);
			return false;
		}
	}
	public async Task<bool> PutAsync<TIn>(string requestUrl,TIn body) {
		try {
			var response = await this._httpClient.PutAsJsonAsync(requestUrl,body);
			if (!response.IsSuccessStatusCode) {
				_showErrorMessage(await response.Content.ReadAsStringAsync());
				return false;
			}
			return true;
		} catch (Exception e) {
			_showErrorMessage(e.Message);
			return false;
		}
	}
	public async Task<bool> DeleteAsync(string requestUrl) {
		try {
			var response = await this._httpClient.DeleteAsync(requestUrl);
			if (!response.IsSuccessStatusCode) {
				_showErrorMessage(await response.Content.ReadAsStringAsync());
				return false;
			}
			return true;
		} catch (Exception e) {
			_showErrorMessage(e.Message);
			return false;
		}
	}
	public async Task<bool> PatchAsync(string requestUrl) {
		try {
			var response = await this._httpClient.PatchAsync(requestUrl,null);
			if (!response.IsSuccessStatusCode) {
				_showErrorMessage(await response.Content.ReadAsStringAsync());
				return false;
			}
			return true;
		} catch (Exception e) {
			_showErrorMessage(e.Message);
			return false;
		}
	}

	private async static Task<T?> _deserializeResponse<T>(HttpResponseMessage response) {
		if (!response.IsSuccessStatusCode) {
			_showErrorMessage(await  response.Content.ReadAsStringAsync());
			return default;
		}
		var content = await response.Content.ReadFromJsonAsync<T>();
		if (content is null) {
			_showErrorMessage("Couldn't deserialize the response!");
			return default;
		}
		return content;
	}
	private static void _showErrorMessage(string message) {
		MessageBox.Show(
			caption: "Oops!",
			text: message,
			icon: MessageBoxIcon.Error,
			buttons: MessageBoxButtons.OK
		);
	}
}