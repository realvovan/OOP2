using lab3.Domain;

namespace lab3.DAL.Interfaces;

public interface IUnitOfWork {
	IRepository<Project> Projects { get; }
	IRepository<TaskItem> Tasks { get; }

	Task<int> SaveChangesAsync();
}
