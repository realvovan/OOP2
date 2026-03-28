using SoftwareDesign.lab2.Main;
using SoftwareDesign.lab2.Models;

namespace SoftwareDesign.lab2.Views;
public partial class ChatScreen : UserControl {
	private Guid _channelId;
	private Messenger _client;
	private MainWindow _window;
	private User _user;
	private System.Timers.Timer _typingTimer;
	private HashSet<User> _typingUsers = new();
	private DateTime _finishTypingAt;
	private bool _isTyping = false;
	public ChatScreen(Guid channelId,Messenger client,MainWindow mainWindow,User user) {
		InitializeComponent();
		this._channelId = channelId;
		this._client = client;
		this._window = mainWindow;
		this._user = user;
		this._typingTimer = new() {
			Interval = 2500
		};

		this.InitializeMessages();

		this.DeleteToolStripMenuItem.Click += ContextMenu_Item_Click;
		this.DeleteForMeToolStripMenuItem.Click += ContextMenu_Item_Click;
		this.Disposed += async (s,e) => {
			this._typingTimer.Stop();
			this._typingTimer.Dispose();
			this._client.MessageReceived -= OnMessage;
			this._client.MessageDeleted -= OnMessageDeleted;
			this._client.UserStartedTyping -= OnUserStartedTyping;
			this._client.UserStoppedTyping -= OnUserFinishedTyping;
			await this._client.LeaveHubChannelAsync(this._channelId);
			await this._client.SetUserTypingState(this._channelId,this._user.Id,false);
		};
	}

