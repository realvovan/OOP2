namespace lab3.PL {
	partial class TaskEditor {
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
			this.label1 = new Label();
			this.TaskNameBox = new TextBox();
			this.DueDatePicker = new DateTimePicker();
			this.EnableDueTime = new CheckBox();
			this.label2 = new Label();
			this.label3 = new Label();
			this.PriorityBox = new ComboBox();
			this.TaskjDescBox = new RichTextBox();
			this.TaskjCancelBtn = new Button();
			this.TaskSaveBtn = new Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Segoe UI",16F);
			this.label1.Location = new Point(12,9);
			this.label1.Name = "label1";
			this.label1.Size = new Size(119,30);
			this.label1.TabIndex = 2;
			this.label1.Text = "Task name:";
			// 
			// TaskNameBox
			// 
			this.TaskNameBox.Font = new Font("Segoe UI",12F);
			this.TaskNameBox.Location = new Point(12,42);
			this.TaskNameBox.Name = "TaskNameBox";
			this.TaskNameBox.Size = new Size(366,29);
			this.TaskNameBox.TabIndex = 3;
			// 
			// DueDatePicker
			// 
			this.DueDatePicker.CustomFormat = "HH:mm dd-MMM-yyyy dddd";
			this.DueDatePicker.Enabled = false;
			this.DueDatePicker.Font = new Font("Segoe UI",10F);
			this.DueDatePicker.Format = DateTimePickerFormat.Custom;
			this.DueDatePicker.Location = new Point(153,77);
			this.DueDatePicker.Name = "DueDatePicker";
			this.DueDatePicker.Size = new Size(225,25);
			this.DueDatePicker.TabIndex = 4;
			// 
			// EnableDueTime
			// 
			this.EnableDueTime.AutoSize = true;
			this.EnableDueTime.Font = new Font("Segoe UI",12F);
			this.EnableDueTime.Location = new Point(12,77);
			this.EnableDueTime.Name = "EnableDueTime";
			this.EnableDueTime.Size = new Size(119,25);
			this.EnableDueTime.TabIndex = 5;
			this.EnableDueTime.Text = "Set due time:";
			this.EnableDueTime.UseVisualStyleBackColor = true;
			this.EnableDueTime.CheckedChanged += this.EnableDueTime_CheckedChanged;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Segoe UI",16F);
			this.label2.Location = new Point(12,152);
			this.label2.Name = "label2";
			this.label2.Size = new Size(172,30);
			this.label2.TabIndex = 6;
			this.label2.Text = "Task description:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Segoe UI",16F);
			this.label3.Location = new Point(12,111);
			this.label3.Name = "label3";
			this.label3.Size = new Size(87,30);
			this.label3.TabIndex = 7;
			this.label3.Text = "Priority:";
			// 
			// PriorityBox
			// 
			this.PriorityBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.PriorityBox.Font = new Font("Segoe UI",10F);
			this.PriorityBox.FormattingEnabled = true;
			this.PriorityBox.Items.AddRange(new object[] { "None","Low","Medium","High" });
			this.PriorityBox.Location = new Point(153,116);
			this.PriorityBox.Name = "PriorityBox";
			this.PriorityBox.Size = new Size(225,25);
			this.PriorityBox.TabIndex = 8;
			// 
			// TaskjDescBox
			// 
			this.TaskjDescBox.Font = new Font("Segoe UI",12F);
			this.TaskjDescBox.Location = new Point(12,185);
			this.TaskjDescBox.Name = "TaskjDescBox";
			this.TaskjDescBox.Size = new Size(366,146);
			this.TaskjDescBox.TabIndex = 9;
			this.TaskjDescBox.Text = "";
			// 
			// TaskjCancelBtn
			// 
			this.TaskjCancelBtn.Font = new Font("Segoe UI",12F);
			this.TaskjCancelBtn.Location = new Point(303,338);
			this.TaskjCancelBtn.Name = "TaskjCancelBtn";
			this.TaskjCancelBtn.Size = new Size(75,34);
			this.TaskjCancelBtn.TabIndex = 11;
			this.TaskjCancelBtn.Text = "Cancel";
			this.TaskjCancelBtn.UseVisualStyleBackColor = true;
			this.TaskjCancelBtn.Click += this.TaskjCancelBtn_Click;
			// 
			// TaskSaveBtn
			// 
			this.TaskSaveBtn.Font = new Font("Segoe UI",12F);
			this.TaskSaveBtn.Location = new Point(222,338);
			this.TaskSaveBtn.Name = "TaskSaveBtn";
			this.TaskSaveBtn.Size = new Size(75,34);
			this.TaskSaveBtn.TabIndex = 10;
			this.TaskSaveBtn.Text = "Save";
			this.TaskSaveBtn.UseVisualStyleBackColor = true;
			this.TaskSaveBtn.Click += this.TaskSaveBtn_Click;
			// 
			// TaskEditor
			// 
			this.AutoScaleDimensions = new SizeF(7F,15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.AutoValidate = AutoValidate.EnablePreventFocusChange;
			this.ClientSize = new Size(390,384);
			this.Controls.Add(this.TaskjCancelBtn);
			this.Controls.Add(this.TaskSaveBtn);
			this.Controls.Add(this.TaskjDescBox);
			this.Controls.Add(this.PriorityBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.EnableDueTime);
			this.Controls.Add(this.DueDatePicker);
			this.Controls.Add(this.TaskNameBox);
			this.Controls.Add(this.label1);
			this.Font = new Font("Segoe UI",9F);
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "TaskEditor";
			this.Text = "Create a new task";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private Label label3;
		internal RichTextBox TaskjDescBox;
		internal Button TaskjCancelBtn;
		internal Button TaskSaveBtn;
		internal TextBox TaskNameBox;
		internal DateTimePicker DueDatePicker;
		internal CheckBox EnableDueTime;
		internal ComboBox PriorityBox;
	}
}