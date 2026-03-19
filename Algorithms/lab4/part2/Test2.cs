using System.Text.RegularExpressions;

namespace Algorithms.lab4;

static class Test2 {
	static T[] insertionSort<T>(T[] array,Comparison<T> comp) {
		T[] sorted = array.ToArray();
		for (int i = 1; i < sorted.Length; i++) {
			T val = sorted[i];
			int j = i - 1;
			while (j >= 0 && comp(sorted[j],val) > 0) {
				sorted[j + 1] = sorted[j];
				j--;
			}
			sorted[j + 1] = val;
		}
		return sorted;
	}
	static void printStudents(Student[] students) {
		Console.WriteLine($"{"First name",-12} {"Last name",-10} {"Id",-10} {"Group"}");
		foreach (var i in students) {
			Console.WriteLine($"{i.FirstName,-12} {i.LastName,-10} {i.Id,-10} {i.Group}");
		}
	}
	public static void Run() {
		var students = new Student[] {
			new Student("First3","Lats3",20,2),
			new Student("First1","Last1",10,1),
			new Student("First5","Lats5",30,3),
			new Student("First2","Lats2",15,1),
			new Student("First4","Lats4",25,2)
		};
		Console.WriteLine("Original array:");
		printStudents(students);
		var sorted = insertionSort(students,(a,b) => {
			int groupComp = a.Group.CompareTo(b.Group);
			if (groupComp != 0) return groupComp;
			return a.Id.CompareTo(b.Id);
		});
		Console.WriteLine("\nStudents after sorting by group number then id:");
		printStudents(sorted);
	}
}