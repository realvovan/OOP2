using Newtonsoft.Json;

namespace Coursework.DataLevel.DataProviders;

public class JsonProvider(string filePath,JsonSerializerSettings settings) : IDataProvider {
	public string FilePath { get; set; } = filePath;
	public JsonSerializerSettings Settings { get; set; } = settings;
	public void SaveToFile<T>(T items) {
		File.WriteAllText(this.FilePath,JsonConvert.SerializeObject(items,this.Settings));
	}
	public T? LoadFromFile<T>() {
		if (!File.Exists(this.FilePath)) return default;
		return JsonConvert.DeserializeObject<T>(File.ReadAllText(this.FilePath));
	}
	public JsonProvider(string filePath) : this(filePath,new JsonSerializerSettings {
		Formatting = Formatting.Indented,
		MissingMemberHandling = MissingMemberHandling.Error,
	}) { }
}