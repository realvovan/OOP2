namespace Coursework.PresentationLevel {
	partial class ClientCreateWindow {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.Title = new Label();
			this.PictureBox = new PictureBox();
			this.FirstBox = new TextBox();
			this.LastBox = new TextBox();
			this.EmailBox = new TextBox();
			this.PhoneBox = new TextBox();
			this.PassportBox = new TextBox();
			this.IbanBox = new TextBox();
			this.PriceBox = new TextBox();
			this.RoomCountBox = new TextBox();
			this.CancelBut = new Button();
			this.AddButton = new Button();
			this.SuggestionsList = new FlowLayoutPanel();
			this.AddSuggestionButton = new Button();
			this.RemoveSuggestionButton = new Button();
			this.OpenFileDialog = new OpenFileDialog();
			this.SuggestionsLabel = new Label();
			((System.ComponentModel.ISupportInitialize)this.PictureBox).BeginInit();
			this.SuspendLayout();
			// 
			// Title
			// 
			this.Title.AutoSize = true;
			this.Title.Font = new Font("Segoe UI",20F,FontStyle.Bold);
			this.Title.Location = new Point(12,9);
			this.Title.Name = "Title";
			this.Title.Size = new Size(208,37);
			this.Title.TabIndex = 2;
			this.Title.Text = "Add new client";
			// 
			// PictureBox
			// 
			this.PictureBox.BackColor = SystemColors.ControlDarkDark;
			this.PictureBox.BackgroundImageLayout = ImageLayout.Stretch;
			this.PictureBox.Cursor = Cursors.Hand;
			this.PictureBox.ImageLocation = "";
			this.PictureBox.Location = new Point(12,55);
			this.PictureBox.Name = "PictureBox";
			this.PictureBox.Size = new Size(175,233);
			this.PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			this.PictureBox.TabIndex = 3;
			this.PictureBox.TabStop = false;
			this.PictureBox.Click += this.PictureBox_Click;
			this.PictureBox.MouseEnter += this.PictureBox_MouseEnter;
			// 
			// FirstBox
			// 
			this.FirstBox.Font = new Font("Segoe UI",12F);
			this.FirstBox.Location = new Point(202,55);
			this.FirstBox.Name = "FirstBox";
			this.FirstBox.PlaceholderText = "First name";
			this.FirstBox.Size = new Size(200,29);
			this.FirstBox.TabIndex = 4;
			// 
			// LastBox
			// 
			this.LastBox.Font = new Font("Segoe UI",12F);
			this.LastBox.Location = new Point(202,90);
			this.LastBox.Name = "LastBox";
			this.LastBox.PlaceholderText = "Last name";
			this.LastBox.Size = new Size(200,29);
			this.LastBox.TabIndex = 5;
			// 
			// EmailBox
			// 
			this.EmailBox.Font = new Font("Segoe UI",12F);
			this.EmailBox.Location = new Point(202,125);
			this.EmailBox.Name = "EmailBox";
			this.EmailBox.PlaceholderText = "Email address";
			this.EmailBox.Size = new Size(200,29);
			this.EmailBox.TabIndex = 6;
			// 
			// PhoneBox
			// 
			this.PhoneBox.Font = new Font("Segoe UI",12F);
			this.PhoneBox.Location = new Point(202,160);
			this.PhoneBox.Name = "PhoneBox";
			this.PhoneBox.PlaceholderText = "Phone number";
			this.PhoneBox.Size = new Size(200,29);
			this.PhoneBox.TabIndex = 7;
			// 
			// PassportBox
			// 
			this.PassportBox.Font = new Font("Segoe UI",12F);
			this.PassportBox.Location = new Point(202,195);
			this.PassportBox.Name = "PassportBox";
			this.PassportBox.PlaceholderText = "Passport number";
			this.PassportBox.Size = new Size(200,29);
			this.PassportBox.TabIndex = 8;
			// 
			// IbanBox
			// 
			this.IbanBox.Font = new Font("Segoe UI",12F);
			this.IbanBox.Location = new Point(202,230);
			this.IbanBox.Name = "IbanBox";
			this.IbanBox.PlaceholderText = "IBAN";
			this.IbanBox.Size = new Size(200,29);
			this.IbanBox.TabIndex = 9;
			// 
			// PriceBox
			// 
			this.PriceBox.Font = new Font("Segoe UI",12F);
			this.PriceBox.Location = new Point(16,294);
			this.PriceBox.Name = "PriceBox";
			this.PriceBox.PlaceholderText = "Preferred price";
			this.PriceBox.Size = new Size(188,29);
			this.PriceBox.TabIndex = 10;
			// 
			// RoomCountBox
			// 
			this.RoomCountBox.Font = new Font("Segoe UI",12F);
			this.RoomCountBox.Location = new Point(210,294);
			this.RoomCountBox.Name = "RoomCountBox";
			this.RoomCountBox.PlaceholderText = "Preferred room count";
			this.RoomCountBox.Size = new Size(188,29);
			this.RoomCountBox.TabIndex = 11;
			// 
			// CancelBut
			// 
			this.CancelBut.Font = new Font("Segoe UI",12F);
			this.CancelBut.Location = new Point(306,489);
			this.CancelBut.Name = "CancelBut";
			this.CancelBut.Size = new Size(96,32);
			this.CancelBut.TabIndex = 13;
			this.CancelBut.Text = "Cancel";
			this.CancelBut.UseVisualStyleBackColor = true;
			this.CancelBut.Click += this.CancelBut_Click;
			// 
			// AddButton
			// 
			this.AddButton.Font = new Font("Segoe UI",12F);
			this.AddButton.Location = new Point(204,489);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new Size(96,32);
			this.AddButton.TabIndex = 12;
			this.AddButton.Text = "Add";
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += this.AddButton_Click;
			// 
			// SuggestionsList
			// 
			this.SuggestionsList.AutoScroll = true;
			this.SuggestionsList.BackColor = SystemColors.ControlLight;
			this.SuggestionsList.FlowDirection = FlowDirection.TopDown;
			this.SuggestionsList.Location = new Point(20,360);
			this.SuggestionsList.Name = "SuggestionsList";
			this.SuggestionsList.Size = new Size(235,111);
			this.SuggestionsList.TabIndex = 14;
			this.SuggestionsList.WrapContents = false;
			// 
			// AddSuggestionButton
			// 
			this.AddSuggestionButton.Font = new Font("Segoe UI",11F);
			this.AddSuggestionButton.Location = new Point(275,362);
			this.AddSuggestionButton.Name = "AddSuggestionButton";
			this.AddSuggestionButton.Size = new Size(116,50);
			this.AddSuggestionButton.TabIndex = 15;
			this.AddSuggestionButton.Text = "Add suggestion";
			this.AddSuggestionButton.UseVisualStyleBackColor = true;
			this.AddSuggestionButton.Click += this.AddSuggestionButton_Click;
			// 
			// RemoveSuggestionButton
			// 
			this.RemoveSuggestionButton.Font = new Font("Segoe UI",11F);
			this.RemoveSuggestionButton.Location = new Point(275,417);
			this.RemoveSuggestionButton.Name = "RemoveSuggestionButton";
			this.RemoveSuggestionButton.Size = new Size(116,50);
			this.RemoveSuggestionButton.TabIndex = 16;
			this.RemoveSuggestionButton.Text = "Remove suggestion";
			this.RemoveSuggestionButton.UseVisualStyleBackColor = true;
			this.RemoveSuggestionButton.Click += this.RemoveSuggestionButton_Click;
			// 
			// SuggestionsLabel
			// 
			this.SuggestionsLabel.AutoSize = true;
			this.SuggestionsLabel.Font = new Font("Segoe UI",12F);
			this.SuggestionsLabel.Location = new Point(20,335);
			this.SuggestionsLabel.Name = "SuggestionsLabel";
			this.SuggestionsLabel.Size = new Size(165,21);
			this.SuggestionsLabel.TabIndex = 17;
			this.SuggestionsLabel.Text = "Suggested real estates";
			// 
			// ClientCreateWindow
			// 
			this.AutoScaleDimensions = new SizeF(7F,15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(414,533);
			this.Controls.Add(this.SuggestionsLabel);
			this.Controls.Add(this.RemoveSuggestionButton);
			this.Controls.Add(this.AddSuggestionButton);
			this.Controls.Add(this.SuggestionsList);
			this.Controls.Add(this.CancelBut);
			this.Controls.Add(this.AddButton);
			this.Controls.Add(this.RoomCountBox);
			this.Controls.Add(this.PriceBox);
			this.Controls.Add(this.IbanBox);
			this.Controls.Add(this.PassportBox);
			this.Controls.Add(this.PhoneBox);
			this.Controls.Add(this.EmailBox);
			this.Controls.Add(this.LastBox);
			this.Controls.Add(this.FirstBox);
			this.Controls.Add(this.PictureBox);
			this.Controls.Add(this.Title);
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ClientCreateWindow";
			this.ShowInTaskbar = false;
			this.Text = "Client editor";
			this.MouseEnter += this.ClientCreateWindow_MouseEnter;
			((System.ComponentModel.ISupportInitialize)this.PictureBox).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private Label Title;
		private PictureBox PictureBox;
		private TextBox FirstBox;
		private TextBox LastBox;
		private TextBox EmailBox;
		private TextBox PhoneBox;
		private TextBox PassportBox;
		private TextBox IbanBox;
		private TextBox PriceBox;
		private TextBox RoomCountBox;
		private Button CancelBut;
		private Button AddButton;
		private FlowLayoutPanel SuggestionsList;
		private Button AddSuggestionButton;
		private Button RemoveSuggestionButton;
		private OpenFileDialog OpenFileDialog;
		private Label SuggestionsLabel;
	}
}