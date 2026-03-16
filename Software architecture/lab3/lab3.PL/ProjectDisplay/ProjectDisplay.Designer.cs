namespace lab3.PL {
	partial class ProjectDisplay {
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
			this.ProjectName = new Label();
			this.ProjectDescription = new Label();
			this.SuspendLayout();
			// 
			// ProjectName
			// 
			this.ProjectName.AutoEllipsis = true;
			this.ProjectName.AutoSize = true;
			this.ProjectName.Font = new Font("Segoe UI",12F);
			this.ProjectName.Location = new Point(0,0);
			this.ProjectName.Margin = new Padding(0,0,0,5);
			this.ProjectName.Name = "ProjectName";
			this.ProjectName.Size = new Size(97,21);
			this.ProjectName.TabIndex = 0;
			this.ProjectName.Text = "Projectname";
			// 
			// ProjectDescription
			// 
			this.ProjectDescription.AutoSize = true;
			this.ProjectDescription.Location = new Point(0,26);
			this.ProjectDescription.Margin = new Padding(0);
			this.ProjectDescription.MaximumSize = new Size(194,0);
			this.ProjectDescription.MinimumSize = new Size(0,40);
			this.ProjectDescription.Name = "ProjectDescription";
			this.ProjectDescription.Size = new Size(32,40);
			this.ProjectDescription.TabIndex = 1;
			this.ProjectDescription.Text = "label";
			// 
			// ProjectDisplay
			// 
			this.AutoScaleDimensions = new SizeF(7F,15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.Control;
			this.Controls.Add(this.ProjectDescription);
			this.Controls.Add(this.ProjectName);
			this.Margin = new Padding(3,1,3,4);
			this.Name = "ProjectDisplay";
			this.Size = new Size(194,23);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		internal Label ProjectName;
		internal Label ProjectDescription;
	}
}
