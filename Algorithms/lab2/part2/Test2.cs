namespace Algorithms.lab2;

static class Test2 {
	static Point2 getRandomPoint() => new Point2(Random.Shared.Next(10),Random.Shared.Next(10));
	public static void Run() {
		var hashtable = new MyHashTable(buckets:3);

		hashtable.Insert(new Square(getRandomPoint(),4));
		hashtable.Insert(new Square(getRandomPoint(),5));
		hashtable.Insert(new Square(getRandomPoint(),3));
		Console.WriteLine($"Count: {hashtable.Count}");
		bool result = hashtable.Insert(new Square(getRandomPoint(),9));
		Console.WriteLine($"Result of inserting 9: {result}");
		result = hashtable.Insert(new Square(getRandomPoint(),4));
		Console.WriteLine($"Result of inserting 4: {result}");

		Console.WriteLine($"Count: {hashtable.Count}");

		Console.WriteLine(hashtable.GetFullContent());
		Console.WriteLine(new string('=',20));
		foreach (var kv in hashtable) {
			Console.WriteLine($"[{kv.Key}] = {kv.Value}");
		}

		Console.WriteLine($"Element with key '12': {hashtable.GetSquare(12)}");
		Console.WriteLine($"Element with key '999': {hashtable.GetSquare(999)}");
	}
}
