using DataAccessLevel.DataProviders;
using System.Drawing;
using System.Text.Json;

namespace lab3_3;

static class Program {
	static void Main() {
		var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
		Trapezoid[] array = [
			new Trapezoid(1,2,3),
			new Trapezoid(5,6,7,Color.AliceBlue,Color.Aqua),
			new Trapezoid(8,9,10,Color.Azure,Color.Beige),
			new Trapezoid(15,6,20)
		];
		//json
		Console.WriteLine("=============\nJson\n=============");
		File.WriteAllText("JsonTrapezoids.json",JsonSerializer.Serialize(array,jsonOptions));
		Trapezoid[]? deserialized = JsonSerializer.Deserialize<Trapezoid[]>(File.ReadAllText("JsonTrapezoids.json"));
		if (deserialized != null) {
			foreach (var i in deserialized) {
				Console.WriteLine(i.ToString());
			}
		} else {
			Console.WriteLine("Could not deserialize");
		}
		// xml serialization
		Console.WriteLine("=============\nXml\n=============");
		var xmlSerializer = new XmlProvider("XmlTrapezoids.xml");
		xmlSerializer.SaveToFile(array);
		deserialized = xmlSerializer.LoadFromFile<Trapezoid>()?.ToArray();
		if (deserialized != null) {
			foreach (var i in deserialized) {
				Console.WriteLine(i.ToString());
			}
		} else {
			Console.WriteLine("Could not deserialize");
		}
		// custom serialization
		Console.WriteLine("=============\nCustom\n=============");
		var customSerializer = new CustomProvider("CustomTrapezoids.txt");
		customSerializer.SaveToFile(array);
		deserialized = customSerializer.LoadFromFile<Trapezoid>()?.ToArray();
		if (deserialized != null) {
			foreach (var i in deserialized) {
				Console.WriteLine(i.ToString());
			}
		} else {
			Console.WriteLine("Could not deserialize");
		}
		// binary serialization
		Console.WriteLine("=============\nBinary\n=============");
		var binSerializer = new BinaryProvider("bin.txt");
		binSerializer.SaveToFile(array);
		deserialized = binSerializer.LoadFromFile<Trapezoid>()?.ToArray();
		if (deserialized != null) {
			foreach (var i in deserialized) {
				Console.WriteLine(i.ToString());
			}
		} else {
			Console.WriteLine("Could not deserialize");
		}
		// array vs list<T>
		List<Trapezoid> list = array.ToList();
		File.WriteAllText("TrapezoidList.json",JsonSerializer.Serialize(list,jsonOptions));
	}
}