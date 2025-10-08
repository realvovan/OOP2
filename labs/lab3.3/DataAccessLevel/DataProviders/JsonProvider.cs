using System.Text.Json;

namespace DataAccessLevel.DataProviders;

public class JsonProvider(string filePath) : DataProvider(filePath) {
	protected override void saveToFileLogic<T>(ICollection<T> objects) {
		File.WriteAllText(this.FilePath,JsonSerializer.Serialize(objects));
	}
	protected override ICollection<T>? loadFromFileLogic<T>() {
		if (!File.Exists(this.FilePath)) throw new FileNotFoundException($"Couldn't open file at {this.FilePath}");
		var objects = JsonSerializer.Deserialize<ICollection<T>>(File.ReadAllText(this.FilePath));
		return objects;
	}
}