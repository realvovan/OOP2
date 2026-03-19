namespace Algorithms.lab4;
static class QuickSorter {
	public static T[] Sort<T>(T[] array,Comparison<T> comp) {
		T[] result = array.ToArray();
		recursiveSort(result,comp,0,result.Length - 1);
		return result;
	}
	private static int medianOfThree<T>(T[] array,Comparison<T> comp,int left,int right) {
		int mid = (left + right) / 2;
		T a = array[left];
		T b = array[mid];
		T c = array[right];

		if ((comp(a,b) > 0) != (comp(a,c) > 0)) return left;
		else if ((comp(b,a) > 0) != (comp(b,c) > 0)) return mid;
		else return right;
	}
	private static void recursiveSort<T>(T[] array,Comparison<T> comp,int left,int right) {
		if (left >= right) return;

		int pivotIndex = medianOfThree(array,comp,left,right);
		T pivot = array[pivotIndex];
		(array[pivotIndex],array[right]) = (array[right],array[pivotIndex]);
		int i = left;
		for (int j = left; j < right; j++) {
			if (comp(array[j],pivot) < 0) {
				(array[i],array[j]) = (array[j],array[i]);
				i++;
			}
		}
		(array[i],array[right]) = (array[right],array[i]);

		recursiveSort(array,comp,left,i - 1);
		recursiveSort(array,comp,i + 1,right);
	}
}
static class Test3 {
	static void printStudents(Student[] students) {
		Console.WriteLine($"{"First name",-12} {"Last name",-10} {"Id",-10} {"Group"}");
		foreach (var i in students) {
			Console.WriteLine($"{i.FirstName,-12} {i.LastName,-10} {i.Id,-10} {i.Group}");
		}
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
		var sorted = QuickSorter.Sort(unsorted,(a,b) => a.Group.CompareTo(b.Group));
		printStudents(sorted);
	}
}