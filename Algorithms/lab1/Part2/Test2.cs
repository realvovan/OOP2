namespace Algorithms.lab1;

static class Test2 {
	public static void Run() {
		var numbers = new DoubleLinkedList<string>(["10","20","30","40"]);

		Console.WriteLine($"List after init: {numbers}");
		numbers.AddFirst("0");
		numbers.AddLast("50");
		numbers.InsertAfter("15",numbers.GetNode(1));
		Console.WriteLine($"List after adding: {numbers}");
		numbers.RemoveFirst();
		numbers.RemoveLast();
		Console.WriteLine($"List after removing: {numbers}");
		numbers.Remove(numbers.GetNode(numbers.Count - 2));

		numbers.InsertAfter("-1",numbers.First!);
		numbers.InsertAfter("100",numbers.Last!);
		Console.WriteLine($"Final list: {numbers}");

	}
}