namespace SoftwareDesign.lab2.Views {
	partial class ChatCreationScreen {
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
			panel1 = new Panel();
			CancelBtn = new Button();
			CreateBtn = new Button();
			UsernameBox = new TextBox();
			label1 = new Label();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.ButtonFace;
			panel1.Controls.Add(CancelBtn);
			panel1.Controls.Add(CreateBtn);
			panel1.Controls.Add(UsernameBox);
			panel1.Controls.Add(label1);
			panel1.Location = new Point(10,10);
			panel1.Margin = new Padding(10);
			panel1.Name = "panel1";
			panel1.Size = new Size(255,135);
			panel1.TabIndex = 1;
			// 
			// CancelBtn
			// 
			CancelBtn.AutoSize = true;
			CancelBtn.Font = new Font("Segoe UI",12F);
			CancelBtn.Location = new Point(173,89);
			CancelBtn.Name = "CancelBtn";
			CancelBtn.Size = new Size(75,31);
			CancelBtn.TabIndex = 5;
			CancelBtn.Text = "Cancel";
			CancelBtn.UseVisualStyleBackColor = true;
			// 
			// CreateBtn
			// 
			CreateBtn.AutoSize = true;
			CreateBtn.Font = new Font("Segoe UI",12F);
			CreateBtn.Location = new Point(94,89);
			CreateBtn.Name = "CreateBtn";
			CreateBtn.Size = new Size(75,31);
			CreateBtn.TabIndex = 4;
			CreateBtn.Text = "Create";
			CreateBtn.UseVisualStyleBackColor = true;
			// 
			// UsernameBox
			// 
			UsernameBox.Font = new Font("Segoe UI",12F);
			UsernameBox.Location = new Point(6,44);
			UsernameBox.Margin = new Padding(6);
			UsernameBox.Name = "UsernameBox";
			UsernameBox.Size = new Size(243,29);
			UsernameBox.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI",20F);
			label1.Location = new Point(3,6);
			label1.Name = "label1";
			label1.Size = new Size(142,37);
			label1.TabIndex = 0;
			label1.Text = "Username:";
			// 
			// ChatCreationScreen
			// 
			AutoScaleDimensions = new SizeF(7F,15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveBorder;
			Controls.Add(panel1);
			Name = "ChatCreationScreen";
			Size = new Size(275,157);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		internal Button CancelBtn;
		internal Button CreateBtn;
		internal TextBox UsernameBox;
		private Label label1;
	}
}
