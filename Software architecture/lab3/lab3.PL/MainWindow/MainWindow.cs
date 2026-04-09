using lab3.Domain.DTOs;
using Microsoft.Toolkit.Uwp.Notifications;

namespace lab3.PL;
public partial class MainWindow : Form {
	private readonly List<TaskItemDto> _loadedTasks = new();
	private readonly SimplifiedHttpClient _httpClient = new();
	private ProjectDisplay? _selectedProject;
	private TaskDisplay? _selectedTask;
	public MainWindow() {
		InitializeComponent();
		this.MaximumSize = this.Size;
		this.MinimumSize = this.Size;

		this.Disposed += (s,e) => this._httpClient.Dispose();

		this.ProjList.ControlRemoved += (_,_) => {
			this.NoProjectsLabel.Visible = this.ProjList.Controls.Count == 1;
			this.UpdateProjectLabelWidth();
		};
		this.ProjList.ControlAdded += (_,_) => {
			this.NoProjectsLabel.Visible = false;
			this.UpdateProjectLabelWidth();
		};
		this.TaskList.ControlAdded += (_,_) => {
			this.NoTasksLabel.Visible = false;
		};
		this.TaskList.ControlRemoved += (_,_) => {
			this.NoTasksLabel.Visible = this.TaskList.Controls.Count == 1;
			this.NoTasksLabel.Text = "No tasks found!";
		};
		this.ProjList.Click += (_,_) => {
			if (this._selectedProject is null) return;
			this._selectedProject.SetSelectionState(false);
			this._selectedProject = null;
			this._selectedTask = null;
			this.ToggleTopPanelButtons();
			this.UpdateProjectLabelWidth();
			this.ClearTaskDispaly();
			this.NoTasksLabel.Text = "Please select a projcet!";
		};
		this.TaskList.Click += (_,_) => {
			if (this._selectedTask is null) return;
			this._selectedTask.BackColor = TaskDisplay.BaseColor;
			this._selectedTask = null;
			this.ToggleTopPanelButtons();
		};
		this.LoadAllProjects();
		this.ToggleTopPanelButtons();
		var timer = new System.Windows.Forms.Timer();
		timer.Interval = 5000;
		timer.Tick += (_,_) => {
			foreach (var task in this._loadedTasks) {
				if (
					task.IsExparationNotified
					|| task.DueTime is null
					|| task.Status == Domain.TaskStatus.Completed
					|| task.DueTime > DateTime.Now
				) continue;

				task.IsExparationNotified = true;
				new ToastContentBuilder()
					.AddText($"Task \"{task.Name}\" is overdue!")
					.AddText(task.Description)
					.Show();

				foreach (var control in this.TaskList.Controls) {
					if (control is TaskDisplay display && display.TaskItem.Id == task.Id) {
						display.OverdueLabel.Visible = true;
						break;
					}
				}
			}
		};
		timer.Start();
	}
	private void ToggleTopPanelButtons() {
		if (this._selectedProject is null) {
			foreach (Control i in this.TopPanel.Controls) {
				if (i is UserButton button && button != this.ProjCreate) {
					button.Disable();
				}
			}
			return;
		}

		this.ProjEdit.Enable();
		this.ProjDelete.Enable();
		this.TaskCreate.Enable();

		bool isTaskSelected = this._selectedTask is not null;
		var status = this._selectedTask?.TaskItem.Status;
		this.TaskDelete.SetEnabled(isTaskSelected);
		this.TaskEdit.SetEnabled(isTaskSelected);
		this.TaskNotStarted.SetEnabled(isTaskSelected && status != Domain.TaskStatus.NotStarted);
		this.TaskInProgress.SetEnabled(isTaskSelected && status != Domain.TaskStatus.InProgress);
		this.TaskCompleted.SetEnabled(isTaskSelected && status != Domain.TaskStatus.Completed);
	}
}
