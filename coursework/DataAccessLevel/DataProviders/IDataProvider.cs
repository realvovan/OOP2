namespace Coursework.DataLevel.DataProviders;

/// <summary>
/// Data provider interface which can save and load objects from a file
/// </summary>
public interface IDataProvider {
	string FilePath { get; set; }
	void SaveToFile<T>(T items);
	T? LoadFromFile<T>();
}