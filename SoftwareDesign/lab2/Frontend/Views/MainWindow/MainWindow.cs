using SoftwareDesign.lab2.Models;
using SoftwareDesign.lab2.Main;

namespace SoftwareDesign.lab2.Views;

public partial class MainWindow : Form {
	private readonly LoginPage _loginPage;
	public MainWindow(User user,Messenger client,LoginPage loginContext) {
		InitializeComponent();
		this._loginPage = loginContext;
		this.Controls.Add(new ChatSelectionScreen(user,this,client));
		this.StartHubConnection(client);

		Console.WriteLine($"Current user guid: {user.Id}");
	}
	private async void StartHubConnection(Messenger client) {
		await client.ListenForMessagesAsync();
	}
	private void MainWindow_FormClosing(object sender,FormClosingEventArgs e) {
		this._loginPage.Dispose();
	}
}
