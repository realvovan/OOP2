namespace lab3_4;

public delegate bool StringCheck(string str,char c);

static class Program {
	static void Main() {
		Console.WriteLine("==============\nPart 1\n==============");
		StringCheck anonymous = delegate (string str,char c) {
			foreach (var i in str) {
				if (c == i) return true;
			}
			return false;
		};
		bool anonResult = anonymous.Invoke("Hello world",'l');
		Console.WriteLine($"Anonymous function result: {anonResult}");
		StringCheck lambda = (str,c) => {
			foreach (var i in str) {
				if (c == i) return true;
			}
			return false;
		};
		bool lambdaResult = lambda.Invoke("Lorem ipsum",'z');
		Console.WriteLine($"Lambda function result: {lambdaResult}");
		Console.WriteLine("==============\nPart 1\n==============");
		var stringQueue = new MyQueue<string>("hello world this is my program".Split(' '));
		stringQueue.QueueCleared += onCleared;
		stringQueue.ElementAdded += onElementAdded;
		stringQueue.ElementRemoved += onElementRemoved;
		stringQueue.Enqueue("C#");
		Console.WriteLine($"Length after adding is {stringQueue.Length}");
		Console.WriteLine($"Peeking: {stringQueue.Peek()}");
		Console.WriteLine($"Popping: {stringQueue.Pop()}");
		Console.WriteLine($"Length after popping is {stringQueue.Length}");
		stringQueue.Pop();
		stringQueue.Pop();
		stringQueue.Pop();
		Console.WriteLine($"Popping: {stringQueue.Pop()}");
		stringQueue.Clear();
		Console.WriteLine($"Length after clearing is {stringQueue.Length}");
	}
	static void onCleared(object? sender,EventArgs e) {
		Console.WriteLine("Queue cleared");
	}
	static void onElementRemoved(object? sender, QueueChangedEventArgs<string> e) {
		Console.WriteLine($"Element '{e.Element}' removed");
	}
	static void onElementAdded(object? sender,QueueChangedEventArgs<string> e) {
		Console.WriteLine($"Element '{e.Element}' added");
	}
}