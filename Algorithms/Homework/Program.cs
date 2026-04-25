namespace Algorithms.Homework;

static class Program {
	static void Main(string[] args) {
		if (args.Length == 0) throw new Exception("No demo number");
		switch (args[0].ToLower()) {
			case "test1":
				LupSolver.Run();
				break;
			case "test2":
				RungeKutta4thOrder.Run();
				break;
			default:
				throw new Exception("Invalid demo");
		}
	}
}
