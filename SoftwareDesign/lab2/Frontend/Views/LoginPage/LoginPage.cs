using System.Threading.Tasks;
using SoftwareDesign.lab2.Main;

namespace SoftwareDesign.lab2.Views;

public partial class LoginPage : Form {
	private readonly Messenger _client;
	public LoginPage(Messenger messengerClient) {
		InitializeComponent();
		this._client = messengerClient;
	}

	private async void SignupButton_Click(object sender,EventArgs e) {
		var result = await this._client.SignupAsync(this.UsernameBox.Text);
		if (result.Success) {
			this.Hide();
			new MainWindow(result.Data!,this._client,this).Show();
		} else {
			this.UsernameBox.ForeColor = Color.Red;
			this.UsernameBox.Text = $"{this.UsernameBox.Text} | {result.Message}";
		}
	}

	private void UsernameBox_Enter(object sender,EventArgs e) {
		this.UsernameBox.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
		this.UsernameBox.Text = string.Empty;
	}

	private async void LoginButton_Click(object sender,EventArgs e) {
		var result = await this._client.LoginAsync(this.UsernameBox.Text);
		if (result.Success) {
			this.Hide();
			new MainWindow(result.Data!,this._client,this).Show();
		} else {
			this.UsernameBox.ForeColor = Color.Red;
			this.UsernameBox.Text = $"{this.UsernameBox.Text} | {result.Message}";
		}
	}
}
