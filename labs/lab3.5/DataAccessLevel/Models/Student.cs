using Newtonsoft.Json;

namespace lab3_5.DataAccessLevel.Models;

public class Student(string first,string last,int passportId,string studentId,bool isSportsAHobby,float sportsMetric,int year)
: Person(first,last,passportId) {
	public string StudentId { get; } = studentId;
	public bool IsSportsAHobby { get; set; } = isSportsAHobby;
	public float SportsMetric { get; set; } = sportsMetric;
	public int Year { get; set; } = year;
	[JsonConstructor]
	public Student() : this("NA","NA",-1,"NA",false,-1f,-1) { }
	public void IncreaseYear() {
		if (this.Year > 5) throw new InvalidOperationException("Student is on the last year");
		this.Year++;
	}
}
