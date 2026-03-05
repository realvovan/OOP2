namespace SoftwareArch.lab1;

static class Demo1 {
	public static void Run() {
		var wild = new Wilderness();
		var store = new AnimalStore("Shelter");
		var person = new Person("Vova");

		var sharik = new Dog("Sharik",store);
		sharik.StateChanged += (sender,args) => {
			var dog = (Dog)sender!;
			switch (args.ChangedState) {
				case AnimalStates.Eating:
					Console.WriteLine($"{dog.Name} ate {dog.FeedCountToday} times today!");
					break;
				case AnimalStates.Happiness:
					Console.WriteLine(
						dog.IsHappy
						? $"{dog.Name} is happy now"
						: $"{dog.Name} is unhappy now"
					);
					break;
				case AnimalStates.Habitat:
					Console.WriteLine(
						dog.Habitat is null
						? $"{dog.Name}'s habitat is now set to null"
						: $"{dog.Name}'s habitat is now {dog.Habitat.Name}"
					);
					break;
			}
		};
		sharik.Died += (sender,args) => {
			var dog = (Dog)sender!;
			Console.WriteLine($"{dog.Name} died for reason: {args.DeathReason}");
		};
		AnimalFactory.Create("dog","Barboss",store);
		AnimalFactory.Create("canary","Birb",store);
		AnimalFactory.Create("lizard","Snaky",store);
		// feeding
		store.FeedAll();
		// feeding again (shouldn't do anything)
		sharik.Eat();
		// happiness
		store.CleanAll();
		
		CalendarService.AdvanceDay(store); // they shouldn't die because they are fed and cleaned after
		// ownership transfer
		sharik.ChangeHabitat(person);
		// overfilling the habitat
		try {
			AnimalFactory.Create("lizard","Liz1",person);
			AnimalFactory.Create("lizard","Liz2",person);
			AnimalFactory.Create("lizard","Liz3",person);
			AnimalFactory.Create("lizard","Liz4",person);
			AnimalFactory.Create("lizard","Liz5",person); // should throw here
		} catch (Exception e) {
			Console.WriteLine(e.StackTrace);
		}
		Console.WriteLine(new string('=',20));
		for (int i = 0;i < person.MaxAnimals;i++) {
			person.GetAnimalAt(i)?.ChangeHabitat(wild);
		}
		// dying
		CalendarService.AdvanceDay(sharik);
		// detaching
		Console.WriteLine($"Number of animals in wilderness: {wild.AnimalCount}");
		sharik.Detach();
		Console.WriteLine($"Number of animals in wilderness after detaching: {wild.AnimalCount}");
	}
}