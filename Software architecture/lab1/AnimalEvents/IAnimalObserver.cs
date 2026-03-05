namespace SoftwareArch.lab1;

public interface IAnimalObserver {
	void Subscribe(Animal animal);
	void Unsubscribe(Animal animal);
}
