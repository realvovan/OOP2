using lab3.BLL;
using lab3.DAL;
using lab3.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace lab3.PL;
static class Program {
	[STAThread]
	static void Main() {
		var host = Host.CreateDefaultBuilder()
			.ConfigureServices((context,services) => {

				services.AddDbContext<TasksManagerDbContext>(options =>
					options.UseSqlite(context.Configuration.GetConnectionString("Default")));

				services.AddScoped<IUnitOfWork,EfUoW>();

				services.AddScoped<ProjectService>();
				services.AddScoped<TasksService>();

				services.AddTransient<MainWindow>();
			})
			.Build();
		ApplicationConfiguration.Initialize();
		var mainWindow = host.Services.GetRequiredService<MainWindow>();
		Application.Run(mainWindow);
	}
}