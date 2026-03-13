namespace Algorithms.lab2;

static class Test3 {
	static Point2 getRandomPoint() => new Point2(Random.Shared.Next(10),Random.Shared.Next(10));
	static bool insertSquare(MyHashtable<float,Square> hashtable,Square element) => hashtable.Insert(element.GetPerimeter(),element);
	public static void Run() {
		const float MIN_AREA = 10f;
		var hashtable = new MyHashtable<float,Square>(3);

		for (int i = 1; i <= 5; i++) insertSquare(hashtable,new Square(getRandomPoint(),i));
		Console.WriteLine($"Hashtable with count [{hashtable.Count}]: {hashtable.GetFullContent()}");

		hashtable.RemoveWhere(kv => kv.Value.GetArea() < MIN_AREA);
		Console.WriteLine($"Hashtable with count [{hashtable.Count}]: {hashtable.GetFullContent()}");
	}
}