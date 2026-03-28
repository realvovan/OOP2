namespace SoftwareDesign.lab2.Views {
	partial class ChatScreen {
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
			this.components = new System.ComponentModel.Container();
			this.panel1 = new Panel();
			this.BackBtn = new Label();
			this.panel2 = new Panel();
			this.MessageBox = new TextBox();
			this.SendBtn = new Button();
			this.MessagesPanel = new FlowLayoutPanel();
			this.ContextMenu = new ContextMenuStrip(this.components);
			this.DeleteToolStripMenuItem = new ToolStripMenuItem();
			this.DeleteForMeToolStripMenuItem = new ToolStripMenuItem();
			this.TypingIndicator = new Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.ContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = SystemColors.ControlDarkDark;
			this.panel1.Controls.Add(this.BackBtn);
			this.panel1.Location = new Point(0,0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(784,50);
			this.panel1.TabIndex = 1;
			// 
			// BackBtn
			// 
			this.BackBtn.AutoSize = true;
			this.BackBtn.Font = new Font("Segoe UI",20F);
			this.BackBtn.ForeColor = SystemColors.HighlightText;
			this.BackBtn.Location = new Point(15,6);
			this.BackBtn.Name = "BackBtn";
			this.BackBtn.Size = new Size(96,37);
			this.BackBtn.TabIndex = 0;
			this.BackBtn.Text = "< Back";
			this.BackBtn.Click += this.BackBtn_Click;
			// 
			// panel2
			// 
			this.panel2.BackColor = SystemColors.ControlDark;
			this.panel2.Controls.Add(this.MessageBox);
			this.panel2.Controls.Add(this.SendBtn);
			this.panel2.Location = new Point(0,411);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(784,50);
			this.panel2.TabIndex = 4;
			// 
			// MessageBox
			// 
			this.MessageBox.Font = new Font("Segoe UI",12F);
			this.MessageBox.Location = new Point(15,11);
			this.MessageBox.Name = "MessageBox";
			this.MessageBox.PlaceholderText = "Message...";
			this.MessageBox.Size = new Size(664,29);
			this.MessageBox.TabIndex = 4;
			this.MessageBox.KeyPress += this.MessageBox_KeyPress;
			// 
			// SendBtn
			// 
			this.SendBtn.AutoSize = true;
			this.SendBtn.Font = new Font("Segoe UI",12F);
			this.SendBtn.Location = new Point(699,9);
			this.SendBtn.Name = "SendBtn";
			this.SendBtn.Size = new Size(68,31);
			this.SendBtn.TabIndex = 3;
			this.SendBtn.Text = "Send";
			this.SendBtn.UseVisualStyleBackColor = true;
			this.SendBtn.Click += this.SendBtn_Click;
			// 
			// MessagesPanel
			// 
			this.MessagesPanel.AutoScroll = true;
			this.MessagesPanel.FlowDirection = FlowDirection.BottomUp;
			this.MessagesPanel.Location = new Point(3,56);
			this.MessagesPanel.Name = "MessagesPanel";
			this.MessagesPanel.Size = new Size(778,327);
			this.MessagesPanel.TabIndex = 5;
			this.MessagesPanel.WrapContents = false;
			// 
			// ContextMenu
			// 
			this.ContextMenu.Items.AddRange(new ToolStripItem[] { this.DeleteToolStripMenuItem,this.DeleteForMeToolStripMenuItem });
			this.ContextMenu.Name = "ContextMenuStrip";
			this.ContextMenu.ShowImageMargin = false;
			this.ContextMenu.Size = new Size(121,48);
			// 
			// DeleteToolStripMenuItem
			// 
			this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
			this.DeleteToolStripMenuItem.Size = new Size(120,22);
			this.DeleteToolStripMenuItem.Tag = "Delete";
			this.DeleteToolStripMenuItem.Text = "Delete";
			// 
			// DeleteForMeToolStripMenuItem
			// 
			this.DeleteForMeToolStripMenuItem.Name = "DeleteForMeToolStripMenuItem";
			this.DeleteForMeToolStripMenuItem.Size = new Size(120,22);
			this.DeleteForMeToolStripMenuItem.Tag = "DeleteForMe";
			this.DeleteForMeToolStripMenuItem.Text = "Delete for me";
			// 
			// TypingIndicator
			// 
			this.TypingIndicator.BackColor = SystemColors.ControlDark;
			this.TypingIndicator.Font = new Font("Segoe UI",10F);
			this.TypingIndicator.Location = new Point(0,386);
			this.TypingIndicator.Name = "TypingIndicator";
			this.TypingIndicator.Size = new Size(784,25);
			this.TypingIndicator.TabIndex = 6;
			this.TypingIndicator.Text = "label1";
			this.TypingIndicator.TextAlign = ContentAlignment.MiddleLeft;
			this.TypingIndicator.Visible = false;
			// 
			// ChatScreen
			// 
			this.AutoScaleDimensions = new SizeF(7F,15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.Controls.Add(this.TypingIndicator);
			this.Controls.Add(this.MessagesPanel);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "ChatScreen";
			this.Size = new Size(784,461);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		#endregion

		internal Panel panel1;
		internal Label BackBtn;
		internal Panel panel2;
		private TextBox MessageBox;
		internal Button SendBtn;
		private FlowLayoutPanel MessagesPanel;
		private ContextMenuStrip ContextMenu;
		private ToolStripMenuItem DeleteToolStripMenuItem;
		private ToolStripMenuItem DeleteForMeToolStripMenuItem;
		private Label TypingIndicator;
	}
}
