namespace lab3.PL {
	partial class TaskDisplay {
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
			this.TaskStatusLabel = new Label();
			this.OverdueLabel = new Label();
			this.TaskName = new Label();
			this.TaskDescription = new Label();
			this.PriorityLabel = new Label();
			this.TimestampLabel = new Label();
			this.DueLabel = new Label();
			this.SuspendLayout();
			// 
			// TaskStatusLabel
			// 
			this.TaskStatusLabel.AutoSize = true;
			this.TaskStatusLabel.ForeColor = SystemColors.GrayText;
			this.TaskStatusLabel.Location = new Point(138,0);
			this.TaskStatusLabel.Margin = new Padding(0);
			this.TaskStatusLabel.Name = "TaskStatusLabel";
			this.TaskStatusLabel.Size = new Size(66,15);
			this.TaskStatusLabel.TabIndex = 0;
			this.TaskStatusLabel.Text = "Not started";
			// 
			// OverdueLabel
			// 
			this.OverdueLabel.AutoSize = true;
			this.OverdueLabel.Font = new Font("Segoe UI",9F,FontStyle.Bold | FontStyle.Italic);
			this.OverdueLabel.ForeColor = Color.Firebrick;
			this.OverdueLabel.Location = new Point(0,0);
			this.OverdueLabel.Margin = new Padding(0);
			this.OverdueLabel.Name = "OverdueLabel";
			this.OverdueLabel.Size = new Size(57,15);
			this.OverdueLabel.TabIndex = 1;
			this.OverdueLabel.Text = "Overdue!";
			// 
			// TaskName
			// 
			this.TaskName.AutoSize = true;
			this.TaskName.Font = new Font("Segoe UI",10F,FontStyle.Bold);
			this.TaskName.Location = new Point(16,15);
			this.TaskName.Name = "TaskName";
			this.TaskName.Size = new Size(113,19);
			this.TaskName.TabIndex = 2;
			this.TaskName.Text = "Task name here";
			// 
			// TaskDescription
			// 
			this.TaskDescription.AutoSize = true;
			this.TaskDescription.Font = new Font("Segoe UI",9F);
			this.TaskDescription.Location = new Point(0,34);
			this.TaskDescription.MinimumSize = new Size(0,25);
			this.TaskDescription.Name = "TaskDescription";
			this.TaskDescription.Size = new Size(92,25);
			this.TaskDescription.TabIndex = 3;
			this.TaskDescription.Text = "Task description";
			// 
			// PriorityLabel
			// 
			this.PriorityLabel.BackColor = Color.Transparent;
			this.PriorityLabel.Font = new Font("Segoe UI",9F,FontStyle.Bold);
			this.PriorityLabel.ForeColor = Color.DarkOrange;
			this.PriorityLabel.Location = new Point(0,18);
			this.PriorityLabel.Name = "PriorityLabel";
			this.PriorityLabel.Size = new Size(19,16);
			this.PriorityLabel.TabIndex = 4;
			// 
			// TimestampLabel
			// 
			this.TimestampLabel.AutoSize = true;
			this.TimestampLabel.Location = new Point(0,94);
			this.TimestampLabel.Name = "TimestampLabel";
			this.TimestampLabel.Size = new Size(159,15);
			this.TimestampLabel.TabIndex = 5;
			this.TimestampLabel.Text = "Created on: 12/02/2026 18:43";
			// 
			// DueLabel
			// 
			this.DueLabel.AutoSize = true;
			this.DueLabel.Location = new Point(0,109);
			this.DueLabel.Name = "DueLabel";
			this.DueLabel.Size = new Size(122,15);
			this.DueLabel.TabIndex = 6;
			this.DueLabel.Text = "Due: 12/02/2026 18:43";
			// 
			// TaskDisplay
			// 
			this.AutoScaleDimensions = new SizeF(7F,15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.ButtonHighlight;
			this.Controls.Add(this.DueLabel);
			this.Controls.Add(this.TimestampLabel);
			this.Controls.Add(this.PriorityLabel);
			this.Controls.Add(this.TaskDescription);
			this.Controls.Add(this.TaskName);
			this.Controls.Add(this.OverdueLabel);
			this.Controls.Add(this.TaskStatusLabel);
			this.Name = "TaskDisplay";
			this.Size = new Size(204,126);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		internal Label TaskStatusLabel;
		internal Label OverdueLabel;
		internal Label TaskName;
		internal Label TaskDescription;
		internal Label PriorityLabel;
		internal Label TimestampLabel;
		internal Label DueLabel;
	}
}
