using DataAccessLevel.Models;
using DataAccessLevel.DataProviders;
using System.Text;

namespace BusinessLogicLevel;

public enum DataProviders {
	BinaryProvider,
	CustomProvider,
	JsonProvider,
	XmlProvider
}

public class EntityService {
	private List<Person> people = new();
	private DataProvider dataProvider;

	public string FilePath {
		get => this.dataProvider.FilePath;
		set => this.dataProvider.SetPath(value);
	}
	public int PersonCount => this.people.Count;

	public EntityService(DataProvider provider) {
		this.dataProvider = provider;
	}
	public EntityService(DataProviders providerType,string filePath) {
		this.dataProvider = createProvider(providerType, filePath);
	}
	public EntityService(string providerTypeFullName,string filePath) {
		this.dataProvider = createProvider(providerTypeFullName, filePath);
	}
	public void ChangeProviderType(DataProvider newProvider) {
		this.dataProvider = newProvider;
	}
	public void ChangeProviderType(DataProviders newType) {
		this.dataProvider = createProvider(newType,this.dataProvider.FilePath);
	}
	public void ChangeProviderType(string providerTypeFullName) {
		this.dataProvider = createProvider(providerTypeFullName,this.dataProvider.FilePath);
	}
	public void Add(Person person) => this.people.Add(person);
	public bool Remove(int index) {
		if (index < 0 || index >= this.people.Count) return false;
		this.people.RemoveAt(index);
		return true;
	}
	public string GetAllPeopleInfo() {
		var result = new StringBuilder();
		for (int i = 0; i < this.people.Count; i++) {
			result.Append($"{i+1}. {this.people[i]}\n");
		}
		return result.ToString();
	}
	public string GetPersonFullInfo(Person person) {
		var result = new StringBuilder();
		foreach (var property in person.GetType().GetProperties()) {
			result.Append($"{property.Name}: {property.GetValue(person)}\n");
		}
		return result.ToString();
	}
	public FileAccessResult SaveToFile() {
		if (this.dataProvider.IsLocked) return new FileAccessResult(false,"File is locked.");
		try {
			this.dataProvider.SaveToFile(this.people);
			return new FileAccessResult();
		} catch (Exception e) {
			return new FileAccessResult(false,e.Message);
		}
	}
	public Person? SearchByName(string first,string last) {
		foreach (var i in this.people) {
			if (i.FirstName.ToLower() == first.ToLower() && i.LastName.ToLower() == last.ToLower()) {
				return i;
			}
		}
		return null;
	}
	public Person? SearchByIndex(int index) {
		if (index < 0 || index >= this.people.Count) return null;
		return this.people[index];
	}
	public void Clear() => this.people.Clear();
	public FileAccessResult LoadFromFile() {
		if (this.dataProvider.IsLocked) return new FileAccessResult(false,"File is locked");
		try {
			ICollection<Person>? loaded = this.dataProvider.LoadFromFile<Person>();
			if (loaded == null) return new FileAccessResult(false,"DataProvider returned null");
			this.people = loaded.ToList();
			return new FileAccessResult();
		} catch (Exception e) {
			return new FileAccessResult(false,$"Error occured while loading from file: {e.Message}");
		}
	}
	public string GetYear2StudentsWhoDoSports() {
		var result = new StringBuilder();
		bool found = false;
		for (int i = 0; i < this.people.Count; i++) {
			if (this.people[i] is Student student && student.Year == 2 && student.IsSportsAHobby) {
				result.Append($"{student.ToString()}, under index {i} in the list");
				found = true;
			}
		}
		if (!found) return "None";
		return result.ToString();
	}
	private static DataProvider createProvider(string providerTypeFullName,string filePath) {
		Type type = Type.GetType(providerTypeFullName) ?? throw new TypeLoadException($"Invalid type name '{providerTypeFullName}'");
		if (!typeof(DataProvider).IsAssignableFrom(type)) throw new TypeLoadException($"Invalid DataProvider");
		return (DataProvider)Activator.CreateInstance(type,[filePath])!;
	}
	private static DataProvider createProvider(DataProviders providerType,string filePath) {
		return providerType switch {
			DataProviders.BinaryProvider => new BinaryProvider(filePath),
			DataProviders.CustomProvider => new CustomProvider(filePath),
			DataProviders.JsonProvider => new JsonProvider(filePath),
			DataProviders.XmlProvider => new XmlProvider(filePath),
			_ => new JsonProvider(filePath),
		};
	}
}
