namespace SoftwareArch.lab1;

static class Program {
	static void Main(string[] args) {
		if (args.Length == 0) throw new InvalidDataException("Invalid program arguments");
		string demoType = args[0].ToLower();
		registerAnimals();
		if (demoType == "demo1") {
			Demo1.Run();
		} else if (demoType == "demo2") {
			Demo2.Run();
		} else {
			throw new InvalidDataException($"Invalid program argument ({demoType})");
		}
	}
	static void registerAnimals() {
		AnimalFactory.Register("dog",(name,habitat) => new Dog(name,habitat));
		AnimalFactory.Register("canary",(name,habitat) => new Canary(name,habitat));
		AnimalFactory.Register("lizard",(name,habitat) => new Lizard(name,habitat));
	}
}