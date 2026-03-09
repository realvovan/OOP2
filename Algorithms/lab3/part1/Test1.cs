namespace Algorithms.lab3;

static class Test1 {
	static void printList(BinaryTree<Student> studentList) {
		Console.WriteLine($"{"First name",-12} {"Last name",-12} {"Student id",-12} {"Hobby",-12} {"Year",11}");
		foreach (var node in studentList) {
			Console.WriteLine(node.Value);
		}
	}

	public static void Run() {
		Predicate<Student> predicate = s => s.Year == 2 && s.Hobby == Hobbies.Sports;

		Console.WriteLine(new string('=',20));
		Console.WriteLine("PART1");
		var tree = new BinaryTree<Student>();
		tree.Insert(new Student("First3","Last3","RT3",Hobbies.Chess,2));
		tree.Insert(new Student("First1","Last1","AB1",Hobbies.None,1));
		tree.Insert(new Student("First5","Last5","KH5",Hobbies.None,3));
		tree.Insert(new Student("First6","Last6","BV6",Hobbies.None,5));
		tree.Insert(new Student("First2","Last2","KX2",Hobbies.Sports,1));
		tree.Insert(new Student("First4","Last4","GF4",Hobbies.Gaming,3));
		tree.Insert(new Student("First7","Last7","GF7",Hobbies.Sports,2));
		tree.Insert(new Student("First8","Last8","GF8",Hobbies.Sports,2));
		printList(tree);
		Console.WriteLine(new string('=',20));
		Console.WriteLine("PART2");
		Console.WriteLine(new string('=',20));
		Console.WriteLine("Year 2 student who do sports:");
		foreach (var i in tree.Where(predicate)) {
			Console.WriteLine(i.Value);
		}
		Console.WriteLine(new string('=',20));
		Console.WriteLine("PART3");
		Console.WriteLine(new string('=',20));
		Console.WriteLine("Deleting year 2 student who do sports:");
		tree.RemoveAllWhere(predicate);
		printList(tree);
	}
}