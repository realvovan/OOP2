using System.Threading.Tasks;
using lab3.Domain.DTOs;

namespace lab3.PL;

public partial class TaskEditor : Form {
	private readonly SimplifiedHttpClient _httpClient;
	private TaskItemDto _dto;
	private bool _isCanceled = true;
	private bool _isCreating;

	public TaskItemDto TaskItem => this._dto;
	public TaskEditor(SimplifiedHttpClient httpClient,TaskItemDto task) : this(httpClient) {
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
	public TaskEditor(SimplifiedHttpClient httpClient,ProjectDisplay selectedProject) : this(httpClient) {
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
	private TaskEditor(SimplifiedHttpClient httpClient) {
		InitializeComponent();
		this._httpClient = httpClient;
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

		if (this._isCreating) {
			var dtoFromServer = await this._httpClient.PostAsync<TaskItemDto,TaskItemDto>(ApiEndpoints.TaskItemCotroller.ROUTE,this._dto);
			if (dtoFromServer is null) return;
			this._dto.Id = dtoFromServer.Id;
		} else {
			bool success = await this._httpClient.PutAsync(ApiEndpoints.TaskItemCotroller.UPDATE_URL,this._dto);
			if (!success) return;
		}
		this._isCanceled = false;
		this.Close();
	}
}
