namespace Coursework.DataLevel.DataProviders;

public interface IDataProvider {
	string FilePath { get; set; }
	void SaveToFile<T>(T items);
	T? LoadFromFile<T>();
}