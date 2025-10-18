using Newtonsoft.Json;

namespace lab3_5.DataAccessLevel.Models;
public abstract class Person(string first,string last,int passportId) {
	public string FirstName { get; set; } = first;
	public string LastName { get; set; } = last;
	public int PassportId { get; set; } = passportId;
	[JsonConstructor]
	public Person() : this("NA","NA",-1) { }
	public override string ToString() => $"{this.FirstName} {this.LastName} | Passport number: {this.PassportId}";
}