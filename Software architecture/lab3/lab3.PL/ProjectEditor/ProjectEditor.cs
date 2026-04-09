using lab3.Domain.DTOs;

namespace lab3.PL;

public partial class ProjectEditor : Form {
	private SimplifiedHttpClient _httpClient;
	private ProjectDto _dto;
	private bool _isCanceled = true;
	private bool _isCreating;

	public ProjectDto Project => this._dto;

	public ProjectEditor(SimplifiedHttpClient httpClient,ProjectDto? projectToEdit = null) {
		InitializeComponent();
		this._httpClient = httpClient;
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

		if (this._isCreating) {
			var dtoFromServer = await this._httpClient.PostAsync<ProjectDto,ProjectDto>(ApiEndpoints.ProjectsController.ROUTE,this._dto);
			if (dtoFromServer is null) return;
			this._dto.Id = dtoFromServer.Id;
		} else {
			bool success = await this._httpClient.PutAsync(ApiEndpoints.ProjectsController.UPDATE_URL,this._dto);
			if (!success) return;
		}
		this._isCanceled = false;
		this.Close();
	}
}
