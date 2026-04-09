namespace lab3.Domain.DTOs;

public class TaskItemDto {
	public Guid Id { get; set; }
	public string Name { get; set; } = "Task";
	public string Description { get; set; } = string.Empty;
	public Guid ProjectId { get; set; }
	public TaskStatus Status { get; set; }
	public TaskProirity Proirity { get; set; }
	public DateTime CreatedAt { get; init; } = DateTime.Now;
	public DateTime? DueTime { get; set; }
	public bool IsExparationNotified { get; set; } = false;

	public TaskItem ToEntity(bool generateGuid) => new TaskItem(
		this.Name,
		this.Description,
		this.Proirity,
		this.ProjectId,
		this.Status,
		this.DueTime
	) {
		Id = generateGuid ? Guid.NewGuid() : this.Id,
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

public class ProjectDto {
	public Guid Id { get; set; }
	public string Name { get; set; } = "Project";
	public string Description { get; set; } = string.Empty;

	public Project ToEntity(bool generateGuid) => new Project(
		this.Name,
		this.Description
	) { Id = generateGuid ? Guid.NewGuid() : this.Id };

	public static ProjectDto FromEntity(Project project) => new ProjectDto {
		Id = project.Id,
		Name = project.Name,
		Description = project.Description,
	};
}