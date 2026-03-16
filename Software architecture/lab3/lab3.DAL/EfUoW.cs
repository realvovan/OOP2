using lab3.DAL.Interfaces;
using lab3.Domain;

namespace lab3.DAL;

public class EfUoW : IUnitOfWork {
	private readonly TasksManagerDbContext _dbContext;

	public IRepository<Project> Projects { get; }
	public IRepository<TaskItem> Tasks { get; }

	public async Task<int> SaveChangesAsync() => await this._dbContext.SaveChangesAsync();

	public EfUoW(TasksManagerDbContext dbContext) {
		this._dbContext = dbContext;
		this.Projects = new EfRepository<Project>(dbContext);
		this.Tasks = new EfRepository<TaskItem>(dbContext);
	}
}
