namespace SoftwareArch.lab1;

static class Program {
	static void Main(string[] args) {
		if (args.Length == 0) throw new InvalidDataException("Invalid program arguments");
		string demoType = args[0].ToLower();
		if (demoType == "demo1") {
			Demo1.Run();
		} else if (demoType == "demo2") {
			Demo2.Run();
		} else {
			throw new InvalidDataException($"Invalid program argument ({demoType})");
		}
	}
}