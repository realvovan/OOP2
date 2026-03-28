using SoftwareDesign.lab2.Models;
using System.Net;
using System.Net.Http.Json;

class Program {
	const string ROUTE = "http://localhost:5251/api/audit";
	static async Task Main() {
		using var client = new HttpClient();
		bool isRunning = true;
		while (isRunning) {
			Console.WriteLine(new string('=',20));
			Console.WriteLine("Select option:\n1. View all entries\n2. View entries for a user\n3. Exit");
			string? input = Console.ReadLine();
			if (input == "1") {
				Console.Write("Enter limit: ");
				if (!int.TryParse(Console.ReadLine(),out int limit)) {
					Console.WriteLine("Invalid input");
					continue;
				}
				Console.Write("Enter offset: ");
				if (!int.TryParse(Console.ReadLine(),out int offset)) {
					Console.WriteLine("Invalid input");
					continue;
				}
				var result = await client.GetAsync(ROUTE + $"?limit={limit}&offset={offset}");
				if (result.StatusCode != HttpStatusCode.OK) {
					Console.WriteLine($"Error: {await result.Content.ReadAsStringAsync()}");
					continue;
				}
				var list = await result.Content.ReadFromJsonAsync<IEnumerable<AuditLogEntry>>();
				if (list is null) {
					Console.WriteLine("Couldnt deserialize list");
					continue;
				}
				printEntries(list);
			} else if (input == "2") {
				Console.Write("Enter limit: ");
				if (!int.TryParse(Console.ReadLine(),out int limit)) {
					Console.WriteLine("Invalid input");
					continue;
				}
				Console.Write("Enter offset: ");
				if (!int.TryParse(Console.ReadLine(),out int offset)) {
					Console.WriteLine("Invalid input");
					continue;
				}
				Console.Write("Enter user guid: ");
				Guid id = new Guid(Console.ReadLine()!);
				var result = await client.GetAsync(ROUTE + $"?limit={limit}&offset={offset}&userId={id}");
				if (result.StatusCode != HttpStatusCode.OK) {
					Console.WriteLine($"Error: {await result.Content.ReadAsStringAsync()}");
					continue;
				}
				var list = await result.Content.ReadFromJsonAsync<IEnumerable<AuditLogEntry>>();
				if (list is null) {
					Console.WriteLine("Couldnt deserialize list");
					continue;
				}
				printEntries(list);
			} else if (input == "3") {
				isRunning = false;
			} else {
				Console.WriteLine("Invalid input");
			}
		}
	}
	static void printEntries(IEnumerable<AuditLogEntry> entries) {
		foreach (var entry in entries) {
			Console.WriteLine($@"Entry ({entry.Id}) from user {entry.UserWhoTriggeredId}:");
			Console.WriteLine(entry.Message);
			Console.WriteLine(new string('+',20));
		}
	}
}