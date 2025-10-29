namespace Coursework.BusinessLevel;

public readonly struct Result(bool result,string message) {
	public readonly bool Success { get; } = result;
	public readonly string Message { get; } = message;

	public static Result Fail(string message) => new Result(false,message);
	public static Result Ok(string message) => new Result(true,message);
	public static Result Successful => new Result(true,string.Empty);
}