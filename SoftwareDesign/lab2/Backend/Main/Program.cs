using Microsoft.EntityFrameworkCore;
using SoftwareDesign.lab2.Models;
using SoftwareDesign.lab2.Services;
using SoftwareDesign.lab2.Storage;

namespace SoftwareDesign.lab2.Main;

public static class Program {
	public static void Main() {
		var builder = WebApplication.CreateBuilder();

		builder.Services.AddDbContext<DatabaseContext>(options =>
			options.UseSqlite(builder.Configuration.GetConnectionString("Default"))
		);

		builder.Services.AddSignalR();
		builder.Services.AddSingleton<QueueService>();
		builder.Services.AddScoped<AuditLogService>();
		builder.Services.AddScoped<MessageService>();
		builder.Services.AddScoped<UserService>();

		builder.Services.AddControllers();

		var app = builder.Build();
		app.MapControllers();
		app.MapHub<ChatHub>("/chat_hub");

		Task.Run(async () => {
			using var scope = app.Services.CreateScope();
			var messageService = scope.ServiceProvider.GetRequiredService<MessageService>();
			await messageService.processQueueAsync();
		}); // runs the queue worker

		app.Run();
	}
}