namespace SoftwareArch.lab1;

public static class AnimalFactory {
	private static readonly Dictionary<string,Func<string,Habitat,Animal>> registry = new();

	public static void Register(string typeName,Func<string,Habitat,Animal> creator) {
		registry[typeName] = creator;
	}
	public static Animal Create(string type,string name,Habitat habitat) {
		if (!registry.TryGetValue(type,out var creator)) throw new ArgumentException("No creator found for provided type",nameof(type));
		return creator(name, habitat);
	}
}
