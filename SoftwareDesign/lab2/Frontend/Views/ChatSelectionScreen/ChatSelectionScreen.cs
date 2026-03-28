using SoftwareDesign.lab2.Main;
using SoftwareDesign.lab2.Models;

namespace SoftwareDesign.lab2.Views;

public partial class ChatSelectionScreen : UserControl {
	private User _user;
	private MainWindow _window;
	private Messenger _client;
	private UserEditScreen? _userEditScreen;
	private ChatCreationScreen? _chatCreationScreen;
	public ChatSelectionScreen(User user,MainWindow window,Messenger client) {
		InitializeComponent();
		this._user = user;
		this._window = window;
		this._client = client;
		this.UsernameLabel.Text = GetDisplayNameLabel(user.Username,user.DisplayName);
		this.LoadChatList();
	}
	
	private async void LoadChatList() {
		var channels = await this._client.GetAllDmsAsync(this._user.Id);
		foreach (var channel in channels) {
			this.CreateChannelLabel(channel);
		}
	}
	private void CreateChannelLabel(MessageChannel channel) {
		var label = new MessageLabel {
			MessageId = channel.Id,
		};
		label.ContentsLabel.Text = "Click to open!";
		label.BackColor = SystemColors.ControlLight;
		if (channel.Members.Count == 0) {
			label.UsernameLabel.Text = "No one here!";
		}
		else if (channel.Members.Count == 1) {
			label.UsernameLabel.Text = channel.Members[0].DisplayName;
		}
		else {
			label.UsernameLabel.Text = string.Join(", ",channel.Members.Where(u => u.Id != this._user.Id).Select(u => u.DisplayName));
		}
		this.ChatList.Controls.Add(label);
		label.BringToFront();

		label.Click += (sender,e) => {
			var label = (MessageLabel)sender!;
			this.Parent?.Controls.Remove(this);
			this.Dispose();
			var chatScreen = new ChatScreen(label.MessageId,this._client,this._window,this._user);
			this._window.Controls.Add(chatScreen);
			chatScreen.BringToFront();
		};
	}

	private void EditUserBtn_Click(object sender,EventArgs e) {
		if (this._userEditScreen is not null) {
			this._userEditScreen.Parent?.Controls.Remove(this._userEditScreen);
			this._userEditScreen.Dispose();
			this._userEditScreen = null!;
			return;
		}
		this._userEditScreen = new UserEditScreen();
		this._userEditScreen.UsernameBox.Text = this._user.Username;
		this._userEditScreen.DisplayNameBox.Text = this._user.DisplayName != this._user.Username ? this._user.DisplayName : "";
		this._userEditScreen.Location = new Point(
			this.ClientSize.Width / 2 - this._userEditScreen.Width / 2,
			70
		);
		this.Controls.Add(this._userEditScreen);
		this._userEditScreen.BringToFront();

		this._userEditScreen.CancelBtn.Click += (s,e) => {
			this._userEditScreen.Parent?.Controls.Remove(this._userEditScreen);
			this._userEditScreen.Dispose();
			this._userEditScreen = null!;
		};
		this._userEditScreen.SaveBtn.Click += async (s,e) => {
			var newUser = new User(this._userEditScreen.UsernameBox.Text,this._userEditScreen.DisplayNameBox.Text.Trim()) {
				Id = this._user.Id,
			};
			var result = await this._client.EditUserAsync(newUser);
			if (result.Success) {
				this._userEditScreen.Parent?.Controls.Remove(this._userEditScreen);
				this._userEditScreen.Dispose();
				this._userEditScreen = null!;
				this._user.Username = newUser.Username;
				this._user.DisplayName = newUser.DisplayName;
				this.UsernameLabel.Text = GetDisplayNameLabel(newUser.Username,newUser.DisplayName);
			}
			else {
				MessageBox.Show(
					text: result.Message,
					caption: "Oops!",
					icon: MessageBoxIcon.Warning,
					buttons: MessageBoxButtons.OK
				);
			}
		};
	}
	private void NewChatBtn_Click(object sender,EventArgs e) {
		if (this._chatCreationScreen is not null) {
			this._chatCreationScreen.Parent?.Controls.Remove(this._chatCreationScreen);
			this._chatCreationScreen.Dispose();
			this._chatCreationScreen = null!;
			return;
		}
		this._chatCreationScreen = new ChatCreationScreen();
		this._chatCreationScreen.Location = new Point(
			this.ClientSize.Width / 2 - this._chatCreationScreen.Width / 2,
			70
		);
		this.Controls.Add(this._chatCreationScreen);
		this._chatCreationScreen.BringToFront();

		this._chatCreationScreen.CancelBtn.Click += (s,e) => {
			this._chatCreationScreen.Parent?.Controls.Remove(this._chatCreationScreen);
			this._chatCreationScreen.Dispose();
			this._chatCreationScreen = null!;
		};
		this._chatCreationScreen.CreateBtn.Click += async (s,e) => {
			MessageChannel? channel = await this._client.CreateDmAsync(this._user.Id,this._chatCreationScreen.UsernameBox.Text);
			this._chatCreationScreen.Parent?.Controls.Remove(this._chatCreationScreen);
			this._chatCreationScreen.Dispose();
			if (channel is not null) {
				bool found = false;
				foreach (Control i in this.ChatList.Controls) {
					if (i is MessageLabel label && label.MessageId == channel.Id) {
						found = true;
						break;
					}
				}
				if (!found) this.CreateChannelLabel(channel);
			}
		};
	}

	private static string GetDisplayNameLabel(string username,string displayName) {
		return string.IsNullOrWhiteSpace(displayName) || displayName == username
			? $"@{username}" : $"{displayName} (@{username})";
	}
}
