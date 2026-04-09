using lab3.BLL.Interfaces;
using lab3.Domain;
using lab3.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace lab3.API.Controllers;

[ApiController]
[Route("api/tasks")]
public class TaskItemsController(ITaskService taskService) : Controller {
	private ITaskService _taskService = taskService;

	[HttpPost]
	public async Task<IActionResult> CreateTaskAsync([FromBody] TaskItemDto taskDto) {
		try {
			var task = await this._taskService.CreateTaskAsync(taskDto);
			return Ok(task);
		} catch (ArgumentException e) {
			return BadRequest(e.Message);
		}
	}
	[HttpDelete("delete")]
	public async Task<IActionResult> RemoveTaskAsync([FromQuery] Guid taskId) {
		await this._taskService.RemoveTaskAsync(taskId);
		return Ok();
	}
	[HttpGet]
	public async Task<IActionResult> GetAllTasksAsync() {
		var tasks = await this._taskService.GetAllTasksAsync();
		return Ok(tasks);
	}
	[HttpGet("{guid}")]
	public async Task<IActionResult> GetTaskAsync(Guid guid) {
		var taskDto = await this._taskService.GetTaskAsync(guid);
		if (taskDto is null) return BadRequest();
		return Ok(taskDto);
	}
	[HttpPut("update")]
	public async Task<IActionResult> UpdateTaskAsync([FromBody] TaskItemDto taskDto) {
		try {
			await this._taskService.UpdateTaskAsync(taskDto);
			return Ok();
		} catch (Exception e) when (e is ArgumentException or InvalidDataException) {
			return BadRequest(e.Message);
		}
	}
	[HttpPatch("update_priority")]
	public async Task<IActionResult> UpdateTaskPriorityAsync([FromQuery] Guid taskId,[FromQuery] int priority) {
		try {
			await this._taskService.SetTaskPriority(taskId,priority);
			return Ok();
		} catch (InvalidDataException e) {
			return BadRequest(e.Message);
		}
	}
	[HttpPatch("update_status")]
	public async Task<IActionResult> UpdateTaskStatusAsync([FromQuery] Guid taskId,[FromQuery] Domain.TaskStatus status) {
		try {
			await this._taskService.SetTaskStatus(taskId,status);
			return Ok();
		} catch (InvalidDataException e) {
			return BadRequest(e.Message);
		}
	}
}
