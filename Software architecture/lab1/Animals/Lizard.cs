namespace SoftwareArch.lab1;

public class Lizard(string name,Habitat habitat) : Animal(name,habitat),IRunable {
	public ActionResult Run() {
		if (!this.IsAlive) return ActionResult.Fail("Animal cannot run because it is dead");
		if (!this.CanBeActive()) return ActionResult.Fail("Animal cannot run because it is not fed");
		Console.WriteLine($"{this.Name} is running!");
		this.fireChangeStateEvent(AnimalStates.Running);
		return ActionResult.Successful;
	}
}