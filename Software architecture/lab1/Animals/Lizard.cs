namespace SoftwareArch.lab1;

public class Lizard(string name,Habitat habitat) : Animal(name,habitat),IRunable {
	public bool Run() {
		if (!this.CanBeActive()) return false;
		Console.WriteLine($"{this.Name} is running!");
		this.fireChangeStateEvent(AnimalStates.Running);
		return true;
	}
}