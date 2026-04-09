namespace lab3.PL;
static class Program {
	[STAThread]
	static void Main() {
		ApplicationConfiguration.Initialize();
		Application.Run(new MainWindow());
	}
}