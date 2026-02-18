namespace SoftwareArch.lab1;

public abstract class Habitat(string name) {
	public abstract int MaxAnimals { get; }
	public string Name { get; set; } = name;
	public int AnimalCount => this.animals.Count;
	protected List<Animal> animals = new();

	// Do not directly add/remove animals from the habitat. Use Animal.ChangeHabitat instead
	internal bool RemoveAnimal(Animal animal) => this.animals.Remove(animal);
	internal void AddAnimal(Animal animal) {
		if (this.IsFull()) throw new Exception("Habitat out of capacity");
		if (this.animals.Contains(animal)) throw new Exception("Animal already in the shelter");
		this.animals.Add(animal);
	}
	public void FeedAll() {
		foreach (var i in this.animals) i.Eat();
	}
	public Animal? GetAnimalAt(int index) {
		if (index >= 0 && index < this.animals.Count) {
			return this.animals[index];
		}
		return null;
	}
	public bool HasAnimal(Animal animal) => this.animals.Contains(animal);
	public bool IsFull() => this.animals.Count >= this.MaxAnimals;
	public void CreateAnimalInHabitat<T>(string animalName) where T : Animal {
		var type = typeof(T);
		if (type.IsAbstract) throw new NotSupportedException("Cannot create an instance of abstract class");
		Activator.CreateInstance(type,new object[] { animalName,this });
	}
	public IEnumerator<Animal> GetEnumerator() => this.animals.GetEnumerator();
}

public class AnimalStore(string name) : Habitat(name),ICaregiver {
	public override int MaxAnimals => 10;
	public void CleanAll() {
		foreach (var animal in this.animals) animal.Clean();
	}
}
public class Person(string name) : Habitat(name),ICaregiver {
	public override int MaxAnimals => 5;
	public void CleanAll() {
		foreach (var animal in this.animals) animal.Clean();
	}
}
public class Wilderness(string name) : Habitat(name) {
	public override int MaxAnimals => int.MaxValue;

	public Wilderness() : this("[Wilderness]") { }
}