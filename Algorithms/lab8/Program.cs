namespace Algorithms.lab8;

static class Program {
	static void Main(string[] args) {
		if (args.Length == 0) throw new ArgumentException("No demo number",nameof(args));
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
				throw new ArgumentOutOfRangeException(nameof(args),"Invalid demo");
		}
	}
}