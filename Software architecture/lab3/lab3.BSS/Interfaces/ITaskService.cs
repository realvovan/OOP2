using lab3.Domain.DTOs;

namespace lab3.BLL.Interfaces;
public interface ITaskService {
	Task<TaskItemDto> CreateTaskAsync(TaskItemDto taskDto);
	Task RemoveTaskAsync(Guid taskId);
	Task<IEnumerable<TaskItemDto>> GetAllTasksAsync();
	Task<TaskItemDto?> GetTaskAsync(Guid taskId);
	Task UpdateTaskAsync(TaskItemDto updatedTask);
	Task SetTaskPriority(Guid taskId,int proirity);
	Task SetTaskStatus(Guid taskId,Domain.TaskStatus status);
}
