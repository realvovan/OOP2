namespace Coursework.DataLevel.Entities;

public class TooManySuggestionsException : Exception {
	public TooManySuggestionsException() : base("Cannot add more suggestions") { }
	public TooManySuggestionsException(string message) : base(message) { }
	public TooManySuggestionsException(string message,Exception inner) : base(message,inner) { }
	public TooManySuggestionsException(int maxSuggestions) : base($"Cannot add more than {maxSuggestions} suggestions") { }
}
public class SuggestionAlreadyExistsException : Exception {
	public SuggestionAlreadyExistsException() : base("Suggestion with the given Guid already added") { }
	public SuggestionAlreadyExistsException(string message) : base(message) { }
	public SuggestionAlreadyExistsException(string message,Exception inner) : base(message,inner) { }
	public SuggestionAlreadyExistsException(Guid guid) : base($"Suggestion with Guid '{guid}' already added") { }
}