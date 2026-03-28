namespace SoftwareDesign.lab2.Views {
	partial class UserEditScreen {
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
			this.label1 = new Label();
			this.UsernameBox = new TextBox();
			this.DisplayNameBox = new TextBox();
			this.label2 = new Label();
			this.SaveBtn = new Button();
			this.CancelBtn = new Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = SystemColors.ButtonFace;
			this.panel1.Controls.Add(this.CancelBtn);
			this.panel1.Controls.Add(this.SaveBtn);
			this.panel1.Controls.Add(this.DisplayNameBox);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.UsernameBox);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new Point(10,10);
			this.panel1.Margin = new Padding(10);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(255,219);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Segoe UI",20F);
			this.label1.Location = new Point(3,6);
			this.label1.Name = "label1";
			this.label1.Size = new Size(142,37);
			this.label1.TabIndex = 0;
			this.label1.Text = "Username:";
			// 
			// UsernameBox
			// 
			this.UsernameBox.Font = new Font("Segoe UI",12F);
			this.UsernameBox.Location = new Point(6,44);
			this.UsernameBox.Margin = new Padding(6);
			this.UsernameBox.Name = "UsernameBox";
			this.UsernameBox.Size = new Size(243,29);
			this.UsernameBox.TabIndex = 1;
			// 
			// DisplayNameBox
			// 
			this.DisplayNameBox.Font = new Font("Segoe UI",12F);
			this.DisplayNameBox.Location = new Point(6,119);
			this.DisplayNameBox.Margin = new Padding(6);
			this.DisplayNameBox.Name = "DisplayNameBox";
			this.DisplayNameBox.Size = new Size(243,29);
			this.DisplayNameBox.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Segoe UI",20F);
			this.label2.Location = new Point(3,81);
			this.label2.Name = "label2";
			this.label2.Size = new Size(183,37);
			this.label2.TabIndex = 2;
			this.label2.Text = "Display name:";
			// 
			// SaveBtn
			// 
			this.SaveBtn.AutoSize = true;
			this.SaveBtn.Font = new Font("Segoe UI",12F);
			this.SaveBtn.Location = new Point(94,177);
			this.SaveBtn.Name = "SaveBtn";
			this.SaveBtn.Size = new Size(75,31);
			this.SaveBtn.TabIndex = 4;
			this.SaveBtn.Text = "Save";
			this.SaveBtn.UseVisualStyleBackColor = true;
			// 
			// CancelBtn
			// 
			this.CancelBtn.AutoSize = true;
			this.CancelBtn.Font = new Font("Segoe UI",12F);
			this.CancelBtn.Location = new Point(173,177);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new Size(75,31);
			this.CancelBtn.TabIndex = 5;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// UserEditScreen
			// 
			this.AutoScaleDimensions = new SizeF(7F,15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.ActiveBorder;
			this.Controls.Add(this.panel1);
			this.Name = "UserEditScreen";
			this.Size = new Size(275,239);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private Label label1;
		private Label label2;
		internal TextBox UsernameBox;
		internal Button SaveBtn;
		internal TextBox DisplayNameBox;
		internal Button CancelBtn;
	}
}
