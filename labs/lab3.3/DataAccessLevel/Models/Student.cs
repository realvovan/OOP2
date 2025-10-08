using System.Text.RegularExpressions;

namespace DataAccessLevel.Models;

public class Student : Person {
	public string StudentId { get; init; } = string.Empty;
	public int Year { get; set; } = 1;
	public int IdentificationCode { get; init; } = 0;
	public bool IsSportsAHobby { get; set; } = false;

	public Student() { }

	public Student(string firstName,string lastName,string studentId,int year,int idCode,bool isSportsAHobby) : base(firstName,lastName) {
		this.StudentId = Regex.IsMatch(studentId,"^[A-Z]{2}\\d{8}$") ? studentId : throw new FormatException("Invalid student id");
		this.Year = year;
		this.IdentificationCode = idCode;
		this.IsSportsAHobby = isSportsAHobby;
	}
	public void Study() => this.Year++;
}
