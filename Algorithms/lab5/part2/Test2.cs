namespace Algorithms.lab5;

static class Test2 {
	static Student[] getStudents(int count) {
		var students = new Student[count];
		for (int i = 0; i < count; i++) {
			int j = i + 1;
			students[i] = new Student(
				$"First{j}",
				$"Last{j}",
				j+10,
				false
			);
		}
		Random.Shared.Shuffle(students);
		return students;
	}
	static void printTree<T,TKey>(BinaryTree<T,TKey>.Node? node,Func<T,TKey> keySelector,int indent = 0) where TKey : IComparable<TKey> {
		if (node is null) return;
		printTree(node.Right,keySelector,indent + 4);
		Console.WriteLine(new string(' ',indent) + keySelector(node.Value));
		printTree(node.Left,keySelector,indent + 4);

	}
	public static void Run() {
		var studentList = getStudents(6);
		var tree = new BinaryTree<Student,string>(s => s.FirstName);
		foreach (var i in studentList) {
			Console.WriteLine(i);
			tree.Insert(i);
		}
		Console.WriteLine(new string('=',20));
		Console.WriteLine("Tree:");
		printTree(tree.Root,s => s.FirstName);

		Console.WriteLine(new string('=',20));
		var found = tree.Search("First2");
		if (found is not null) {
			Console.WriteLine("found:");
			Console.WriteLine(found.Value);
		} else {
			Console.WriteLine("Coukdnt find student with this key");
		}

		tree.RotateLeft(tree.Root!);
		Console.WriteLine("Tree after rotating left about Root node");
		printTree(tree.Root,s => s.FirstName);
	}
}