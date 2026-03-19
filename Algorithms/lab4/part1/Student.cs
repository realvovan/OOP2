namespace Algorithms.lab4;

class Student(string first,string last,uint id,uint groupNumber) {
	public string FirstName { get; set; } = first;
	public string LastName { get; set; } = last;
	public uint Id { get; set; } = id;
	public uint Group { get; set; } = groupNumber;
}