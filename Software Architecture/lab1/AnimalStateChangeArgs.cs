namespace SoftwareArch.lab1;

public enum AnimalStates {
	Walking,
	Running,
	Flying,
	Singing,
	Dying,
	Eating,
	Happiness,
	Habitat,
}
public class AnimalStateChangeArgs(AnimalStates changedState) : EventArgs {
	public AnimalStates ChangedState { get; } = changedState;
}