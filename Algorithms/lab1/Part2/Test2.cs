namespace Algorithms.lab1;

static class Test2 {
	public static void Run() {
		var numbers = new DoubleLinkedList<string>(["10","20","30","40"]);
		
		Console.WriteLine($"List after init: {numbers}");
		numbers.AddFirst("0");
		numbers.AddLast("50");
		numbers.Insert("15",2);
		Console.WriteLine($"List after adding: {numbers}");
		numbers.RemoveFirst();
		numbers.RemoveLast();
		numbers.Remove(numbers.Count - 2);
		Console.WriteLine($"List after removing: {numbers}");
	}
}