using lab3.Domain.DTOs;

namespace lab3.PL;

partial class MainWindow {
	private TaskDisplay CreateTaskLabel(TaskItemDto taskItem) {
		var label = new TaskDisplay(taskItem);
		label.SubscribeToClickEvent(this.TaskDisplay_Click);
		label.Visible = taskItem.Status != Domain.TaskStatus.Completed || this.ShowCompleted.Checked;
		label.Name = taskItem.Id.ToString();
		this.Tooltip.SetToolTip(label.TaskName,taskItem.Name);
		this.TaskList.Controls.Add(label);
		label.UpdateTextLabels();
		return label;
	}
	private void ClearTaskDispaly() {
		for (int i = 0; i < this.TaskList.Controls.Count; i++) {
			var label = this.TaskList.Controls[i] as TaskDisplay;
			if (label is not null) {
				label.Remove(this.TaskDisplay_Click);
				i--;
			}
		}
	}
	private async Task SetSelectedTaskStatus(Domain.TaskStatus status) {
		if (this._selectedTask is null) return;
		bool result = await this._httpClient.PatchAsync(
			ApiEndpoints.TaskItemCotroller.UPDATE_STATUS_URL + $"?taskId={this._selectedTask.TaskItem.Id}&status={status}"
		);
		if (!result) return;
		this._selectedTask.TaskItem.Status = status;
		this._selectedTask.UpdateTextLabels();
		this._selectedTask.Visible = status != Domain.TaskStatus.Completed || this.ShowCompleted.Checked;
		this.ToggleTopPanelButtons();
	}

	private void TaskCreate_Click(object sender,EventArgs e) {
		if (!this.TaskCreate.Enabled) return;
		if (this._selectedProject is null) {
			MessageBox.Show(
				text:"Couldn't open the task editor because there is no selected project. Please select a project and try again!",
				caption:"Oops!",
				icon:MessageBoxIcon.Exclamation,
				buttons:MessageBoxButtons.OK
			);
			return;
		}
		using var taskEditor = new TaskEditor(this._httpClient,this._selectedProject);
		bool result = taskEditor.ShowDialog();
		if (!result) return;
		this.CreateTaskLabel(taskEditor.TaskItem);
		this._loadedTasks.Add(taskEditor.TaskItem);
	}
	private void TaskDisplay_Click(object? sender,EventArgs e) {
		TaskDisplay? label = sender as TaskDisplay ?? ((sender as Label)?.Parent as TaskDisplay);
		if (label is null || label == this._selectedTask) return;
		if (this._selectedTask is not null) this._selectedTask.BackColor = TaskDisplay.BaseColor;
		label.BackColor = TaskDisplay.ClickedColor;
		this._selectedTask = label;
		this.ToggleTopPanelButtons();
	}
	private async void TaskEdit_Click(object sender,EventArgs e) {
		if (this._selectedTask is null) {
			this.ToggleTopPanelButtons();
			MessageBox.Show(
				caption: "Oops!",
				text: "Couldn't open the task editor. We couldn't find the task",
				icon: MessageBoxIcon.Exclamation,
				buttons: MessageBoxButtons.OK);
			return;
		}
		if (await this._httpClient.GetAsync<ProjectDto>(ApiEndpoints.TaskItemCotroller.ROUTE + $"/{this._selectedTask.TaskItem.Id}") is null) {
			MessageBox.Show(
				caption: "Oops!",
				text: $"Couldn't open the task editor. We couldn't find the task with id [{this._selectedTask.TaskItem.Id}]",
				icon: MessageBoxIcon.Exclamation,
				buttons: MessageBoxButtons.OK);
			return;
		}
		using var taskEditor = new TaskEditor(this._httpClient,this._selectedTask.TaskItem);
		bool result = taskEditor.ShowDialog();
		if (!result) return;
		this._selectedTask.TaskItem = taskEditor.TaskItem;
		this.Tooltip.SetToolTip(this._selectedTask.TaskName,this._selectedTask.TaskName.Text);
		this._selectedTask.UpdateTextLabels();
	}
	private async void TaskDelete_Click(object sender,EventArgs e) {
		if (this._selectedTask is null) return;
		bool success = await this._httpClient.DeleteAsync(ApiEndpoints.TaskItemCotroller.DELETE_URL + $"?taskId={this._selectedTask.TaskItem.Id}");
		if (!success) {
			this._selectedTask.BackColor = TaskDisplay.BaseColor;
			this._selectedTask = null;
			this.ToggleTopPanelButtons();
			return;
		}
		this._loadedTasks.Remove(this._selectedTask.TaskItem);
		this._selectedTask.Remove(this.TaskDisplay_Click);
		this._selectedTask = null;
		this.ToggleTopPanelButtons();
	}
	private void ShowCompleted_CheckedChanged(object sender,EventArgs e) {
		foreach (Control control in this.TaskList.Controls) {
			if (control is TaskDisplay display && display.TaskItem.Status == Domain.TaskStatus.Completed) {
				display.Visible = this.ShowCompleted.Checked;
			}
		}
	}

	private async void TaskNotStarted_Click(object sender,EventArgs e) => await this.SetSelectedTaskStatus(Domain.TaskStatus.NotStarted);
	private async void TaskInProgress_Click(object sender,EventArgs e) => await this.SetSelectedTaskStatus(Domain.TaskStatus.InProgress);
	private async void TaskCompleted_Click(object sender,EventArgs e) => await this.SetSelectedTaskStatus(Domain.TaskStatus.Completed);
}