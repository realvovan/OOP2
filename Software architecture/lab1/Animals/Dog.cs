namespace SoftwareArch.lab1;

public class Dog(string name,Habitat habitat) : Animal(name,habitat),IRunable {
	public bool Run() {
		if (!this.IsAlive || !this.CanBeActive()) return false;
		Console.WriteLine($"{this.Name} is running!");
		this.fireChangeStateEvent(AnimalStates.Running);
		return true;
	}
}