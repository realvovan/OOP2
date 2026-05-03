using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using SoftwareDesign.lab2.Storage;

namespace SoftwareDesign.lab2.Tests;
public sealed class TestWebApplicationFactory : WebApplicationFactory<Program> {
	protected override void ConfigureWebHost(IWebHostBuilder builder) {
		builder.UseEnvironment("testing");
		builder.ConfigureServices(services => {
			services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("TestingDb"));
		});
	}
	protected override void ConfigureClient(HttpClient client) {
		using var scope = Services.CreateScope();
		var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
		db.Database.EnsureCreated();
	}
}
