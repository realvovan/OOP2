namespace SoftwareDesign.lab2.Exceptions;

public class UsernameAlreadyExistsException : Exception {
	const string MESSAGE = "This username already exists";
	public string Username { get; }

	public UsernameAlreadyExistsException(string message,string username) : base(message) {
		this.Username = username;
	}
	public UsernameAlreadyExistsException(string message,string username,Exception inner) : base(message,inner) {
		this.Username = username;
	}
	public UsernameAlreadyExistsException(string username) : this(MESSAGE,username) { }
	public UsernameAlreadyExistsException(string username,Exception inner) : this(MESSAGE,username,inner) { }
}
public class InvalidGuidException : Exception {
	const string MESSAGE = "Invalid Guid";
	public Guid Guid { get; }
	public InvalidGuidException(string message,Guid guid) : base(message) {
		this.Guid = guid;
	}
	public InvalidGuidException(string message,Guid guid,Exception inner) : base(message,inner) {
		this.Guid = guid;
	}
	public InvalidGuidException(Guid guid) : this(MESSAGE,guid) { }
	public InvalidGuidException(Guid guid,Exception inner) : this(MESSAGE,guid,inner) { }
}