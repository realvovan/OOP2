namespace lab3.Domain;

public class TaskItem : Entity {
	public string Name { get; private set; } = null!;
	public string Description { get; private set; } = null!;
	public TaskStatus Status { get; set; }
	public TaskProirity Proirity { get; set; }
	public DateTime CreatedAt { get; init; } = DateTime.Now;
	public DateTime? DueTime { get; set; }

	public Guid ProjectId { get; private set; }
	public Project Project { get; private set; } = null!;

	public void ChangeName(string newName) {
		if (string.IsNullOrWhiteSpace(newName)) throw new ArgumentException("Project name cannot be null or whitespace",nameof(newName));
		this.Name = newName;
	}
	public void ChangeDescription(string newDescription) => this.Description = newDescription;

	private TaskItem() {}
	public TaskItem(string name,string description,TaskProirity proirity,Guid projectId,TaskStatus status = TaskStatus.NotStarted,DateTime? dueTime = null) {
		this.ChangeName(name);
		this.ChangeDescription(description);
		this.Proirity = proirity;
		this.ProjectId = projectId;
		this.Status = status;
		this.DueTime = dueTime;
	}
}

public enum TaskStatus {
	NotStarted,
	InProgress,
	Completed
}

public enum TaskProirity {
	None,
	Low,
	Medium,
	High
}