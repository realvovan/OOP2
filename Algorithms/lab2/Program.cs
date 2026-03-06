namespace Algorithms.lab2;

static class Program {
	static void Main(string[] args) {
		if (args.Length == 0) throw new Exception("No demo number");
		switch (args[0].ToLower()) {
			case "test1":
				Test1.Run();
				break;
			case "test2":
				Test2.Run();
				break;
			case "test3":
				Test3.Run();
				break;
			default:
				throw new Exception("Invalid demo");
		}
	}
}