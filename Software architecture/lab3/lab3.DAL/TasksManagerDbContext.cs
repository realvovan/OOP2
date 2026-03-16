using Microsoft.EntityFrameworkCore;
using lab3.Domain;

namespace lab3.DAL;

public class TasksManagerDbContext(DbContextOptions<TasksManagerDbContext> options) : DbContext(options) {
	public DbSet<Project> Projects { get; set; }
	public DbSet<TaskItem> Tasks { get; set; }
	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		modelBuilder.Entity<Project>()
			.HasKey(p => p.Id);
		modelBuilder.Entity<Project>()
			.HasMany(p => p.Tasks)
			.WithOne(t => t.Project)
			.HasForeignKey(t => t.ProjectId)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<TaskItem>()
			.HasKey(t => t.Id);

		base.OnModelCreating(modelBuilder);
	}
}
