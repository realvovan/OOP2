namespace SoftwareArch.lab1;

public class AnimalDeathObserver : IAnimalObserver {
	private static Dictionary<AnimalDeathReasons,string> messages = new() {
		{ AnimalDeathReasons.NotSpecifed, "%s died for an unspecifed reason in habitat %s" },
		{ AnimalDeathReasons.Hunger, "%s died of hunder in habitat %s" },
		{ AnimalDeathReasons.NotCleaned, "%s died because it wasn't cleaned after in habitat %s" },
		{ AnimalDeathReasons.HabitatNulled, "%s died because its habitat was removed" },
		{ AnimalDeathReasons.Hunger | AnimalDeathReasons.NotCleaned, "%s died because it wasn't fed or cleaned after in habitat %s" }
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
