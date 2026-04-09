using lab3.Domain.DTOs;

namespace lab3.BLL.Interfaces;
public interface IProjectService {
	Task<ProjectDto> CreateProjectAsync(ProjectDto projectDto);
	Task RemoveProjectAsync(Guid projectId);
	Task<ProjectDto?> GetProjectAsync(Guid projectId);
	Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();
	Task UpdateProjectAsync(ProjectDto updatedProject);
}
