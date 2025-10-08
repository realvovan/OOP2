using System.Text.RegularExpressions;

namespace DataAccessLevel.Models;

public class Person {
	public string FirstName { get; init; } = string.Empty;
	public string LastName { get; init; } = string.Empty;
	public string UID { get; init; } = Guid.NewGuid().ToString();

	public Person() { }
	public Person(string firstName,string lastName) {
		this.FirstName = Regex.IsMatch(firstName,"^[A-Za-z']+$") ? firstName : throw new FormatException("Invalid first name");
		this.LastName = Regex.IsMatch(lastName,"^[A-Za-z']+$") ? lastName : throw new FormatException("Invalid last name");
		this.UID = Guid.NewGuid().ToString();
	}
	public override string ToString() => $"{this.FirstName} {this.LastName}: UID = {this.UID}";
}
