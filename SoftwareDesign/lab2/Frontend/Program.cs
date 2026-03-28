using SoftwareDesign.lab2.Views;

namespace SoftwareDesign.lab2.Main;

static class Program {
	[STAThread]
	static void Main() {
		using var client = new Messenger();

		ApplicationConfiguration.Initialize();
		Application.Run(new LoginPage(client));
		Console.WriteLine("App closing");
	}
}