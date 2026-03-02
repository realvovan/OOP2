namespace SoftwareArch.lab1;

public class Canary(string name,Habitat habitat) : Animal(name,habitat),IFlyable,ISingable {
	public ActionResult Fly() {
		if (!this.IsAlive) return ActionResult.Fail("Animal cannot fly because it is dead");
		if (!this.CanBeActive()) return ActionResult.Fail("Animal cannot fly because it is not fed");
		this.fireChangeStateEvent(AnimalStates.Flying);
		return ActionResult.Successful;
	}
	public ActionResult Sing() {
		if (!this.IsAlive) return ActionResult.Fail("Animal cannot sing because it is dead");
		if (!this.CanBeActive()) return ActionResult.Fail("Animal cannot sing because it is not fed");
		this.fireChangeStateEvent(AnimalStates.Singing);
		return ActionResult.Successful;
	}
}