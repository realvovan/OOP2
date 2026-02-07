namespace SoftwareArch.lab1;

public enum AnimalStates {
	Walking,
	Running,
	Flying,
	Singing,
	Dying,
	Eating,
	Happiness,
	Living,
	Habitat,
}
public class AnimalStateChangeArgs(AnimalStates stateChanged) : EventArgs {
	public AnimalStates StateChanged { get; } = stateChanged;
}