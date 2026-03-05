namespace SoftwareArch.lab1;

public static class CalendarService {
	public static void AdvanceDay(Animal animal) {
		if (!animal.IsAlive) return;
		var deathReason = animal.CanSurviveToday();
		if (deathReason is not null) {
			animal.Die(deathReason.Value);
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