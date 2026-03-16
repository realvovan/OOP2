using lab3.BLL.DTOs;
using lab3.DAL.Interfaces;
using lab3.Domain;

namespace lab3.BLL;

public class TasksService {
	private readonly IUnitOfWork _uow;

	private IRepository<TaskItem> _tasks => this._uow.Tasks;

	public async Task<ActionResult> CreateTaskAsync(TaskItemDto task) {
		try {
			this._tasks.Add(task.ToEntity());
		} catch (Exception e) {
			return ActionResult.Fail($"Couldn't create task. {e.Message}");
		}
		return await this.SaveAllChangesAsync();
	}

	public async Task<ActionResult> RemoveTaskAsync(Guid taskId) {
		var task = await this._tasks.GetByIdAsync(taskId);
		if (task is null) return ActionResult.Fail($"No task with given id exists ({taskId})");
		this._tasks.Remove(task);
		return await this.SaveAllChangesAsync();
	}

	public async Task<IEnumerable<TaskItemDto>> GetAllTasksAsync() {
		var tasks = await this._tasks.GetAllAsync();
		return tasks.Select(TaskItemDto.FromEntity);
	}

	public async Task<TaskItemDto?> GetTaskAsync(Guid taskId) {
		var task = await this._tasks.GetByIdAsync(taskId);
		if (task is null) return null;
		return TaskItemDto.FromEntity(task);
	}

	public async Task<ActionResult> UpdateTaskAsync(TaskItemDto updatedTask) {
		var task = await this._tasks.GetByIdAsync(updatedTask.Id);
		if (task is null)
			return ActionResult.Fail($"No task with given id exists ({updatedTask.Id})");
		try {
			task.ChangeName(updatedTask.Name);
			task.ChangeDescription(updatedTask.Description);
			task.DueTime = updatedTask.DueTime;
			task.Status = updatedTask.Status;
			task.Proirity = updatedTask.Proirity;
			return await this.SaveAllChangesAsync();
		} catch (Exception e) {
			return ActionResult.Fail($"Couldn't update task. {e.Message}");
		}
	}

	public async Task<ActionResult> SetTaskPriority(Guid taskId,int proirity) {
		var task = await this._tasks.GetByIdAsync(taskId);
		if (task is null) return ActionResult.Fail($"No task with given id exists ({taskId})");
		task.Proirity = (TaskProirity)Math.Clamp(proirity,(int)TaskProirity.None,(int)TaskProirity.High);
		return await this.SaveAllChangesAsync();
	}

	public async Task<ActionResult> SaveAllChangesAsync() => await UnitOfWorkHelper.SaveAllChanges(this._uow);

	public async Task<ActionResult> SetTaskStatus(Guid taskId,Domain.TaskStatus status) {
		var task = await this._tasks.GetByIdAsync(taskId);
		if (task is null) return ActionResult.Fail($"No task with given id exists ({taskId})");
		task.Status = status;
		return await this.SaveAllChangesAsync();
	}

	public TasksService(IUnitOfWork uow) {
		this._uow = uow;
	}
}
