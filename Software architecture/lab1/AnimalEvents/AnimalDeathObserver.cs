namespace SoftwareArch.lab1;

public class AnimalDeathObserver : IAnimalObserver {
	private static Dictionary<AnimalDeathReasons,string> messages = new() {
		{ AnimalDeathReasons.NotSpecifed, "{0} died for an unspecifed reason in habitat {1}" },
		{ AnimalDeathReasons.Hunger, "{0} died of hunder in habitat {1}" },
		{ AnimalDeathReasons.NotCleaned, "{0} died because it wasn't cleaned after in habitat {1}" },
		{ AnimalDeathReasons.HabitatNulled, "{0} died because its habitat was removed" },
		{ AnimalDeathReasons.Hunger | AnimalDeathReasons.NotCleaned, "{0} died because it wasn't fed and cleaned after in habitat {1}" }
	};
	public void Subscribe(Animal animal) {
		animal.Died += onDied;
	}
	public void Unsubscribe(Animal animal) {
		animal.Died -= onDied;
	}
	private void onDied(object? sender,AnimalDeathEventArgs args) {
		var animal = (Animal)sender!;
		var message = AnimalDeathObserver.messages.GetValueOrDefault(
			args.DeathReason,
			AnimalDeathObserver.messages[AnimalDeathReasons.NotSpecifed]
		);
		Console.WriteLine(string.Format(message,animal.Name,animal.Habitat?.Name));
	}
}
