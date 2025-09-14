using System.Text.RegularExpressions;

namespace Database.People;

public abstract class Person {
	private string firstName = "";
	private string lastName = "";

	public string FirstName {
		get => this.firstName;
		set {
			if (!Regex.IsMatch(value,"^[A-Za-z']+$")) throw new FormatException("Invalid name format");
			this.firstName = value;
		}
	}
	public string LastName {
		get => this.lastName;
		set {
			if (!Regex.IsMatch(value,"^[A-Za-z']+$")) throw new FormatException("Invalid name format");
			this.lastName = value;
		}
	}
	public int PassportNumber { get; init; }

	public Person(string first,string last,int passportNumber) {
		this.FirstName = first;
		this.LastName = last;
		this.PassportNumber = passportNumber;
	}

	public override string ToString() => $"{this.GetType().Name}: {this.firstName} {this.lastName}, passport {this.PassportNumber}";
}