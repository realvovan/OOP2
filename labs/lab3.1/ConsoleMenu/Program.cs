using System.Collections.Generic;
using Database.FileManager;
using Database.People;

namespace Database.ConsoleMenu;

static class ConsoleMenu {
	static void Main() {
		Person[] people = [];
		var db = new DatabaseManager(string.Empty);
		bool isRunning = true;
		string? userInput;
		//initial database set up
		while (db.FilePath == string.Empty) {
			Console.WriteLine(@"Welcome to the database manager user interface!
Select an action:
1. Enter file path to read/write to
2. Exit");
			userInput = Console.ReadLine();
			switch (userInput) {
				case "1":
					Console.Write("Enter file path: ");
					do {
						userInput = Console.ReadLine();
					} while (userInput == null);
					db.FilePath = userInput;
					break;
				case "2":
					isRunning = false;
					return;
				default:
					Console.WriteLine("Invalid input!");
					break;
			}
		}
		var choices = new Dictionary<string,Action>() {
			{ "1", () => {
				// Adding a person
				Console.WriteLine("What type of person would you like to add (Student/Fireman/Courier)");
				userInput = Console.ReadLine()?.ToLower();
				if (userInput == "student") {
					try {
						Console.WriteLine("Enter student's first name");
						string first = Console.ReadLine() ?? "";
						Console.WriteLine("Enter student's last name");
						string last = Console.ReadLine() ?? "";
						Console.WriteLine("Enter student's passport number");
						int passportNum = int.Parse(Console.ReadLine() ?? "0");
						Console.WriteLine("Enter student id number (XX12345678)");
						string studentId = Console.ReadLine() ?? "";
						Console.WriteLine("Enter the year/grade");
						int year = int.Parse(Console.ReadLine() ?? "1");
						Console.WriteLine("Is sports their hobby (Y/N)");
						bool isSportsAHobby = Console.ReadLine()?.ToLower() == "y";
						people = [..people,new Student(first,last,passportNum,studentId,year,isSportsAHobby)];
					} catch (Exception e) {
						Console.WriteLine($"An error occured while adding a student: {e.Message}");
						return;
					}
				} else if (userInput == "fireman") {
					try {
						Console.WriteLine("Enter fireman's first name");
						string first = Console.ReadLine() ?? "";
						Console.WriteLine("Enter fireman's last name");
						string last = Console.ReadLine() ?? "";
						Console.WriteLine("Enter fireman's passport number");
						int passportNum = int.Parse(Console.ReadLine() ?? "0");
						Console.WriteLine("Enter the number of complete jobs");
						int jobsDone = int.Parse(Console.ReadLine() ?? "0");
						people = [..people,new Fireman(first,last,passportNum,jobsDone)];
					} catch (Exception e) {
						Console.WriteLine($"An error occured while adding a student: {e.Message}");
						return;
					}
				} else if (userInput == "courier") {
					try {
						Console.WriteLine("Enter courier's first name");
						string first = Console.ReadLine() ?? "";
						Console.WriteLine("Enter courier's last name");
						string last = Console.ReadLine() ?? "";
						Console.WriteLine("Enter courier's passport number");
						int passportNum = int.Parse(Console.ReadLine() ?? "0");
						Console.WriteLine("Enter the number of complete orders");
						int jobsDone = int.Parse(Console.ReadLine() ?? "0");
						people = [..people,new Courier(first,last,passportNum,jobsDone)];
					} catch (Exception e) {
						Console.WriteLine($"An error occured while adding a student: {e.Message}");
						return;
					}
				} else {
					Console.WriteLine("Invalid input!");
					return;
				}
				Console.WriteLine($"Successfully added {people[people.Length - 1]}");
			} },
			{ "2", () => {
				// Removing a person
				if (people.Length == 0) {
					Console.WriteLine("List of people is empty!");
					return;
				}
				Console.WriteLine("Which person would you like to remove from the list?");
				for (int i = 0; i < people.Length; i++) {
					Console.WriteLine($"{i + 1}. {people[i]}");
				}
				if (int.TryParse(Console.ReadLine() ?? "0",out int toRemove) && toRemove <= people.Length) {
					people = people.Where((_,index) => index != toRemove - 1).ToArray();
					Console.WriteLine("Successfully removed a person");
				} else {
					Console.WriteLine("Invalid index!");
				}
			} },
			{ "3", () => {
				if (people.Length == 0) {
					Console.WriteLine(
						"Are you sure you want to overwrite the file with an empty list? !This action will wipe the file! (Y/N)"
					);
					if (Console.ReadLine()?.ToLower() == "y") {
						db.SaveToFile(people);
						Console.WriteLine("Successfully cleared the file!");
					} else {
						Console.WriteLine("Action declined");
					}
				} else {
					Console.WriteLine($"Are you sure you want to overwrite the file with {people.Length} people (Y/N)");
					if (Console.ReadLine()?.ToLower() == "y") {
						db.SaveToFile(people);
						Console.WriteLine($"Successfully saved {people.Length} people");
					} else {
						Console.WriteLine("Action declined");
					}
				}
			} },
			{ "4", () => {
				if (people.Length == 0) {
					Console.WriteLine("List of people is empty!");
					return;
				}
				Console.WriteLine($"Are you sure you want to add {people.Length} people to the file (Y/N)");
				if (Console.ReadLine()?.ToLower() == "y") {
					db.AppendToFile(people);
					Console.WriteLine($"Successfully saved {people.Length} people");
				} else {
					Console.WriteLine("Action declined!");
				}
			} },
			{ "5", () => {
				people = db.LoadFromFile();
				Console.WriteLine($"Successfully loaded {people.Length} people");
			} },
			{ "6", () => {
				if (people.Length == 0) {
					Console.WriteLine("List of people is empty");
				} else {
					foreach (var i in people) Console.WriteLine(i.ToString());
				}
			} },
			{ "7", () => {
				if (people.Length == 0) {
					Console.WriteLine("List of people is empty");
					return;
				}
				Console.WriteLine("Would you like to search by\n1. Name\n2. Passport number");
				userInput = Console.ReadLine();
				if (userInput == "1") {
					Console.Write("Enter the first name: ");
					string? first = Console.ReadLine();
					Console.Write("Enter the last name: ");
					string? last = Console.ReadLine();
					if (string.IsNullOrEmpty(first) || string.IsNullOrEmpty(last)) {
						Console.WriteLine("Invalid input");
						return;
					}
					bool isFound = false;
					for (int i = 0; i < people.Length; i++) {
						var person = people[i];
						if (person.FirstName.ToLower() == first.ToLower() && person.LastName.ToLower() == last.ToLower()) {
							Console.WriteLine($"{person} is number {i+1} in the list");
							isFound = true;
						}
					}
					if (!isFound) Console.WriteLine($"Couldnt find anyone with the name {first} {last}");
				} else if (userInput == "2") {
					Console.Write("Enter the passport number: ");
					if (int.TryParse(Console.ReadLine(), out int passportNum)) {
						bool isFound = false;
						for (int i = 0; i < people.Length; i++) {
							var person = people[i];
							if (person.PassportNumber == passportNum) {
								Console.WriteLine($"{person} is number {i+1} in the list");
								isFound = true;
							}
						}
						if (!isFound) Console.WriteLine($"Couldnt find anyone with the passport number {passportNum}");
					} else {
						Console.WriteLine("Invalid input");
					}
				}
			} },
			{ "8", () => {
				Console.Write("Enter new file path: ");
				userInput = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(userInput)) {
					Console.WriteLine("Invalid input");
					return;
				}
				db.FilePath = userInput;
			} },
			{ "9", () => {
				Student[] match = [];
				foreach (var i in people) {
					if (i is Student student && student.Year == 2 && student.IsSportsAHobby) {
						match = [..match,student];
					}
				}
				Console.WriteLine($"Found {match.Length} students on year 2 that also do sports:");
				foreach (var i in match) {
					Console.WriteLine(i);
				}
			} },
			{ "10", () => {
				Person[] toAdd = [
					new Student("Vova","Hordiienko",12345678,"KB87654321",2,true),
					new Student("Dima","Lisovyy",22444466,"AK12344321",2,false),
					new Student("Lida","Petrenko",6533221,"BK42231200",1,true),
					new Fireman("Ivan","Pavlenko",6769420),
					new Fireman("Pavel","Melikabyan",5432134,4),
					new Courier("John","Doe",12342335,10)
				];
				people = [..people,..toAdd];
				Console.WriteLine("Successfully added 5 people to the list");
			} },
			{ "11", () => {
				isRunning = false;
			} }
		};
		while (isRunning) {
			Console.WriteLine(@"Select an action:
1. Add a person
2. Remove a person
3. Save people to the file (!overwrites the file!)
4. Append people to the file
5. Load people from the file
6. View loaded people
7. Search
8. Change file path
9. Calculate the number of year 2 students that do sports
10. Add predefined people (as an example)
11. Exit");
			userInput = Console.ReadLine() ?? "";
			if (choices.TryGetValue(userInput,out var action)) action();
			else Console.WriteLine("Invalid input!");

			Console.WriteLine("Press any key to continue. . .");
			Console.ReadLine();
		}
	}
}