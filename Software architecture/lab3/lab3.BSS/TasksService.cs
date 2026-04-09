using lab3.BLL.Interfaces;
using lab3.DAL.Interfaces;
using lab3.Domain;
using lab3.Domain.DTOs;

namespace lab3.BLL;

public class TasksService : ITaskService {
	private readonly IUnitOfWork _uow;

	private IRepository<TaskItem> _tasks => this._uow.Tasks;

	public async Task<TaskItemDto> CreateTaskAsync(TaskItemDto taskDto) {
		var taskItem = taskDto.ToEntity(true);
		this._tasks.Add(taskItem);
		await this._uow.SaveChangesAsync();
		return TaskItemDto.FromEntity(taskItem);
	}

	public async Task RemoveTaskAsync(Guid taskId) {
		var task = await this._tasks.GetByIdAsync(taskId)
			?? throw new InvalidDataException($"No task with given id exists ({taskId})");
		this._tasks.Remove(task);
		await this._uow.SaveChangesAsync();
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

	public async Task UpdateTaskAsync(TaskItemDto updatedTask) {
		var task = await this._tasks.GetByIdAsync(updatedTask.Id)
			?? throw new InvalidDataException($"No task with given id exists ({updatedTask.Id})");

		task.ChangeName(updatedTask.Name);
		task.ChangeDescription(updatedTask.Description);
		task.DueTime = updatedTask.DueTime;
		task.Status = updatedTask.Status;
		task.Proirity = updatedTask.Proirity;
		await this._uow.SaveChangesAsync();
	}

	public async Task SetTaskPriority(Guid taskId,int proirity) {
		var task = await this._tasks.GetByIdAsync(taskId)
			?? throw new InvalidDataException($"No task with given id exists ({taskId})");
		task.Proirity = (TaskProirity)Math.Clamp(proirity,(int)TaskProirity.None,(int)TaskProirity.High);
		await this._uow.SaveChangesAsync();
	}

	public async Task SetTaskStatus(Guid taskId,Domain.TaskStatus status) {
		var task = await this._tasks.GetByIdAsync(taskId)
			?? throw new InvalidDataException($"No task with given id exists ({taskId})");
		task.Status = status;
		await this._uow.SaveChangesAsync();
	}

	public TasksService(IUnitOfWork uow) {
		this._uow = uow;
	}
}
