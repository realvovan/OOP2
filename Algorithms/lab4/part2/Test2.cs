using System.Text.RegularExpressions;

namespace Algorithms.lab4;

static class Test2 {
	static int[] indexSort<T>(T[] array,Comparison<T> comp) {
		var index = new int[array.Length];
		for (int i = 0; i < array.Length; i++) {
			index[i] = i;
		}
		Array.Sort(index, (i,j) => comp(array[i],array[j]));
		return index;
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
		foreach (var student in students) {
			Console.WriteLine($"{student.FirstName,-12} {student.LastName,-10} {student.Id,-10} {student.Group}");
		}
		var sortedIndex = indexSort(students,(a,b) => {
			int groupComp = a.Group.CompareTo(b.Group);
			if (groupComp != 0) return groupComp;
			return a.Id.CompareTo(b.Id);
		});
		Console.WriteLine("\nStudents after sorting by group number then id:");
		Console.WriteLine($"{"First name",-12} {"Last name",-10} {"Id",-10} {"Group"}");
		foreach (int i in sortedIndex) {
			var student = students[i];
			Console.WriteLine($"{student.FirstName,-12} {student.LastName,-10} {student.Id,-10} {student.Group}");
		}
	}
}