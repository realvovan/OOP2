namespace lab3.PL {
	partial class MainWindow {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.TopPanel = new Panel();
			this.TaskCompleted = new UserButton();
			this.TaskInProgress = new UserButton();
			this.TaskNotStarted = new UserButton();
			this.TaskDelete = new UserButton();
			this.TaskEdit = new UserButton();
			this.TaskCreate = new UserButton();
			this.ProjDelete = new UserButton();
			this.ProjEdit = new UserButton();
			this.ProjCreate = new UserButton();
			this.ShowCompleted = new CheckBox();
			this.ProjList = new FlowLayoutPanel();
			this.NoProjectsLabel = new Label();
			this.panel1 = new Panel();
			this.Tooltip = new ToolTip(this.components);
			this.TaskList = new FlowLayoutPanel();
			this.NoTasksLabel = new Label();
			this.TopPanel.SuspendLayout();
			this.ProjList.SuspendLayout();
			this.TaskList.SuspendLayout();
			this.SuspendLayout();
			// 
			// TopPanel
			// 
			this.TopPanel.BackColor = SystemColors.ControlDark;
			this.TopPanel.BorderStyle = BorderStyle.FixedSingle;
			this.TopPanel.Controls.Add(this.TaskCompleted);
			this.TopPanel.Controls.Add(this.TaskInProgress);
			this.TopPanel.Controls.Add(this.TaskNotStarted);
			this.TopPanel.Controls.Add(this.TaskDelete);
			this.TopPanel.Controls.Add(this.TaskEdit);
			this.TopPanel.Controls.Add(this.TaskCreate);
			this.TopPanel.Controls.Add(this.ProjDelete);
			this.TopPanel.Controls.Add(this.ProjEdit);
			this.TopPanel.Controls.Add(this.ProjCreate);
			this.TopPanel.Location = new Point(0,0);
			this.TopPanel.Name = "TopPanel";
			this.TopPanel.Size = new Size(772,45);
			this.TopPanel.TabIndex = 0;
			// 
			// TaskCompleted
			// 
			this.TaskCompleted.BackColor = SystemColors.ButtonHighlight;
			this.TaskCompleted.Location = new Point(565,2);
			this.TaskCompleted.Name = "TaskCompleted";
			this.TaskCompleted.Size = new Size(77,39);
			this.TaskCompleted.TabIndex = 10;
			this.TaskCompleted.Text = "Mark as Completed";
			this.TaskCompleted.UseVisualStyleBackColor = false;
			this.TaskCompleted.Click += this.TaskCompleted_Click;
			// 
			// TaskInProgress
			// 
			this.TaskInProgress.BackColor = SystemColors.ButtonHighlight;
			this.TaskInProgress.Location = new Point(482,2);
			this.TaskInProgress.Name = "TaskInProgress";
			this.TaskInProgress.Size = new Size(77,39);
			this.TaskInProgress.TabIndex = 9;
			this.TaskInProgress.Text = "Mark as In progress";
			this.TaskInProgress.UseVisualStyleBackColor = false;
			this.TaskInProgress.Click += this.TaskInProgress_Click;
			// 
			// TaskNotStarted
			// 
			this.TaskNotStarted.BackColor = SystemColors.ButtonHighlight;
			this.TaskNotStarted.Location = new Point(399,2);
			this.TaskNotStarted.Name = "TaskNotStarted";
			this.TaskNotStarted.Size = new Size(77,39);
			this.TaskNotStarted.TabIndex = 8;
			this.TaskNotStarted.Text = "Mark as Not started";
			this.TaskNotStarted.UseVisualStyleBackColor = false;
			this.TaskNotStarted.Click += this.TaskNotStarted_Click;
			// 
			// TaskDelete
			// 
			this.TaskDelete.BackColor = SystemColors.ButtonHighlight;
			this.TaskDelete.Location = new Point(328,2);
			this.TaskDelete.Name = "TaskDelete";
			this.TaskDelete.Size = new Size(53,39);
			this.TaskDelete.TabIndex = 7;
			this.TaskDelete.Text = "Delete Task";
			this.TaskDelete.UseVisualStyleBackColor = false;
			this.TaskDelete.Click += this.TaskDelete_Click;
			// 
			// TaskEdit
			// 
			this.TaskEdit.BackColor = SystemColors.ButtonHighlight;
			this.TaskEdit.Location = new Point(269,2);
			this.TaskEdit.Name = "TaskEdit";
			this.TaskEdit.Size = new Size(53,39);
			this.TaskEdit.TabIndex = 6;
			this.TaskEdit.Text = "Edit Task";
			this.TaskEdit.UseVisualStyleBackColor = false;
			this.TaskEdit.Click += this.TaskEdit_Click;
			// 
			// TaskCreate
			// 
			this.TaskCreate.BackColor = SystemColors.ButtonHighlight;
			this.TaskCreate.Location = new Point(210,2);
			this.TaskCreate.Name = "TaskCreate";
			this.TaskCreate.Size = new Size(53,39);
			this.TaskCreate.TabIndex = 5;
			this.TaskCreate.Text = "New Task";
			this.TaskCreate.UseVisualStyleBackColor = false;
			this.TaskCreate.Click += this.TaskCreate_Click;
			// 
			// ProjDelete
			// 
			this.ProjDelete.BackColor = SystemColors.ButtonHighlight;
			this.ProjDelete.Location = new Point(132,2);
			this.ProjDelete.Name = "ProjDelete";
			this.ProjDelete.Size = new Size(53,39);
			this.ProjDelete.TabIndex = 4;
			this.ProjDelete.Text = "Delete Project";
			this.ProjDelete.UseVisualStyleBackColor = false;
			this.ProjDelete.Click += this.ProjDelete_Click;
			// 
			// ProjEdit
			// 
			this.ProjEdit.BackColor = SystemColors.ButtonHighlight;
			this.ProjEdit.Location = new Point(71,2);
			this.ProjEdit.Name = "ProjEdit";
			this.ProjEdit.Size = new Size(53,39);
			this.ProjEdit.TabIndex = 3;
			this.ProjEdit.Text = "Edit Project";
			this.ProjEdit.UseVisualStyleBackColor = false;
			this.ProjEdit.Click += this.ProjEdit_Click;
			// 
			// ProjCreate
			// 
			this.ProjCreate.BackColor = SystemColors.ButtonHighlight;
			this.ProjCreate.Location = new Point(10,2);
			this.ProjCreate.Name = "ProjCreate";
			this.ProjCreate.Size = new Size(53,39);
			this.ProjCreate.TabIndex = 2;
			this.ProjCreate.Text = "New Project";
			this.ProjCreate.UseVisualStyleBackColor = false;
			this.ProjCreate.Click += this.ProjCreate_Click;
			// 
			// ShowCompleted
			// 
			this.ShowCompleted.AutoSize = true;
			this.ShowCompleted.Checked = true;
			this.ShowCompleted.CheckState = CheckState.Checked;
			this.ShowCompleted.Location = new Point(528,391);
			this.ShowCompleted.Name = "ShowCompleted";
			this.ShowCompleted.Size = new Size(115,19);
			this.ShowCompleted.TabIndex = 11;
			this.ShowCompleted.Text = "Show completed";
			this.ShowCompleted.UseVisualStyleBackColor = true;
			this.ShowCompleted.CheckedChanged += this.ShowCompleted_CheckedChanged;
			// 
			// ProjList
			// 
			this.ProjList.AutoScroll = true;
			this.ProjList.BackColor = Color.FromArgb(210,210,210);
			this.ProjList.Controls.Add(this.NoProjectsLabel);
			this.ProjList.FlowDirection = FlowDirection.TopDown;
			this.ProjList.Location = new Point(0,45);
			this.ProjList.Name = "ProjList";
			this.ProjList.Size = new Size(200,365);
			this.ProjList.TabIndex = 1;
			this.ProjList.WrapContents = false;
			// 
			// NoProjectsLabel
			// 
			this.NoProjectsLabel.AutoSize = true;
			this.NoProjectsLabel.Font = new Font("Segoe UI",14F,FontStyle.Italic);
			this.NoProjectsLabel.Location = new Point(17,30);
			this.NoProjectsLabel.Margin = new Padding(17,30,3,0);
			this.NoProjectsLabel.Name = "NoProjectsLabel";
			this.NoProjectsLabel.Size = new Size(163,25);
			this.NoProjectsLabel.TabIndex = 0;
			this.NoProjectsLabel.Text = "No projects found!";
			// 
			// panel1
			// 
			this.panel1.BackColor = SystemColors.ActiveCaptionText;
			this.panel1.Location = new Point(200,0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(2,410);
			this.panel1.TabIndex = 2;
			// 
			// TaskList
			// 
			this.TaskList.AutoScroll = true;
			this.TaskList.Controls.Add(this.NoTasksLabel);
			this.TaskList.Location = new Point(203,48);
			this.TaskList.Name = "TaskList";
			this.TaskList.Size = new Size(440,337);
			this.TaskList.TabIndex = 12;
			// 
			// NoTasksLabel
			// 
			this.NoTasksLabel.AutoSize = true;
			this.NoTasksLabel.Font = new Font("Segoe UI",14F,FontStyle.Italic);
			this.NoTasksLabel.Location = new Point(150,30);
			this.NoTasksLabel.Margin = new Padding(150,30,3,0);
			this.NoTasksLabel.Name = "NoTasksLabel";
			this.NoTasksLabel.Size = new Size(195,25);
			this.NoTasksLabel.TabIndex = 1;
			this.NoTasksLabel.Text = "Please select a project!";
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new SizeF(7F,15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.ControlLight;
			this.ClientSize = new Size(646,411);
			this.Controls.Add(this.TaskList);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.ShowCompleted);
			this.Controls.Add(this.ProjList);
			this.Controls.Add(this.TopPanel);
			this.MaximizeBox = false;
			this.Name = "MainWindow";
			this.Text = "Project manager";
			this.TopPanel.ResumeLayout(false);
			this.ProjList.ResumeLayout(false);
			this.ProjList.PerformLayout();
			this.TaskList.ResumeLayout(false);
			this.TaskList.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private Panel TopPanel;
		private FlowLayoutPanel ProjList;
		private UserButton ProjDelete;
		private UserButton ProjEdit;
		private UserButton ProjCreate;
		private Panel panel1;
		private Label NoProjectsLabel;
		private ToolTip Tooltip;
		private UserButton TaskCreate;
		private UserButton TaskDelete;
		private UserButton TaskEdit;
		private UserButton TaskCompleted;
		private UserButton TaskInProgress;
		private UserButton TaskNotStarted;
		private CheckBox ShowCompleted;
		private FlowLayoutPanel TaskList;
		private Label NoTasksLabel;
	}
}