	private async void InitializeMessages() {
		await this._client.JoinHubChannelAsync(this._channelId);
		this._typingTimer.Start();
		this._typingTimer.Elapsed += async (s,e) => {
			if (this._isTyping && DateTime.UtcNow > this._finishTypingAt) {
				this._isTyping = false;
				await this._client.SetUserTypingState(this._channelId,this._user.Id,false);
			}
		};
		this._client.MessageReceived += OnMessage;
		this._client.MessageDeleted += OnMessageDeleted;
		this._client.UserStartedTyping += OnUserStartedTyping;
		this._client.UserStoppedTyping += OnUserFinishedTyping;
		var messages = await this._client.GetAllChannelMessagesAsync(this._channelId,this._user.Id);
		for (int i = messages.Count - 1; i >= 0; i--) {
			this.CreateMessageLabel(messages[i],true);
		}
	}
	private void CreateMessageLabel(Models.Message message,bool isMessageProcessed) {
		const int textMargin = 5;
		var label = new MessageLabel {
			MessageId = message.Id,
			Name = message.Id.ToString()
		};
		label.ContentsLabel.ForeColor = isMessageProcessed ? SystemColors.ControlText : SystemColors.ControlDarkDark;
		if (message.IsDeleted) {
			label.UsernameLabel.Text = "[DELETED MESSAGE]";
			label.ContentsLabel.Text = string.Empty;
		} else {
			label.UsernameLabel.Text = message.SenderId == this._user.Id ? "You" : message.Sender.DisplayName;
			label.ContentsLabel.Text = message.Content;
		}
		this.MessagesPanel.Controls.Add(label);
		label.Height = label.UsernameLabel.Height + label.ContentsLabel.Height + textMargin;
		label.BringToFront();
		this.MessagesPanel.ScrollControlIntoView(label);

		if (message.IsDeleted) return;
		if (message.SenderId == this._user.Id) {
			label.MouseClick += (sender,e) => {
				var label = (MessageLabel)sender!;
				if (e.Button != MouseButtons.Right) return;
				this.DeleteToolStripMenuItem.Visible = true;
				this.ContextMenu.Tag = label;
				this.ContextMenu.Show(Cursor.Position);
			};
		} else {
			label.MouseClick += (sender,e) => {
				var label = (MessageLabel)sender!;
				if (e.Button != MouseButtons.Right) return;
				this.DeleteToolStripMenuItem.Visible = false;
				this.ContextMenu.Tag = label;
				this.ContextMenu.Show(Cursor.Position);
			};
		}
	}
	private void OnMessage(Models.Message message) {
		bool found = false;
		foreach (Control i in this.MessagesPanel.Controls) {
			if (i is MessageLabel label && label.MessageId == message.Id) {
				found = true;
				label.ContentsLabel.ForeColor = SystemColors.ControlText;
				return;
			}
		}
		if (!found) {
			if (this.InvokeRequired) {
				this.Invoke(() => this.CreateMessageLabel(message,true));
			} else {
				this.CreateMessageLabel(message,true);
			}
		}
	}
	private void OnMessageDeleted(Models.Message message) {
		foreach (Control i in this.MessagesPanel.Controls) {
			if (i is MessageLabel label && label.MessageId == message.Id) {
				label.UsernameLabel.Text = "[DELETED MESSAGE]";
				label.ContentsLabel.Text = string.Empty;
				label.Height = label.UsernameLabel.Height + 5;
				return;
			}
		}
	}
	private void OnUserStartedTyping(User user) {
		if (this._user.Equals(user)) return;
		this._typingUsers.Add(user);
		if (this.InvokeRequired) {
			this.Invoke(this.UpdateTypingIndicator);
		} else {
			this.UpdateTypingIndicator();
		}
	}
	private void OnUserFinishedTyping(User user) {
		if (this._user.Equals(user)) return;
		this._typingUsers.Remove(user);
		if (this.InvokeRequired) {
			this.Invoke(this.UpdateTypingIndicator);
		} else {
			this.UpdateTypingIndicator();
		}
	}
	private void UpdateTypingIndicator() {
		const int maxUsernameDisplay = 3;
		if (this._typingUsers.Count == 0) {
			this.TypingIndicator.Visible = false;
			return;
		}
		this.TypingIndicator.Visible = true;
		if (this._typingUsers.Count == 1) {
			this.TypingIndicator.Text = $"{this._typingUsers.First().DisplayName} is typing...";
		} else if (this._typingUsers.Count > maxUsernameDisplay) {
			var usernames = new string[maxUsernameDisplay];
			for (int i = 0; i < maxUsernameDisplay; i++) {
				usernames[i] = this._typingUsers.ElementAt(i).DisplayName;
			}
			this.TypingIndicator.Text =
				$"{string.Join(", ",usernames)} and {this._typingUsers.Count - maxUsernameDisplay} others are typing...";
		} else {
			this.TypingIndicator.Text = $"{string.Join(", ",this._typingUsers.Select(u => u.DisplayName))} are typing...";
		}
	}
	private async void SendBtn_Click(object sender,EventArgs e) {
		string text = this.MessageBox.Text;
		this.MessageBox.Text = string.Empty;
		var message = await this._client.SendMessageAsync(this._channelId,this._user.Id,text);
		if (message is not null) this.CreateMessageLabel(message,false);
		this._isTyping = false;
		await this._client.SetUserTypingState(this._channelId,this._user.Id,false);
	}

	private void BackBtn_Click(object sender,EventArgs e) {
		this.Parent?.Controls.Remove(this);
		this.Dispose();
		var screen = new ChatSelectionScreen(this._user,this._window,this._client);
		this._window.Controls.Add(screen);
		screen.BringToFront();
	}
	private async void ContextMenu_Item_Click(object? sender,EventArgs e) {
		var item = (ToolStripItem)sender!;
		var label = (MessageLabel)this.ContextMenu.Tag!;
		ActionResult result;
		switch (item.Tag) {
			case "Delete":
				await this._client.DeleteMessageAsync(label.MessageId);
				break;
			case "DeleteForMe":
				result = await this._client.DeleteForMeAsync(label.MessageId,this._user.Id);
				if (!result.Success) break;
				label.Parent?.Controls.Remove(label);
				label.Dispose();
				break;
		}
	}
	private async void MessageBox_KeyPress(object sender,KeyPressEventArgs e) {
		this._finishTypingAt = DateTime.UtcNow.AddSeconds(5);
		if (this._isTyping) return;
		this._isTyping = true;
		await this._client.SetUserTypingState(this._channelId,this._user.Id,true);
	}
}
