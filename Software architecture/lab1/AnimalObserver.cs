namespace SoftwareArch.lab1;

public class AnimalObserver() {
	public void Subscribe(Animal animal) {
		animal.StateChanged += onStateChanged;
	}
	public void Unsubscribe(Animal animal) {
		animal.StateChanged -= onStateChanged;
	}
	private void onStateChanged(object? sender,AnimalStateChangeArgs args) {
		var animal = (Animal)sender!;
		if (args.ChangedState == AnimalStates.Dying && animal.Habitat is not null) {
			Console.WriteLine($"{animal.Name} died in {animal.Habitat.Name}");
		} else if (args.ChangedState == AnimalStates.Walking) {
			Console.WriteLine($"{animal.Name} is walking");
		} else if (args.ChangedState == AnimalStates.Singing) {
			Console.WriteLine($"{animal.Name} is singing");
		} else if (args.ChangedState == AnimalStates.Flying) {
			Console.WriteLine($"{animal.Name} is flying");
		} else if (args.ChangedState == AnimalStates.Running) {
			Console.WriteLine($"{animal.Name} is running");
		}
	}
}