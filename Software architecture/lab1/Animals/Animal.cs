namespace SoftwareArch.lab1;

public abstract class Animal : IFeedable, IWalkable {
	public const int MAX_DAILY_FEEDING = 5;
	public static readonly TimeSpan FeedingCooldown = TimeSpan.FromSeconds(5); // increase for real life use

	private bool isHappy = false;

	public event EventHandler<AnimalStateChangeArgs>? StateChanged;
	public event EventHandler<AnimalDeathEventArgs>? Died;
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

	public ActionResult Walk() {
		if (!this.IsAlive) return ActionResult.Fail("Animal cannot walk because it is dead");
		this.fireChangeStateEvent(AnimalStates.Walking);
		return ActionResult.Successful;
	}
	public ActionResult Eat() {
		if (!this.IsAlive) return ActionResult.Fail("Animal cannot eat because it is dead");
		if (this.FeedCountToday >= MAX_DAILY_FEEDING) return ActionResult.Fail("Animal cannot eat because it has reached max feeding count");
		if (DateTime.Now - this.LastFedAt < FeedingCooldown) return ActionResult.Fail("Animal cannot be fed so quickly, please wait");
		this.FeedCountToday++;
		this.LastFedAt = DateTime.Now;
		this.fireChangeStateEvent(AnimalStates.Eating);
		return ActionResult.Successful;
	}
	public void Clean() {
		this.SetHappy(true);
	}
	public bool CanBeActive() {
		return (DateTime.Now - this.LastFedAt).TotalHours <= 8;
	}
	public bool CanSurviveToday(out AnimalDeathReasons deathReason) {
		// can survive if the animals is
		// - fed
		// - happy or lives in the wild
		deathReason = 0;
		if (this.FeedCountToday == 0) deathReason |= AnimalDeathReasons.Hunger;
		if (!this.IsHappy) deathReason |= AnimalDeathReasons.NotCleaned;
		return deathReason == 0;
	}
	public void SetHappy(bool newHappy) {
		if (this.IsHappy != newHappy && this.IsAlive) {
			this.IsHappy = newHappy;
			this.fireChangeStateEvent(AnimalStates.Happiness);
		}
	}
	public void Die(AnimalDeathReasons reason = AnimalDeathReasons.NotSpecifed) {
		if (this.IsAlive) {
			this.IsAlive = false;
			this.Died?.Invoke(this,new AnimalDeathEventArgs(reason));
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
		this.Die(AnimalDeathReasons.HabitatNulled);
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