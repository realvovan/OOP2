namespace DataAccessLevel.DataProviders;

public class FileLockedException : Exception {
	public FileLockedException() : base("Cannot read or write, file is locked") { }
	public FileLockedException(string message) : base(message) { }
	public FileLockedException(string message, Exception inner) : base(message, inner) { }
}
