using Microsoft.EntityFrameworkCore;
using SoftwareDesign.lab2.Models;
using SoftwareDesign.lab2.Services;
using SoftwareDesign.lab2.Storage;

var builder = WebApplication.CreateBuilder(args);

if (!builder.Environment.IsEnvironment("testing")) {
	builder.Services.AddDbContext<DatabaseContext>(options =>
		options.UseSqlite(builder.Configuration.GetConnectionString("Default"))
);
}


builder.Services.AddSignalR();
builder.Services.AddSingleton<QueueService>();
builder.Services.AddScoped<AuditLogService>();
builder.Services.AddScoped<MessageService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.MapHub<ChatHub>("/chat_hub");

_ = Task.Run(async () => {
	using var scope = app.Services.CreateScope();
	var messageService = scope.ServiceProvider.GetRequiredService<MessageService>();
	await messageService.processQueueAsync();
}); // runs the queue worker

app.Run();
public partial class Program { }