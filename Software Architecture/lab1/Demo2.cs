using System.Runtime.CompilerServices;
using System.Text;

namespace SoftwareArch.lab1;

static class Demo2 {
	enum menuModes {
		MainMenu,
		HabitatMenu,
		AnimalMode,
		AnimalSelectionMode,
		None
	}

	static readonly Person person = new("Person");
	static readonly AnimalStore store = new("PetShop");
	static readonly Wilderness wild = new();
	static menuModes menuMode = menuModes.MainMenu;

	static Habitat? selectedHabitat = null;
	static Animal? selectedAnimal = null;

	static void onAnimalStateChange(object? sender,AnimalStateChangeArgs args) {
		var animal = (Animal)sender!;
		if (args.ChangedState == AnimalStates.Dying && animal.Habitat is not null) {
			Console.WriteLine($"{animal.Name} died in {animal.Habitat.Name}");
		}
	}

	static void mainMenu() {
		string prompt = @"Welcome to the program!
Please select action:
1. Animal habitat options
2. Animal controls options
3. Exit";
		string input = getValidInput(prompt,["1","2","3"]);
		if (input == "1") {
			prompt = @"Please select the habitat
1. Person
2. Pet shop
3. Wilderness";
			input = getValidInput(prompt,["1","2","3"]);
			if (input == "1") {
				selectedHabitat = person;
			} else if (input == "2") {
				selectedHabitat = store;
			} else if (input == "3") {
				selectedHabitat = wild;
			}
			menuMode = menuModes.HabitatMenu;
		} else if (input == "2") {
			menuMode = menuModes.AnimalSelectionMode;
		} else if (input == "3") {
			menuMode = menuModes.None;
		}
	}
	static void habitatMenu() {
		if (selectedHabitat is null) {
			Console.WriteLine("Oops something went wrong! Going back to the main menu");
			menuMode = menuModes.MainMenu;
			return;
		}
		string prompt = @$"Selected habitat {selectedHabitat.Name}
Please select habitat action
1. Create new animal in the habitat
2. Feed all animals
3. Clean all animals
4. Manage specific animal
5. List all animals
6. Advance day
7. Main menu";
		string input = getValidInput(prompt,["1","2","3","4","5","6","7"]);
		if (input == "1") {
			if (selectedHabitat.IsFull()) {
				Console.WriteLine("Selected habitat is full, please select anothe action");
				return;
			}
			promptUserAnimalCreate(selectedHabitat);
		} else if (input == "2") {
			selectedHabitat.FeedAll();
			Console.WriteLine("Fed all animals!");
		} else if (input == "3") {
			if (!selectedHabitat.HasCare) {
				Console.WriteLine("This habitat does not support cleaning");
				return;
			}
			selectedHabitat.CleanAll();
			Console.WriteLine("Cleaned after animals");
		} else if (input == "4") {
			if (selectedHabitat.AnimalCount == 0) {
				Console.WriteLine("No animals found, consider adding some and trying again!");
				return;
			}
			Console.WriteLine("Please select the animal:");
			for (int i = 0;i < selectedHabitat.AnimalCount;i++) {
				Console.WriteLine($"{i+1}. {selectedHabitat.GetAnimalAt(i)}");
			}
			input = getValidInput(string.Empty,s => int.TryParse(s,out int n) && n >= 1 && n <= selectedHabitat.AnimalCount);
			selectedAnimal = selectedHabitat.GetAnimalAt(int.Parse(input) - 1);
			selectedHabitat = null;
			menuMode = menuModes.AnimalMode;
		} else if (input == "5") {
			Console.WriteLine($"List of animals ({selectedHabitat.AnimalCount}/{selectedHabitat.MaxAnimals}):");
			for (int i = 0;i < selectedHabitat.AnimalCount;i++) {
				Console.WriteLine(selectedHabitat.GetAnimalAt(i)!.ToString());
			}
		} else if (input == "6") {
			Console.WriteLine("Advancing to next day");
			selectedHabitat.AdvanceDay();
		} else if (input == "7") {
			menuMode = menuModes.MainMenu;
		}
	}
	static void animalMenu() {
		if (selectedAnimal is null) {
			Console.WriteLine("Oops something went wrong! Going back to the main menu");
			menuMode = menuModes.MainMenu;
			return;
		}
		StringBuilder promptBuilder = new(@$"Please select action for animal {selectedAnimal.Name}
1. View full info
2. Clean after
3. Change habitat
4. Go to habitat options
5. Advance day
6. Remove from program
");
		int availableOptions = 6;
		int walkOpt=0, feedOpt=0, runOpt=0, flyOpt=0, exitOpt=0;
		if (selectedAnimal is IWalkable) {
			availableOptions++;
			walkOpt = availableOptions;
			promptBuilder.Append($"{availableOptions}. Walk\n");
		}
		if (selectedAnimal is IFeedable) {
			availableOptions++;
			feedOpt = availableOptions;
			promptBuilder.Append($"{availableOptions}. Feed\n");
		}
		if (selectedAnimal is IRunable) {
			availableOptions++;
			runOpt = availableOptions;
			promptBuilder.Append($"{availableOptions}. Run\n");
		}
		if (selectedAnimal is IFlyable) {
			availableOptions++;
			flyOpt = availableOptions;
			promptBuilder.Append($"{availableOptions}. Fly\n");
		}
		promptBuilder.Append($"{++availableOptions}. Main menu");
		exitOpt = availableOptions;
		string input = getValidInput(promptBuilder.ToString(),s => int.TryParse(s,out int n) && n >= 1 && n <= availableOptions);
		if (input == "1") {
			Console.WriteLine($"{selectedAnimal}|Habitat name: {selectedAnimal.Habitat?.Name}");
		} else if (input == "2") {
			selectedAnimal.Clean();
			Console.WriteLine($"Cleaned after {selectedAnimal.Name}");
		} else if (input == "3") {
			string prompt = @"Please select the new habitat
1. Person
2. Pet shop
3. Wilderness";
			input = getValidInput(prompt,["1","2","3"]);
			bool result = selectedAnimal.ChangeHabitat(input switch {
				"1" => person,
				"2" => store,
				"3" => wild,
				_ => throw new InvalidDataException("Invalid habitat option")
			});
			Console.WriteLine(
				result
				? "Successfully changed the habitat"
				: "Oops! We ran into an error trying to change the habitat"
			);
		} else if (input == "4") {
			selectedHabitat = selectedAnimal.Habitat;
			selectedAnimal = null;
			menuMode = menuModes.HabitatMenu;
		} else if (input == "5") {
			selectedAnimal.AdvanceDay();
			Console.WriteLine("Day advanced!");
		} else if (input == "6") {
			Console.WriteLine("Are you sure you want to remove this animal? This action cannnot be undone! (y/n)");
			string? confirmation = Console.ReadLine()?.ToLower();
			if (confirmation == "y" || confirmation == "ye" || confirmation == "yes") {
				selectedAnimal.Detach();
				selectedAnimal = null;
				menuMode = menuModes.MainMenu;
				Console.WriteLine("Removed successfully");
			} else {
				Console.WriteLine("Action aborted!");
			}
		} else if (input == walkOpt.ToString()) {
			bool result = selectedAnimal.Walk();
			if (!result) Console.WriteLine("Animal cannot walk at this moment");
		} else if (input == feedOpt.ToString()) {
			bool result = selectedAnimal.Eat();
			Console.WriteLine(
				result
				? "Animal was fed!"
				: "Animal is not hungry!"
			);
		} else if (input == flyOpt.ToString()) {
			var flyable = (IFlyable)selectedAnimal!;
			bool result = flyable.Fly();
			if (!result) Console.WriteLine("Animal cannot fly at this moment");
		} else if (input == runOpt.ToString()) {
			var runnable = (IRunable)selectedAnimal!;
			bool result = runnable.Run();
			if (!result) Console.WriteLine("Animal cannot run at this moment");
		} else if (input == exitOpt.ToString()) {
			selectedAnimal = null;
			menuMode = menuModes.MainMenu;
		}
	}
	static void animalSelectionMenu() {
		StringBuilder promptBuilder = new("Please select the animal you want to edit:\n");
		var animals = new List<Animal>();
		int i = 1;
		foreach (var animal in person) {
			animals.Add(animal);
			promptBuilder.Append($"{i}. {animal}|Habitat name: {animal.Habitat?.Name}\n");
			i++;
		}
		foreach (var animal in store) {
			animals.Add(animal);
			promptBuilder.Append($"{i}. {animal}|Habitat name: {animal.Habitat?.Name}\n");
			i++;
		}
		foreach (var animal in wild) {
			animals.Add(animal);
			promptBuilder.Append($"{i}. {animal}|Habitat name: {animal.Habitat?.Name}\n");
			i++;
		}
		promptBuilder.Append($"{i++}. Add new animal\n");
		promptBuilder.Append($"{i}. Main menu");
		string input = getValidInput(promptBuilder.ToString(),s => int.TryParse(s,out int n) && n > 0 && n <= animals.Count + 2);
		int n = int.Parse(input);
		if (n == animals.Count + 1) {
			string prompt = @"Please select the habitat:
1. Person
2. Pet shop
3. Wilderness";
			input = getValidInput(prompt,["1","2","3"]);
			Habitat habitat = input switch {
				"1" => person,
				"2" => store,
				"3" => wild,
				_ => throw new InvalidDataException("Invalid habitat option")
			};
			if (habitat.IsFull()) {
				Console.WriteLine("Selected habitat is full!");
				return;
			}
			promptUserAnimalCreate(habitat);
		} else if (n >= animals.Count + 2) {
			menuMode = menuModes.MainMenu;
		} else { 
			selectedAnimal = animals[n - 1];
			menuMode = menuModes.AnimalMode;
		}
		animals.Clear();
	}
	static void promptUserAnimalCreate(Habitat habitat) {
		string prompt = @"Please select animal type
1. Dog
2. Canary
3. Lizard";
		string input = getValidInput(prompt,["1","2","3"]);
		string animalName = getValidInput("Please enter animal name",_ => true).Trim();
		if (input == "1") {
			new Dog(animalName,habitat).StateChanged += onAnimalStateChange;
		} else if (input == "2") {
			new Canary(animalName,habitat).StateChanged += onAnimalStateChange;
		} else if (input == "3") {
			new Lizard(animalName,habitat).StateChanged += onAnimalStateChange;
		}
		Console.WriteLine("Successfully added animal!");
	}
	// Returns user input if it matches the predicate
	static string getValidInput(string prompt,Predicate<string> validator) {
		Console.WriteLine(prompt);
		while (true) {
			string? input = Console.ReadLine();
			if (input is not null && validator(input)) return input;
			Console.WriteLine("Invalid input, please try again!");
		}
	}
	// Returns user input if it matches one of the provided valid inputs
	static string getValidInput(string prompt,string[] validInputs) {
		Console.WriteLine(prompt);
		while (true) {
			string? input = Console.ReadLine();
			if (input is not null && validInputs.Contains(input)) return input;
			Console.WriteLine("Invalid input, please try again!");
		}
	}
	public static void Run() {
		while (menuMode != menuModes.None) {
			if (menuMode == menuModes.MainMenu) {
				mainMenu();
			} else if (menuMode == menuModes.HabitatMenu) {
				habitatMenu();
			} else if (menuMode == menuModes.AnimalMode) {
				animalMenu();
			} else if (menuMode == menuModes.AnimalSelectionMode) {
				animalSelectionMenu();
			}
			Console.WriteLine(new string('=',20));
		}
	}
}