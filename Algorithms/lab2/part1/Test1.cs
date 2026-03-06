namespace Algorithms.lab2;

static class Test1 {
	static Point2 getRandomPoint() => new Point2(Random.Shared.Next(10),Random.Shared.Next(10));
	public static void Run() {
		var hashTable = new SimpleSquareHashTable(size:6);

		hashTable.Insert(new Square(getRandomPoint(),4));
		hashTable.Insert(new Square(getRandomPoint(),5));
		hashTable.Insert(new Square(getRandomPoint(),7));
		hashTable.Insert(new Square(getRandomPoint(),9));
		hashTable.Insert(new Square(getRandomPoint(),2));
		bool result = hashTable.Insert(new Square(getRandomPoint(),3));
		Console.WriteLine($"Result of inserting the last square: {result}");
		Console.WriteLine(hashTable.GetFullContent());

		result = hashTable.Insert(new Square(getRandomPoint(),4));
		Console.WriteLine($"Result of inserting the last square: {result}");

		Console.WriteLine($"Obtaining an element with key '12' -> {hashTable.GetSquare(12f)}");
		Console.WriteLine($"Obtaining an element with key '999' -> {hashTable.GetSquare(999f)}");

		foreach (var kv in hashTable) {
			Console.WriteLine($"[{kv.Key}] = {kv.Value}");
		}
	}
}