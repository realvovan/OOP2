using lab3.BLL;
using lab3.BLL.DTOs;

namespace lab3.PL;

public partial class ProjectEditor : Form {
	private ProjectService _service;
	private ProjectDto _dto;
	private bool _isCanceled = true;
	private bool _isCreating;

	public ProjectDto Project => this._dto;

	public ProjectEditor(ProjectService projectService,ProjectDto? projectToEdit = null) {
		InitializeComponent();
		this._service = projectService;
		this.CancelButton = this.ProjCancelBtn;
		this.AcceptButton = this.ProjSaveBtn;
		if (projectToEdit is null) {
			this._isCreating = true;
			this._dto = new ProjectDto();
			this.Text = "Create a new project";
		} else {
			this._isCreating = false;
			this._dto = projectToEdit;
			this.Text = "Edit project";
			this.ProjNameBox.Text = projectToEdit.Name;
			this.ProjDescBox.Text = projectToEdit.Description;
		}
	}
	public new bool ShowDialog() {
		base.ShowDialog();
		if (this._isCanceled) {
			this._dto = null!;
			return false;
		} else {
			return true;
		}
	}

	private void ProjCancelBtn_Click(object sender,EventArgs e) {
		this._isCanceled = true;
		this.Close();
	}

	private async void ProjSaveBtn_Click(object sender,EventArgs e) {
		this.ProjCancelBtn.Enabled = false;
		this.ProjSaveBtn.Enabled = false;
		this._dto.Name = this.ProjNameBox.Text.Trim();
		this._dto.Description = this.ProjDescBox.Text.Trim();

		ActionResult dbResult;
		if (this._isCreating) {
			dbResult = await this._service.CreateProjectAsync(this._dto);
		} else {
			dbResult = await this._service.UpdateProjectAsync(this._dto);
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
			this.ProjSaveBtn.Enabled = true;
			this.ProjCancelBtn.Enabled = true;
			return;
		}
		this.Close();
	}
}
