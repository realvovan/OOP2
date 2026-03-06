namespace SoftwareArch.lab1;

public static class CalendarService {
	public static void AdvanceDay(Animal animal) {
		if (!animal.IsAlive) return;
		if (!animal.CanSurviveToday(out var deathReason)) {
			animal.Die(deathReason);
		}
		animal.SetHappy(false);
		animal.ResetFeedCount();
	}
	public static void AdvanceDay(Habitat habitat) {
		foreach (var animal in habitat) {
			AdvanceDay(animal);
		}
	}
}