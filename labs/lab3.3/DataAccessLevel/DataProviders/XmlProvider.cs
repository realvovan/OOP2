using System.Xml.Serialization;

namespace DataAccessLevel.DataProviders;

public class XmlProvider(string filePath) : DataProvider(filePath) {
	protected override void saveToFileLogic<T>(ICollection<T> objects) {
		using var writer = new StreamWriter(this.FilePath);
		new XmlSerializer(typeof(T[]),this.getKnownTypes(typeof(T))).Serialize(writer,objects.ToArray());
	}
	protected override ICollection<T>? loadFromFileLogic<T>() {
		if (!File.Exists(this.FilePath)) throw new FileNotFoundException($"Couldn't open file at {this.FilePath}");
		using var reader = new StreamReader(this.FilePath);
		var objects = new XmlSerializer(typeof(List<T>),this.getKnownTypes(typeof(T))).Deserialize(reader);
		return (ICollection<T>?)objects;
	}
	private Type[] getKnownTypes(Type basetype) {
		var assembly = basetype.Assembly;
		var types = new List<Type>();
		foreach (var i in assembly.GetTypes()) {
			if (i != basetype && basetype.IsAssignableFrom(i)) {
				types.Add(i);
			}
		}
		return types.ToArray();
	}
}