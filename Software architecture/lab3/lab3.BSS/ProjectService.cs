using lab3.BLL.Interfaces;
using lab3.DAL.Interfaces;
using lab3.Domain;
using lab3.Domain.DTOs;

namespace lab3.BLL;

public class ProjectService : IProjectService {
	private readonly IUnitOfWork _uow;

	private IRepository<Project> _projects => this._uow.Projects;

	public async Task<ProjectDto> CreateProjectAsync(ProjectDto projectDto) {
		var project = projectDto.ToEntity(true);
		this._projects.Add(project);
		await this._uow.SaveChangesAsync();
		return ProjectDto.FromEntity(project);
	}

	public async Task RemoveProjectAsync(Guid projectId) {
		var project = await this._projects.GetByIdAsync(projectId)
			?? throw new InvalidDataException($"No project with given id exists ({projectId})");
		this._projects.Remove(project);
		await this._uow.SaveChangesAsync();
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

	public async Task UpdateProjectAsync(ProjectDto updatedProject) {
		var project = await this._projects.GetByIdAsync(updatedProject.Id)
			?? throw new InvalidDataException($"No project with given id exists ({updatedProject.Id})");
		project.ChangeName(updatedProject.Name);
		project.ChangeDescription(updatedProject.Description);
		await this._uow.SaveChangesAsync();
	}

	public ProjectService(IUnitOfWork uow) {
		this._uow = uow;
	}
}
