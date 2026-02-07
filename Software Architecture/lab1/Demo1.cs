namespace SoftwareArch.lab1;

static class Demo1 {
	public static void Run() {
		var wild = new Wilderness();
		var store = new AnimalStore("Shelter");
		var person = new Person("Vova");

		var sharik = new Dog("Sharik",store);
		sharik.StateChanged += (sender,args) => {
			var dog = (Dog)sender!;
			switch (args.StateChanged) {
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
				case AnimalStates.Living:
					if (!dog.IsAlive) Console.WriteLine($"{dog.Name} has died :/");
					break;
			}
		};

		store.CreateAnimalInHabitat<Dog>("Barboss");
		store.CreateAnimalInHabitat<Canary>("Birb");
		store.CreateAnimalInHabitat<Lizard>("Snaky");
		// feeding
		store.FeedAll();
		// feeding again (shouldn't do anything)
		sharik.Eat();
		// happiness
		store.CleanAll();
		
		store.AdvanceDay(); // they shouldn't die because they are fed and cleaned after
		// ownership transfer
		sharik.ChangeHabitat(person);
		// overfilling the habitat
		try {
			person.CreateAnimalInHabitat<Lizard>("Liz1");
			person.CreateAnimalInHabitat<Lizard>("Liz2");
			person.CreateAnimalInHabitat<Lizard>("Liz3");
			person.CreateAnimalInHabitat<Lizard>("Liz4");
			person.CreateAnimalInHabitat<Lizard>("Liz5"); // should throw here
		} catch (Exception e) {
			Console.WriteLine(e.StackTrace);
		}
		Console.WriteLine(new string('=',20));
		for (int i = 0;i < person.MaxAnimals;i++) {
			person.GetAnimalAt(i)?.ChangeHabitat(wild);
		}
		// dying
		sharik.AdvanceDay();
		// detaching
		Console.WriteLine($"Number of animals in wilderness: {wild.AnimalCount}");
		sharik.Detach();
		Console.WriteLine($"Number of animals in wilderness after detaching: {wild.AnimalCount}");
	}
}