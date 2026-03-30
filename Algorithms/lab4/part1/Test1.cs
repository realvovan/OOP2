namespace Algorithms.lab4;

static class Test1 {
	static void printStudents(Student[] students) {
		Console.WriteLine($"{"First name",-12} {"Last name",-10} {"Id",-10} {"Group"}");
		foreach (var i in students) {
			Console.WriteLine($"{i.FirstName,-12} {i.LastName,-10} {i.Id,-10} {i.Group}");
		}
	}
	static T[] bubbleSort<T>(T[] list,Comparison<T> comp) {
		T[] sorted = list.ToArray();
		int len = sorted.Length;
		for (int i = 0; i < len - 1; i++) {
			bool swapped = false;
			for (int j = 0; j < len - i - 1; j++) {
				if (comp(sorted[j],sorted[j + 1]) > 0) {
					(sorted[j + 1],sorted[j]) = (sorted[j],sorted[j + 1]);
					swapped = true;
				}
			}
			if (!swapped) break;
		}
		return sorted;
	}
	public static void Run() {
		var unsorted = new Student[] {
			new("First7","Last7",432,4),
			new("First1","Last1",123,1),
			new("First6","Last6",4324,4),
			new("First3","Last3",213,2),
			new("First2","Last2",4132,1),
			new("First5","Last5",3213,4),
			new("First4","Last4",3214,3),
		};
		Console.WriteLine("Unsorted array:");
		printStudents(unsorted);
		Console.WriteLine("\nSorting the array by group number in ascending order:");
		var sorted = bubbleSort(unsorted,(a,b) => {
			int result = a.Group.CompareTo(b.Group);
			if (result == 0) {
				return a.FirstName.CompareTo(b.FirstName);
			}
			return result;
		});
		printStudents(sorted);
	}
}