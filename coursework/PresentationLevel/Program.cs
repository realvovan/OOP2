namespace Coursework.PresentationLevel;

/// <summary>
/// Starting point of the program. Launches a new instance of <see cref="MainWindow"/>
/// </summary>
static class Program {
	[STAThread]
	static void Main() {
		ApplicationConfiguration.Initialize();
		Application.Run(new MainWindow());
	}
}