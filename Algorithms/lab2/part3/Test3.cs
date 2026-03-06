namespace Algorithms.lab2;

static class Test3 {
	static Point2 getRandomPoint() => new Point2(Random.Shared.Next(10),Random.Shared.Next(10));
	public static void Run() {
		const float MIN_AREA = 10f;
		var hashtable = new MyHashTable(3);

		for (int i = 1; i <= 5; i++) hashtable.Insert(new Square(getRandomPoint(),i));
		Console.WriteLine($"Hashtable with count [{hashtable.Count}]: {hashtable.GetFullContent()}");

		hashtable.RemoveWhere(s => s.GetArea() < MIN_AREA);
		Console.WriteLine($"Hashtable with count [{hashtable.Count}]: {hashtable.GetFullContent()}");
	}
}