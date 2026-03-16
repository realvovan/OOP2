using System.Threading.Tasks;
using lab3.BLL;
using lab3.BLL.DTOs;

namespace lab3.PL;

public partial class TaskEditor : Form {
	private readonly TasksService _service;
	private TaskItemDto _dto;
	private bool _isCanceled = true;
	private bool _isCreating;

	public TaskItemDto TaskItem => this._dto;
	public TaskEditor(TasksService taskService,TaskItemDto task) : this(taskService) {
		this._isCreating = false;
		this._dto = task;
		this.Text = "Edit task";
		this.TaskNameBox.Text = task.Name;
		this.TaskjDescBox.Text = task.Description;
		this.PriorityBox.SelectedIndex = (int)task.Proirity;
		if (task.DueTime is null) {
			this.DueDatePicker.Value = DateTime.Now;
			this.EnableDueTime.Checked = false;
		} else {
			this.DueDatePicker.Value = task.DueTime.Value;
			this.EnableDueTime.Checked = true;
		}
	}
	public TaskEditor(TasksService taskService,ProjectDisplay selectedProject) : this(taskService) {
		this._isCreating = true;
		this._dto = new TaskItemDto {
			ProjectId = selectedProject.ProjectId,
			Status = Domain.TaskStatus.NotStarted
		};
		this.Text = "Create a new task";
		this.PriorityBox.SelectedIndex = 0;
		this.DueDatePicker.Value = DateTime.Now;
	}
#pragma warning disable CS8618
	private TaskEditor(TasksService taskService) {
		InitializeComponent();
		this._service = taskService;
		this.AcceptButton = this.TaskSaveBtn;
		this.CancelButton = this.TaskjCancelBtn;
	}
#pragma warning restore CS8618
	public new bool ShowDialog() {
		base.ShowDialog();
		if (this._isCanceled) {
			this._dto = null!;
			return false;
		} else {
			return true;
		}
	}
	private void EnableDueTime_CheckedChanged(object sender,EventArgs e) {
		this.DueDatePicker.Enabled = this.EnableDueTime.Checked;
	}
	private void TaskjCancelBtn_Click(object sender,EventArgs e) {
		this._isCanceled = true;
		this.Close();
	}
	private async void TaskSaveBtn_Click(object sender,EventArgs e) {
		this.TaskSaveBtn.Enabled = false;
		this.TaskjCancelBtn.Enabled = false;
		this._dto.Name = this.TaskNameBox.Text;
		this._dto.Description = this.TaskjDescBox.Text;
		this._dto.Proirity = (Domain.TaskProirity)this.PriorityBox.SelectedIndex;
		this._dto.DueTime = this.EnableDueTime.Checked ? this.DueDatePicker.Value : null;
		this._dto.IsExparationNotified = false;

		ActionResult dbResult;
		if (this._isCreating) {
			dbResult = await this._service.CreateTaskAsync(this._dto);
		} else {
			dbResult = await this._service.UpdateTaskAsync(this._dto);
		}
		if (dbResult.Success) {
			this._isCanceled = false;
			this.Close();
			return;
		}
		this._isCanceled = true;
		var dialogResult = MessageBox.Show(
			caption: "Oops!",
			text: $"We couldn't save changes. Here's the reason: {dbResult.Message}",
			icon: MessageBoxIcon.Exclamation,
			buttons: MessageBoxButtons.RetryCancel
		);
		if (dialogResult == DialogResult.Retry) {
			this.TaskSaveBtn.Enabled = true;
			this.TaskjCancelBtn.Enabled = true;
			return;
		}
		this.Close();
	}
}
