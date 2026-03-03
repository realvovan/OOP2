namespace Algorithms.lab1;

static class Test1 {
	static void safeCall(Action action) {
		try {
			action();
		} catch (Exception e) {
			Console.WriteLine(e.Message);
		}
	}
	public static void Run() {
		var cars = new MyList<string>(["bmw","mazda","mercedes"]);
		Console.WriteLine($"List after initializing: {cars}");
		cars[1] = "renault";
		Console.WriteLine($"List after changing the second: {cars}");
		Console.WriteLine($"List contains mercedes: {cars.Contains("mercedes")}");
		Console.WriteLine($"List contains fiat: {cars.Contains("fiat")}");
		cars.Add("ford");
		cars.Add("chevy");
		Console.WriteLine($"List after appending two cars: {cars}");
		cars.Insert("honda",2);
		Console.WriteLine($"List after inserting 'honda' at index 2: {cars}");
		cars.Remove(1);
		Console.WriteLine($"List after removing element at index 1: {cars}");
		Console.WriteLine("Testing exceptions");
		safeCall(() => cars.Insert("test",999));
		safeCall(() => cars[-1] = "test");
		safeCall(() => cars.Remove(999));
		cars.Clear();
		Console.WriteLine($"List after clearing: {cars}");
	}
}
