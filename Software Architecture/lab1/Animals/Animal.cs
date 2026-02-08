namespace SoftwareArch.lab1;

public abstract class Animal : IFeedable, IWalkable {
	public const int MAX_DAILY_FEEDING = 5;
	public static readonly TimeSpan FeedingCooldown = TimeSpan.FromSeconds(5); // increase for real life use

	private bool isHappy = false;

	public event EventHandler<AnimalStateChangeArgs>? StateChanged;
	public string Name { get; set; }
	public DateTime LastFedAt { get; private set; } = DateTime.MinValue;
	public int FeedCountToday { get; private set; } = 0;
	public bool IsAlive { get; private set; } = true;
	public bool IsHappy {
		get => this.isHappy || this.Habitat is not ICaregiver;
		private set => this.isHappy = value;
	}
	public Habitat? Habitat { get; private set; }
	public Animal(string name,Habitat habitat) {
		this.Name = name;
		this.Habitat = habitat;

		habitat.AddAnimal(this);
	}

	public bool Walk() {
		if (!this.IsAlive) return false;
		Console.WriteLine($"{this.Name} is walking");
		this.fireChangeStateEvent(AnimalStates.Walking);
		return true;
	}
	public bool Eat() {
		if (!this.IsAlive || this.FeedCountToday >= MAX_DAILY_FEEDING || DateTime.Now - this.LastFedAt < FeedingCooldown) return false;
		this.FeedCountToday++;
		this.LastFedAt = DateTime.Now;
		this.fireChangeStateEvent(AnimalStates.Eating);
		return true;
	}
	public void Clean() {
		this.SetHappy(true);
	}
	public bool CanBeActive() {
		return (DateTime.Now - this.LastFedAt).TotalHours <= 8;
	}
	public bool CanSurviveToday() {
		// can survive if the animals is
		// - fed
		// - happy or lives in the wild
		return this.FeedCountToday > 0 && this.IsHappy;
	}
	public void SetHappy(bool newHappy) {
		if (this.IsHappy != newHappy && this.IsAlive) {
			this.IsHappy = newHappy;
			this.fireChangeStateEvent(AnimalStates.Happiness);
		}
	}
	public void Die() {
		if (this.IsAlive) {
			this.IsAlive = false;
			this.fireChangeStateEvent(AnimalStates.Dying);
		}
	}
	public void ResetFeedCount() => this.FeedCountToday = 0;
	public bool ChangeHabitat(Habitat newHabitat) {
		if (!this.IsAlive || this.Habitat is null || this.Habitat == newHabitat || newHabitat.AnimalCount >= newHabitat.MaxAnimals) return false;
		this.Habitat.RemoveAnimal(this);
		newHabitat.AddAnimal(this);
		this.Habitat = newHabitat;
		this.fireChangeStateEvent(AnimalStates.Habitat);
		return true;
	}
	// Method used to 'Destroy' the object by unlinking it from any habitat
	public void Detach() {
		if (this.Habitat is null) return;
		this.Die();
		this.Habitat.RemoveAnimal(this);
		this.Habitat = null;
		this.fireChangeStateEvent(AnimalStates.Habitat);
	}
	public override string ToString() {
		return $"{this.GetType().Name} {this.Name}: IsAlive = {this.IsAlive}|IsHappy = {this.IsHappy}|Feed count today = {this.FeedCountToday}";
	}
	protected void fireChangeStateEvent(AnimalStates newState) {
		this.StateChanged?.Invoke(this,new AnimalStateChangeArgs(newState));
	}
}