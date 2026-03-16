namespace lab3.PL {
	partial class ProjectEditor {
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
			this.ProjNameBox = new TextBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.ProjDescBox = new RichTextBox();
			this.ProjSaveBtn = new Button();
			this.ProjCancelBtn = new Button();
			this.SuspendLayout();
			// 
			// ProjNameBox
			// 
			this.ProjNameBox.Font = new Font("Segoe UI",12F);
			this.ProjNameBox.Location = new Point(12,42);
			this.ProjNameBox.Name = "ProjNameBox";
			this.ProjNameBox.Size = new Size(366,29);
			this.ProjNameBox.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Segoe UI",16F);
			this.label1.Location = new Point(12,9);
			this.label1.Name = "label1";
			this.label1.Size = new Size(145,30);
			this.label1.TabIndex = 1;
			this.label1.Text = "Project name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Segoe UI",16F);
			this.label2.Location = new Point(12,74);
			this.label2.Name = "label2";
			this.label2.Size = new Size(198,30);
			this.label2.TabIndex = 2;
			this.label2.Text = "Project description:";
			// 
			// ProjDescBox
			// 
			this.ProjDescBox.Font = new Font("Segoe UI",12F);
			this.ProjDescBox.Location = new Point(12,107);
			this.ProjDescBox.Name = "ProjDescBox";
			this.ProjDescBox.Size = new Size(366,182);
			this.ProjDescBox.TabIndex = 3;
			this.ProjDescBox.Text = "";
			// 
			// ProjSaveBtn
			// 
			this.ProjSaveBtn.Font = new Font("Segoe UI",12F);
			this.ProjSaveBtn.Location = new Point(222,295);
			this.ProjSaveBtn.Name = "ProjSaveBtn";
			this.ProjSaveBtn.Size = new Size(75,34);
			this.ProjSaveBtn.TabIndex = 4;
			this.ProjSaveBtn.Text = "Save";
			this.ProjSaveBtn.UseVisualStyleBackColor = true;
			this.ProjSaveBtn.Click += this.ProjSaveBtn_Click;
			// 
			// ProjCancelBtn
			// 
			this.ProjCancelBtn.Font = new Font("Segoe UI",12F);
			this.ProjCancelBtn.Location = new Point(303,295);
			this.ProjCancelBtn.Name = "ProjCancelBtn";
			this.ProjCancelBtn.Size = new Size(75,34);
			this.ProjCancelBtn.TabIndex = 5;
			this.ProjCancelBtn.Text = "Cancel";
			this.ProjCancelBtn.UseVisualStyleBackColor = true;
			this.ProjCancelBtn.Click += this.ProjCancelBtn_Click;
			// 
			// ProjectEditor
			// 
			this.AutoScaleDimensions = new SizeF(7F,15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(390,340);
			this.Controls.Add(this.ProjCancelBtn);
			this.Controls.Add(this.ProjSaveBtn);
			this.Controls.Add(this.ProjDescBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ProjNameBox);
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "ProjectEditor";
			this.Text = "Create new project";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private TextBox ProjNameBox;
		private Label label1;
		private Label label2;
		private RichTextBox ProjDescBox;
		private Button ProjSaveBtn;
		private Button ProjCancelBtn;
	}
}