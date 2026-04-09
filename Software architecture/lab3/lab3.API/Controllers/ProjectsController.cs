using lab3.BLL.Interfaces;
using lab3.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace lab3.API.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController(IProjectService projectService) : Controller {
	private IProjectService _projectService = projectService;
	[HttpPost]
	public async Task<IActionResult> CreateProjectAsync([FromBody] ProjectDto projectDto) {
		try {
			var project = await this._projectService.CreateProjectAsync(projectDto);
			return Ok(project);
		} catch (ArgumentException e) {
			return BadRequest(e.Message);
		}
	}
	[HttpDelete("delete")]
	public async Task<IActionResult> DeleteProjectAsync([FromQuery] Guid projId) {
		await this._projectService.RemoveProjectAsync(projId);
		return Ok();
	}
	[HttpGet("{guid}")]
	public async Task<IActionResult> GetProjectAsync(Guid guid) {
		var projectDto = await this._projectService.GetProjectAsync(guid);
		if (projectDto is null) return BadRequest();
		return Ok(projectDto);
	}
	[HttpGet]
	public async Task<IActionResult> GetAllProjectsAsync() {
		var projects = await this._projectService.GetAllProjectsAsync();
		return Ok(projects);
	}
	[HttpPut("update")]
	public async Task<IActionResult> UpdateProjectAsync([FromBody] ProjectDto projectDto) {
		try {
			await this._projectService.UpdateProjectAsync(projectDto);
			return Ok();
		} catch (Exception e) when (e is ArgumentException or InvalidDataException) {
			return BadRequest(e.Message);
		}
	}
}
