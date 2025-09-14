using System.Reflection;
using System.Runtime.Serialization;
using Database.People;

namespace Database.FileManager;

public class DatabaseManager(string filePath) {
	public string FilePath { get; set; } = filePath;
	public bool IsLocked { get; private set; } = false;

	public void SaveToFile(Person[] people) => this.writeToFile(people,false);
	public void AppendToFile(Person[] people) => this.writeToFile(people,true);
	public Person[] LoadFromFile() {
		if (this.IsLocked) throw new DatabaseLockedException("Database locked for another operation! Cannot read!");
		if (!File.Exists(this.FilePath)) throw new FileNotFoundException();
		this.IsLocked = true;
		using var reader = new StreamReader(this.FilePath);
		var result = new Person[0];
		// if == 0 then reading object type
		// if == 1 then reading properties
		// if == 2 then read an invalid object => skipping until the next object
		int readingState = 0;
		while (!reader.EndOfStream) {
			string? line = reader.ReadLine()?.Trim();
			if (string.IsNullOrEmpty(line)) continue;
			if (line[0] == '{') {
				readingState = 1;
				continue;
			}
			else if (line[0] == '}') {
				readingState = 0;
				continue;
			}
			if (readingState == 0) {
				Type type = Type.GetType(line) ?? throw new TypeLoadException($"Could not find type {line}");
				if (!typeof(Person).IsAssignableFrom(type)) {
					readingState = 2;
					continue;
				}
#pragma warning disable
				result = [..result,(Person)FormatterServices.GetSafeUninitializedObject(type)!];
#pragma warning restore
			} else if (readingState == 1) {
				string[] split = line.Split(':',StringSplitOptions.TrimEntries);
				if (split.Length < 2) throw new InvalidDataException();
				Person person = result[result.Length - 1];
				PropertyInfo property = person.GetType().GetProperty(split[0].Substring(1,split[0].Length - 2))
					?? throw new InvalidDataException($"Invalid property name {split[0]}");
				if (split[1][0] == '"') {
					property.SetValue(person,split[1].Substring(1,split[1].Length - 2));
				} else if (split[1][0] == '\'') {
					property.SetValue(person,split[1][1]);
				} else if (split[1] == "True") {
					property.SetValue(person,true);
				} else if (split[1] == "False") {
					property.SetValue(person,false);
				} else if (split[1] == "null") {
					property.SetValue(person,null);
				} else if (int.TryParse(split[1],out int integer)) {
					property.SetValue(person,integer);
				} else if (float.TryParse(split[1],out float floating)) {
					property.SetValue(person,floating);
				} else {
					// its an enum
					Type? type = Type.GetType(split[1].Substring(0,split[1].LastIndexOf('.')));
					if (type != null && type.IsEnum) {
						property.SetValue(person,Enum.Parse(type,split[1].Substring(split[1].LastIndexOf('.') + 1)));
					} else {
						throw new InvalidDataException("Invalid property type");
					}
				}
			} else if (readingState == 2) continue;
		}
		return result;
	}

	private void writeToFile(Person[] people,bool append) {
		if (this.IsLocked) throw new DatabaseLockedException("Database locked for another operation! Cannot write!");
		this.IsLocked = true;
		using var writer = new StreamWriter(this.FilePath,append);
		foreach (var person in people) {
			var type = person.GetType();
			writer.Write(type.FullName);
			writer.Write("\n{\n");
			foreach (var property in type.GetProperties()) {
				string toWrite;
				var value = property.GetValue(person);
				if (value == null) toWrite = "null";
				else if (property.PropertyType.IsEnum) toWrite = $"{property.PropertyType.FullName}.{value}";
				else if (property.PropertyType == typeof(string)) toWrite = $"\"{value}\"";
				else if (property.PropertyType == typeof(char)) toWrite = $"'{value}'";
				else toWrite = value.ToString() ?? throw new Exception($"Could not convert property {property.Name} to string");
				writer.Write($"\"{property.Name}\": {toWrite}\n");
			}
			writer.Write("};\n");
		}
		this.IsLocked = false;
	}
}

public class DatabaseLockedException : Exception {
	public DatabaseLockedException() : base("Database locked for another operation!") { }
	public DatabaseLockedException(string message) : base(message) { }
	public DatabaseLockedException(string message,Exception? innerException) : base(message,innerException) { }
}