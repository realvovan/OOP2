namespace Algorithms.lab3;

enum Hobbies {
	None,
	Sports,
	Chess,
	Gaming
}

class Student : IComparable<Student> {
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string StudentId { get; set; }
	public Hobbies Hobby { get; set; }
	public byte Year { get; private set; }

	public void SetYear(byte year) {
		if (year < 1 || year > 6) throw new ArgumentOutOfRangeException(nameof(year));
		this.Year = year;
	}
	public int CompareTo(Student other) {
		if (other is null) return -1;
		return this.Year.CompareTo(other.Year);
	}
	public override string ToString() {
		return $"{this.FirstName,-12} {this.LastName,-12} {this.StudentId,-12} Hobby: {this.Hobby,-12} {this.Year,-6}";
	}

	public Student(string first,string last,string studentId,Hobbies hobby,byte year = 1) {
		this.FirstName = first;
		this.LastName = last;
		this.StudentId = studentId;
		this.Hobby = hobby;
		this.SetYear(year);
	}
}