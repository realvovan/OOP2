namespace SoftwareDesign.lab2.Views {
	partial class MessageLabel {
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
			UsernameLabel = new Label();
			ContentsLabel = new Label();
			SuspendLayout();
			// 
			// UsernameLabel
			// 
			UsernameLabel.AutoSize = true;
			UsernameLabel.Font = new Font("Segoe UI",12F,FontStyle.Bold);
			UsernameLabel.Location = new Point(0,0);
			UsernameLabel.MaximumSize = new Size(770,0);
			UsernameLabel.Name = "UsernameLabel";
			UsernameLabel.Size = new Size(87,21);
			UsernameLabel.TabIndex = 0;
			UsernameLabel.Text = "Username";
			// 
			// ContentsLabel
			// 
			ContentsLabel.AutoSize = true;
			ContentsLabel.Font = new Font("Segoe UI",10F);
			ContentsLabel.Location = new Point(0,21);
			ContentsLabel.MaximumSize = new Size(770,0);
			ContentsLabel.Name = "ContentsLabel";
			ContentsLabel.Size = new Size(154,19);
			ContentsLabel.TabIndex = 1;
			ContentsLabel.Text = "Message text goes here";
			// 
			// MessageLabel
			// 
			AutoScaleDimensions = new SizeF(7F,15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(ContentsLabel);
			Controls.Add(UsernameLabel);
			Name = "MessageLabel";
			Size = new Size(750,47);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		internal Label UsernameLabel;
		internal Label ContentsLabel;
	}
}
