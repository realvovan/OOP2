namespace lab3.Domain;

public class Project : Entity {
	public string Name { get; private set; } = null!;
	public string Description { get; private set; } = null!;

	public ICollection<TaskItem> Tasks { get; private set; } = [];

	public void ChangeName(string newName) {
		if (string.IsNullOrWhiteSpace(newName)) throw new ArgumentException("Project name cannot be null or whitespace",nameof(newName));
		this.Name = newName;
	}
	public void ChangeDescription(string newDescription) => this.Description = newDescription;

	public Project(string name,string description) {
		this.ChangeName(name);
		this.ChangeDescription(description);
	}
}