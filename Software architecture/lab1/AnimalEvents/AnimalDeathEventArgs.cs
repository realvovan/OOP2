namespace SoftwareArch.lab1;

public enum AnimalDeathReasons {
	NotSpecifed = 0,
	Hunger = 1,
	NotCleaned = 2,
	HabitatNulled = 4,
}

public class AnimalDeathEventArgs(AnimalDeathReasons deathReason) : EventArgs {
	public AnimalDeathReasons DeathReason { get; } = deathReason;
}
