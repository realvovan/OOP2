using lab3.BLL.DTOs;
using lab3.DAL.Interfaces;
using lab3.Domain;

namespace lab3.BLL;

public class ProjectService {
	private readonly IUnitOfWork _uow;

	private IRepository<Project> _projects => this._uow.Projects;

	public async Task<ActionResult> CreateProjectAsync(ProjectDto project) {
		try {
			this._projects.Add(project.ToEntity());
		} catch (Exception e) {
			return ActionResult.Fail($"Couldn't create project. {e.Message}");
		}
		return await this.SaveAllChangesAsync();
	}

	public async Task<ActionResult> RemoveProjectAsync(Guid projectId) {
		var project = await this._projects.GetByIdAsync(projectId);
		if (project is null) return ActionResult.Fail($"No project with given id exists ({projectId})");
		this._projects.Remove(project);
		return await this.SaveAllChangesAsync();
	}
	public async Task<ProjectDto?> GetProjectAsync(Guid projectId) {
		var project = await this._projects.GetByIdAsync(projectId);
		if (project is null) return null;
		return ProjectDto.FromEntity(project);
	}
	public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync() {
		var projects = await this._projects.GetAllAsync();
		return projects.Select(ProjectDto.FromEntity);
	}

	public async Task<ActionResult> UpdateProjectAsync(ProjectDto updatedProject) {
		var project = await this._projects.GetByIdAsync(updatedProject.Id);
		if (project is null) return ActionResult.Fail($"No project with given id exists ({updatedProject.Id})");
		try {
			project.ChangeName(updatedProject.Name);
			project.ChangeDescription(updatedProject.Description);
			return await this.SaveAllChangesAsync();
		} catch (Exception e) {
			return ActionResult.Fail($"Couldn't updated project. {e.Message}");
		}
	}

	public async Task<ActionResult> SaveAllChangesAsync() => await UnitOfWorkHelper.SaveAllChanges(this._uow);

	public ProjectService(IUnitOfWork uow) {
		this._uow = uow;
	}
}
