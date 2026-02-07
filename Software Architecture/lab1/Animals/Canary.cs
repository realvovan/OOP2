namespace SoftwareArch.lab1;

public class Canary(string name,Habitat habitat) : Animal(name,habitat),IFlyable,ISingable {
	public bool Fly() {
		if (!this.IsAlive || !this.CanBeActive()) return false;
		Console.WriteLine($"{this.Name} is flying!");
		this.fireChangeStateEvent(AnimalStates.Flying);
		return true;
	}
	public bool Sing() {
		if (!this.IsAlive || !this.CanBeActive()) return false;
		Console.WriteLine($"{this.Name} is singing!");
		this.fireChangeStateEvent(AnimalStates.Singing);
		return true;
	}
	public bool Sing(string sound) {
		if (!this.IsAlive || !this.CanBeActive()) return false;
		Console.WriteLine($"{this.Name}: {sound}");
		this.fireChangeStateEvent(AnimalStates.Singing);
		return true;
	}
}