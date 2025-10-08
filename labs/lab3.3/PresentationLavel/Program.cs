using BusinessLogicLevel;
using BusinessLogicLevel.DTOs;

namespace PresentationLevel;

public class Menu {
	private EntityService? entityService;
	public bool IsOpen { get; private set; } = false;
	public void InitMenu() {
		this.IsOpen = true;
		Console.WriteLine(@"Welcome! Please select an action:
1. Start
2. Exit");
		while (this.IsOpen) {
			string? input = Console.ReadLine();
			if (input == "1") {
				Console.WriteLine(@"Select a serializer type, or enter a valid DataProvider type name:
1. Json
2. Xml
3. Binary
4. Custom serializer");
				input = Console.ReadLine();
				if (input == "1") this.entityService = new EntityService(DataProviders.JsonProvider,"");
				else if (input == "2") this.entityService = new EntityService(DataProviders.XmlProvider,"");
				else if (input == "3") this.entityService = new EntityService(DataProviders.BinaryProvider,"");
				else if (input == "4") this.entityService = new EntityService(DataProviders.CustomProvider,"");
				else {
					try {
						this.entityService = new EntityService(input ?? "","");
					} catch {
						Console.WriteLine("Invalid input!");
						continue;
					}
				}
				Console.Write("Enter the full file path: ");
				while (true) {
					input = Console.ReadLine();
					if (!string.IsNullOrWhiteSpace(input)) break;
					Console.WriteLine("Invalid input!");
				}
				this.entityService.FilePath = input;
				break;
			} else if (input == "2") {
				this.IsOpen = false;
			} else {
				Console.WriteLine("Invalid input!");
			}
		}
	}
	public void MainMenu() {
		this.IsOpen = true;
		if (this.entityService == null) this.InitMenu();
		while (this.IsOpen) {
			Console.WriteLine(@"========================
Main menu:
1. Add a person
2. Remove a person
3. View all people
4. View all info about a person
5. Save people to file
6. Load people from file
7. Clear the list of people
8. Edit DataProvider
9. Count the number of year 2 students who do sports
10. Exit");
			string? input = Console.ReadLine();
			if (input == "1") addPerson();
			else if (input == "2") removePerson();
			else if (input == "3") viewAll();
			else if (input == "4") viewFullInfoAboutPerson();
			else if (input == "5") saveToFile();
			else if (input == "6") loadFromFile();
			else if (input == "7") clearList();
			else if (input == "8") editProvider();
			else if (input == "9") numberOfYear2StudentsWhoDoSports();
			else if (input == "10") exit();
			else Console.WriteLine("Invalid input!");
		}
	}

	private void addPerson() {
		Console.Write("Enter person type (student/fireman/courier): ");
		string? input = Console.ReadLine()?.ToLower();
		if (input == "student") {
			try {
				Console.WriteLine("Enter student's first name");
				string first = Console.ReadLine() ?? "";
				Console.WriteLine("Enter student's last name");
				string last = Console.ReadLine() ?? "";
				Console.WriteLine("Enter an identification code");
				int idCode = int.Parse(Console.ReadLine() ?? "0");
				Console.WriteLine("Enter student id number (XX12345678)");
				string studentId = Console.ReadLine() ?? "";
				Console.WriteLine("Enter the year/grade");
				int year = int.Parse(Console.ReadLine() ?? "1");
				Console.WriteLine("Is sports their hobby (Y/N)");
				bool isSportsAHobby = Console.ReadLine()?.ToLower() == "y";
				this.entityService!.Add(new StudentDTO() {
					FirstName = first,
					LastName = last,
					IdentificationCode = idCode,
					StudentId = studentId,
					Year = year,
					IsSportsAHobby = isSportsAHobby
				}.ToEntity());
			} catch (Exception e) {
				Console.WriteLine($"An error occured while adding a student: {e.Message}");
				return;
			}
			Console.WriteLine("Successfully added a student");
		} else if (input == "fireman") {
			try {
				Console.WriteLine("Enter fireman's first name");
				string first = Console.ReadLine() ?? "";
				Console.WriteLine("Enter fireman's last name");
				string last = Console.ReadLine() ?? "";
				Console.WriteLine("Enter the number of complete jobs");
				int jobsDone = int.Parse(Console.ReadLine() ?? "0");
				this.entityService!.Add(new FiremanDTO() {
					FirstName = first,
					LastName = last,
					JobsDone = jobsDone
				}.ToEntity());
			} catch (Exception e) {
				Console.WriteLine($"An error occured while adding a fireman: {e.Message}");
				return;
			}
			Console.WriteLine("Successfully added a fireman");
		} else if (input == "courier") {
			try {
				Console.WriteLine("Enter courier's first name");
				string first = Console.ReadLine() ?? "";
				Console.WriteLine("Enter courier's last name");
				string last = Console.ReadLine() ?? "";
				Console.WriteLine("Enter the number of complete orders");
				int jobsDone = int.Parse(Console.ReadLine() ?? "0");
				this.entityService!.Add(new CourierDTO() {
					FirstName = first,
					LastName = last,
					OrdersDelivered = jobsDone
				}.ToEntity());
			} catch (Exception e) {
				Console.WriteLine($"An error occured while adding a courier: {e.Message}");
				return;
			}
			Console.WriteLine("Successfully added a courier");
		} else Console.WriteLine("Invalid input");
	}
	private void removePerson() {
		if (this.entityService!.PersonCount == 0) {
			Console.WriteLine("No people to remove!");
			return;
		}
		Console.WriteLine("Choose which person you'd like to remove:");
		Console.WriteLine(this.entityService.GetAllPeopleInfo());
		if (int.TryParse(Console.ReadLine(),out int i) && --i > -1 && i < this.entityService.PersonCount) {
			this.entityService.Remove(i);
			Console.WriteLine("Person removed successfully!");
		} else {
			Console.WriteLine("Invalid input");
		}
	}
	private void viewAll() {
		if (this.entityService!.PersonCount == 0) Console.WriteLine("No people!");
		else Console.WriteLine(this.entityService.GetAllPeopleInfo());
	}
	private void viewFullInfoAboutPerson() {
		if (this.entityService!.PersonCount == 0) {
			Console.WriteLine("No people!");
			return;
		}
		Console.WriteLine("Choose which person you'd like to get info on:");
		Console.WriteLine(this.entityService.GetAllPeopleInfo());
		if (int.TryParse(Console.ReadLine(),out int i)) {
			var p = this.entityService.SearchByIndex(--i);
			if (p != null) {
				Console.WriteLine(this.entityService.GetPersonFullInfo(p));
			} else {
				Console.WriteLine("Index out of range");
			}
		} else {
			Console.WriteLine("Invalid input");
		}
	}
	private void saveToFile() {
		string? input;
		if (this.entityService!.PersonCount == 0) {
			Console.WriteLine("List is empty, this action will !CLEAR! the file! Are you sure you want to do that? (y/n)");
			input = Console.ReadLine()?.ToLower();
			if (input == "y" || input == "yes") {
				var result = this.entityService.SaveToFile();
				if (result.IsSuccess) Console.WriteLine("File successfully cleared!");
				else Console.WriteLine($"Error while clearing the file: {result.Message}");
			} else {
				Console.WriteLine("Action aborted!");
			}
			return;
		}
		Console.WriteLine($"Do you want to overwrite the file with {this.entityService.PersonCount} person(s)? (y/n)");
		input = Console.ReadLine()?.ToLower();
		if (input == "y" || input == "yes") {
			var result = this.entityService.SaveToFile();
			if (result.IsSuccess) Console.WriteLine("File successfully overwritten");
			else Console.WriteLine($"Error while overwriting the file: {result.Message}");
		} else {
			Console.WriteLine("Action aborted");
		}
	}
	private void loadFromFile() {
		var result = this.entityService!.LoadFromFile();
		if (result.IsSuccess) Console.WriteLine($"Successfully loaded {this.entityService.PersonCount} person(s)");
		else Console.WriteLine($"Error while loading from file: {result.Message}");
	}
	private void clearList() {
		Console.WriteLine("Are you sure you want to clear the list? (y/n)");
		string? input = Console.ReadLine()?.ToLower();
		if (input == "y" || input == "yes") {
			this.entityService!.Clear();
			Console.WriteLine("List cleared successfully!");
		} else {
			Console.WriteLine("Action aborted!");
		}
	}
	private void editProvider() {
		Console.WriteLine("Would you like to change provider's type or file path? (type/path)");
		string? input = Console.ReadLine()?.ToLower();
		if (input == "type") {
			Console.WriteLine(@"Select a serializer type, or enter a valid DataProvider type name:
1. Json
2. Xml
3. Binary
4. Custom serializer");
			input = Console.ReadLine();
			if (input == "1") this.entityService!.ChangeProviderType(DataProviders.JsonProvider);
			else if (input == "2") this.entityService!.ChangeProviderType(DataProviders.XmlProvider);
			else if (input == "3") this.entityService!.ChangeProviderType(DataProviders.BinaryProvider);
			else if (input == "4") this.entityService!.ChangeProviderType(DataProviders.CustomProvider);
			else {
				try {
					this.entityService!.ChangeProviderType(input ?? "");
					Console.WriteLine("Successfully changed type");
					return;
				} catch {
					Console.WriteLine("Invalid input");
				}
			}
			Console.WriteLine("Successfully changed type");
		} else if (input == "path") {
			Console.Write("Enter full file path: ");
			while (true) {
				input = Console.ReadLine();
				if (!string.IsNullOrWhiteSpace(input)) {
					this.entityService!.FilePath = input;
					Console.WriteLine("Successfully changed path");
					break;
				}
				Console.WriteLine("Invalid input! Try again!");
			}
		} else {
			Console.WriteLine("Invalid input");
		}
	}
	private void numberOfYear2StudentsWhoDoSports() => Console.WriteLine(this.entityService!.GetYear2StudentsWhoDoSports());
	private void exit() => this.IsOpen = false;
}
static class Program {
	static void Main() {
		new Menu().MainMenu();
	}
}