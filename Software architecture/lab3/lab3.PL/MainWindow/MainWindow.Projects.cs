using lab3.BLL.DTOs;

namespace lab3.PL;

partial class MainWindow {
	private ProjectDisplay CreateProjectLabel(ProjectDto project) {
		var label = new ProjectDisplay(project.Id);
		label.SetTitle(project.Name);
		label.SetDescription(project.Description);
		label.Click += this.ProjectDisplay_Click;
		label.ProjectName.Click += this.ProjectDisplay_Click;
		label.Name = project.Id.ToString();
		this.ProjList.Controls.Add(label);
		this.Tooltip.SetToolTip(label.ProjectName,label.ProjectName.Text);
		return label;
	}
	private async void LoadAllProjects() {
		foreach (var proj in await this._projectService.GetAllProjectsAsync()) {
			this.CreateProjectLabel(proj);
		}
		foreach (var task in await this._tasksService.GetAllTasksAsync()) {
			this._loadedTasks.Add(task);
		}
	}
	private void UpdateProjectLabelWidth() {
		int widht = ProjectDisplay.BASE_WIDTH;
		if (this.ProjList.VerticalScroll.Visible) widht -= SystemInformation.VerticalScrollBarWidth;
		foreach (Control i in this.ProjList.Controls) {
			if (i is ProjectDisplay) {
				i.Width = widht;
			}
		}
	}
	private void ProjCreate_Click(object sender,EventArgs e) {
		using var projectEditor = new ProjectEditor(this._projectService);
		bool result = projectEditor.ShowDialog();
		if (!result) return;
		ProjectDisplay label = this.CreateProjectLabel(projectEditor.Project);
		this.ProjectDisplay_Click(label,EventArgs.Empty);
	}
	private void ProjectDisplay_Click(object? sender,EventArgs e) {
		ProjectDisplay? label = sender as ProjectDisplay ?? ((sender as Label)?.Parent as ProjectDisplay);
		if (label is null || label == this._selectedProject) return;
		this._selectedProject?.SetSelectionState(false);
		this._selectedProject = label;
		this._selectedTask = null;
		this.ToggleTopPanelButtons();
		label.SetSelectionState(true);
		this.UpdateProjectLabelWidth();

		this.ClearTaskDispaly();
		var tasks = this._loadedTasks.Where(t => t.ProjectId == label.ProjectId);
		if (!tasks.Any()) {
			this.NoTasksLabel.Text = "No tasks found!";
		} else {
			foreach (var i in tasks) {
				this.CreateTaskLabel(i);
			}
		}
	}
	private async void ProjDelete_Click(object sender,EventArgs e) {
		if (this._selectedProject is null) return;
		var result = await this._projectService.RemoveProjectAsync(this._selectedProject.ProjectId);
		if (!result.Success) {
			MessageBox.Show(
				caption: "Oops!",
				text: $"We couldn't delete this project. Here's the reason: {result.Message}",
				icon: MessageBoxIcon.Exclamation,
				buttons: MessageBoxButtons.OK
			);
			this._selectedProject.SetSelectionState(false);
			this._selectedProject = null;
			this._selectedProject = null;
			this.ToggleTopPanelButtons();
			return;
		}
		this._loadedTasks.RemoveAll(t => t.ProjectId == this._selectedProject.ProjectId);
		this._selectedProject.Parent?.Controls.Remove(this._selectedProject);
		this._selectedProject.Click -= this.ProjectDisplay_Click;
		this._selectedProject.ProjectName.Click -= this.ProjectDisplay_Click;
		this._selectedProject.Dispose();
		this._selectedProject = null;
		this._selectedTask = null;
		this.ToggleTopPanelButtons();
		this.ClearTaskDispaly();
	}
	private async void ProjEdit_Click(object sender,EventArgs e) {
		if (this._selectedProject is null) {
			this.ToggleTopPanelButtons();
			MessageBox.Show(
				caption: "Oops!",
				text: "Couldn't open the project editor. We couldn't find the project",
				icon: MessageBoxIcon.Exclamation,
				buttons: MessageBoxButtons.OK);
			return;
		}
		var project = await this._projectService.GetProjectAsync(this._selectedProject.ProjectId);
		if (project is null) {
			MessageBox.Show(
				caption: "Oops!",
				text: $"Couldn't open the project editor. We couldn't find the project with id [{this._selectedProject.ProjectId}]",
				icon: MessageBoxIcon.Exclamation,
				buttons: MessageBoxButtons.OK);
			return;
		}
		using var projectEditor = new ProjectEditor(this._projectService,project);
		bool result = projectEditor.ShowDialog();
		if (!result) return;
		this._selectedProject.ProjectName.Text = projectEditor.Project.Name;
		this._selectedProject.ProjectDescription.Text = projectEditor.Project.Description;
		this.Tooltip.SetToolTip(this._selectedProject.ProjectName,this._selectedProject.ProjectName.Text);
		this._selectedProject.SetSelectionState(true);
	}
}
