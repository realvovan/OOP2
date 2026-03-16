using lab3.Domain;

namespace lab3.BLL.DTOs;

public class TaskItemDto() {
	public Guid Id { get; set; } = Guid.NewGuid();
	public string Name { get; set; } = "Task";
	public string Description { get; set; } = string.Empty;
	public Guid ProjectId { get; set; }
	public Domain.TaskStatus Status { get; set; }
	public TaskProirity Proirity { get; set; }
	public DateTime CreatedAt { get; init; } = DateTime.Now;
	public DateTime? DueTime { get; set; }
	public bool IsExparationNotified { get; set; } = false;

	public TaskItem ToEntity() => new TaskItem(
		this.Name,
		this.Description,
		this.Proirity,
		this.ProjectId,
		this.Status,
		this.DueTime
	) {
		Id = this.Id,
		CreatedAt = this.CreatedAt
	};

	public static TaskItemDto FromEntity(TaskItem task) => new TaskItemDto {
		Id = task.Id,
		Name = task.Name,
		Description = task.Description,
		Proirity = task.Proirity,
		Status = task.Status,
		ProjectId = task.ProjectId,
		CreatedAt = task.CreatedAt,
		DueTime = task.DueTime
	};
}

public class ProjectDto() {
	public Guid Id { get; set; } = Guid.NewGuid();
	public string Name { get; set; } = "Project";
	public string Description { get; set; } = string.Empty;

	public Project ToEntity() => new Project(
		this.Name,
		this.Description
	) { Id = this.Id };

	public static ProjectDto FromEntity(Project project) => new ProjectDto {
		Id = project.Id,
		Name = project.Name,
		Description = project.Description,
	};
}