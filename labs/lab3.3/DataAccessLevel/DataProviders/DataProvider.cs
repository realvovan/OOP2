namespace DataAccessLevel.DataProviders;

public abstract class DataProvider(string filePath) {
	public bool IsLocked { get; protected set; } = false;
	public string FilePath { get; private set; } = filePath;
	protected abstract void saveToFileLogic<T>(ICollection<T> objects) where T : new();
	protected abstract ICollection<T>? loadFromFileLogic<T>() where T : new();
	public void SaveToFile<T>(ICollection<T> objcets) where T : new() {
		if (this.IsLocked) throw new FileLockedException();
		this.IsLocked = true;
		this.saveToFileLogic(objcets);
		this.IsLocked = false;
	}
	public ICollection<T>? LoadFromFile<T>() where T : new() {
		if (this.IsLocked) throw new FileLockedException();
		this.IsLocked = true;
		ICollection<T>? objects = this.loadFromFileLogic<T>();
		this.IsLocked = false;
		return objects;
	}
	public bool SetPath(string newPath) {
		if (this.IsLocked) return false;
		if (string.IsNullOrWhiteSpace(newPath)) return false;
		this.FilePath = newPath;
		return true;
	}
}
