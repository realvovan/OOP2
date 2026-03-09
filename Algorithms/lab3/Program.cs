namespace Algorithms.lab3;

static class Program {
	static void Main(string[] args) {
		if (args.Length == 0) throw new Exception("No demo number");
		switch (args[0].ToLower()) {
			case "test1":
				Test1.Run();
				break;
			default:
				throw new Exception("Invalid demo");
		}
	}
}