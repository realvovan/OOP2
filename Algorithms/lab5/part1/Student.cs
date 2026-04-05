namespace Algorithms.lab5;

class Student(string firstName,string lastName,int id,bool militaryTraining) : IComparable<Student> {
	public string FirstName { get; set; } = firstName;
	public string LastName { get; set; } = lastName;
	public int Id { get; set; } = id;
	public bool HadMilitaryTraining { get; set; } = militaryTraining;

	public int CompareTo(Student? other) {
		if (other is null) return -1;
		return this.Id.CompareTo(other.Id);
	}
	public override string ToString() => $"{this.FirstName,-8} {this.LastName,-8} {this.Id,-3} {this.HadMilitaryTraining}";
}