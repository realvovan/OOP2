namespace Algorithms.lab2;

static class Test2 {
	static Point2 getRandomPoint() => new Point2(Random.Shared.Next(10),Random.Shared.Next(10));
	static bool insertSquare(MyHashtable<float,Square> hashtable,Square element) => hashtable.Insert(element.GetPerimeter(),element);
	public static void Run() {
		var hashtable = new MyHashtable<float,Square>(buckets:3);

		insertSquare(hashtable,new Square(getRandomPoint(),4));
		insertSquare(hashtable,new Square(getRandomPoint(),5));
		insertSquare(hashtable,new Square(getRandomPoint(),6));
		Console.WriteLine($"Count: {hashtable.Count}");
		bool result = insertSquare(hashtable,new Square(getRandomPoint(),9));
		Console.WriteLine($"Result of inserting 9: {result}");
		result = insertSquare(hashtable,new Square(getRandomPoint(),4));
		Console.WriteLine($"Result of inserting 4: {result}");

		Console.WriteLine($"Count: {hashtable.Count}");

		Console.WriteLine(hashtable.GetFullContent());
		Console.WriteLine(new string('=',20));
		foreach (var kv in hashtable) {
			Console.WriteLine($"[{kv.Key}] = {kv.Value}");
		}

		Console.WriteLine($"Element with key '16': {hashtable.ElementAt(16f)}");
		Console.WriteLine($"Element with key '999': {hashtable.ElementAt(999f)}");

		Console.WriteLine("Testing a hashtable with Square key\n");
		var otherTable = new MyHashtable<Square,string>();
		var sqr1 = new Square(getRandomPoint(),3);
		var sqr2 = new Square(getRandomPoint(),6);
		otherTable.Insert(key:sqr1,value:"This is a square with side length 3");
		otherTable.Insert(key:sqr2,value:"This is a square with side length 6");
		Console.WriteLine(otherTable.GetFullContent());
		foreach(var kv in otherTable) {
			Console.WriteLine($"[{kv.Key}] = {kv.Value}");
		}
		Console.WriteLine($"Accessing an element with key 'sqr2': {otherTable.ElementAt(sqr2)}");
	}
}
