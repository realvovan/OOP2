namespace Algorithms.lab5;
static class Test1 {
	static Student[] getStudents(int count = 20) {
		var students = new Student[count];
		int mid = count / 2;
		for (int i = 0; i < count; i++) {
			int j = i + 1;
			students[i] = new($"First{j}",$"Last{j}",j,i > mid);
		}
		return students;
	}
	static int findFirstMilitary(Student[] students) {
		int left = 0;
		int right = students.Length - 1;
		int result = -1;
		
		while (left <= right) {
			int mid = (left + right) / 2;
			if (students[mid].HadMilitaryTraining) {
				result = mid;
				right = mid - 1;
			} else {
				left = mid + 1;
			}
		}
		return result;
	}
	public static void Run() {
		var students = getStudents();
		Console.WriteLine("Students:");
		foreach (var i in students) {
			Console.WriteLine(i);
		}
		Console.WriteLine(new string('=',20));
		int start = findFirstMilitary(students);
		if (start == -1) {
			Console.WriteLine("No students with military training");
			return;
		}
		int key = 29; // or anything else really im just lazy to read user input lol
		int index = InterpolationSearcher.Search(students,key,s => s.Id,start);
		if (index != -1) {
			Console.WriteLine("Found:");
			Console.WriteLine(students[index]);
		} else {
			Console.WriteLine("No student with given id found");
		}
	}
}
