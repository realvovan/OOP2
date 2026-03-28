namespace SoftwareDesign.lab2.Views {
	partial class ChatSelectionScreen {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.panel1 = new Panel();
			this.EditUserBtn = new Button();
			this.UsernameLabel = new Label();
			this.panel2 = new Panel();
			this.NewChatBtn = new Button();
			this.ChatList = new FlowLayoutPanel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = SystemColors.ControlDarkDark;
			this.panel1.Controls.Add(this.EditUserBtn);
			this.panel1.Controls.Add(this.UsernameLabel);
			this.panel1.Location = new Point(0,0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(784,50);
			this.panel1.TabIndex = 0;
			// 
			// EditUserBtn
			// 
			this.EditUserBtn.AutoSize = true;
			this.EditUserBtn.Font = new Font("Segoe UI",12F);
			this.EditUserBtn.Location = new Point(700,10);
			this.EditUserBtn.Name = "EditUserBtn";
			this.EditUserBtn.Size = new Size(75,31);
			this.EditUserBtn.TabIndex = 1;
			this.EditUserBtn.Text = "Edit";
			this.EditUserBtn.UseVisualStyleBackColor = true;
			this.EditUserBtn.Click += this.EditUserBtn_Click;
			// 
			// UsernameLabel
			// 
			this.UsernameLabel.AutoSize = true;
			this.UsernameLabel.Font = new Font("Segoe UI",20F);
			this.UsernameLabel.ForeColor = SystemColors.HighlightText;
			this.UsernameLabel.Location = new Point(15,6);
			this.UsernameLabel.Name = "UsernameLabel";
			this.UsernameLabel.Size = new Size(136,37);
			this.UsernameLabel.TabIndex = 0;
			this.UsernameLabel.Text = "Username";
			// 
			// panel2
			// 
			this.panel2.BackColor = SystemColors.ControlDark;
			this.panel2.Controls.Add(this.NewChatBtn);
			this.panel2.Location = new Point(0,411);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(784,50);
			this.panel2.TabIndex = 3;
			// 
			// NewChatBtn
			// 
			this.NewChatBtn.AutoSize = true;
			this.NewChatBtn.Font = new Font("Segoe UI",12F);
			this.NewChatBtn.Location = new Point(682,9);
			this.NewChatBtn.Name = "NewChatBtn";
			this.NewChatBtn.Size = new Size(85,31);
			this.NewChatBtn.TabIndex = 3;
			this.NewChatBtn.Text = "New chat";
			this.NewChatBtn.UseVisualStyleBackColor = true;
			this.NewChatBtn.Click += this.NewChatBtn_Click;
			// 
			// ChatList
			// 
			this.ChatList.AutoScroll = true;
			this.ChatList.FlowDirection = FlowDirection.TopDown;
			this.ChatList.Location = new Point(3,56);
			this.ChatList.Name = "ChatList";
			this.ChatList.Size = new Size(778,349);
			this.ChatList.TabIndex = 4;
			this.ChatList.WrapContents = false;
			// 
			// ChatSelectionScreen
			// 
			this.AutoScaleDimensions = new SizeF(7F,15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.Controls.Add(this.ChatList);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "ChatSelectionScreen";
			this.Size = new Size(784,461);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
		}

		#endregion

		internal Panel panel1;
		internal Button EditUserBtn;
		internal Label UsernameLabel;
		internal Panel panel2;
		internal Button NewChatBtn;
		private FlowLayoutPanel ChatList;
	}
}
