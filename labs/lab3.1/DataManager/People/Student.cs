using System.Text.RegularExpressions;

namespace Database.People;

public class Student : Person {
	public int Year { get; set; }
	public string StudentId { get; init; }
	public bool IsSportsAHobby { get; set; }

	public Student(string first,string last,int passportNumber,string studentId,bool isSportsAHobby) : base(first,last,passportNumber) {
		this.IsSportsAHobby = isSportsAHobby;
		this.StudentId =
			Regex.IsMatch(studentId,"^[A-Z]{2}[0-9]{8}$")
			? studentId
			: throw new FormatException("Invalid student id");
	}
	public void Study() => this.Year++;
}