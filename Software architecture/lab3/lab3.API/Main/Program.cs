using lab3.BLL;
using lab3.BLL.Interfaces;
using lab3.DAL;
using lab3.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab3.API.Main;

static class Program {
	static void Main() {
		var builder = WebApplication.CreateBuilder();

		builder.Services.AddDbContext<TasksManagerDbContext>(options => 
			options.UseSqlite(builder.Configuration.GetConnectionString("Default"))
		);

		builder.Services.AddScoped<IUnitOfWork,EfUoW>();

		builder.Services.AddScoped<ITaskService,TasksService>();
		builder.Services.AddScoped<IProjectService,ProjectService>();

		builder.Services.AddControllers();

		var app = builder.Build();
		app.MapControllers();
		app.Run();
	}
}
