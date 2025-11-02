namespace Coursework.BusinessLevel;

/// <summary>
/// Represesnts the result and a message of any operation
/// </summary>
/// <param name="result">Whether the operation was successful</param>
/// <param name="message">(Error) message to the operation</param>
public readonly struct Result(bool result,string message) {
	/// <summary>
	/// Gets the opertaion success
	/// </summary>
	public readonly bool Success { get; } = result;
	/// <summary>
	/// Gets a message provided with the operation success, or an empty string if no message was given
	/// </summary>
	public readonly string Message { get; } = message;

	/// <summary>
	/// Creates a new <see cref="Result"/> object with the <see cref="Success"/> set to <see langword="false"/>
	/// </summary>
	/// <param name="message">An error message provided with the failure of the operation</param>
	/// <returns></returns>
	public static Result Fail(string message) => new Result(false,message);
	/// <summary>
	/// Creates a new <see cref="Result"/> with the <see cref="Success"/> set to <see langword="true"/>
	/// </summary>
	/// <param name="message">A message provided with the successful completion of the operation</param>
	/// <returns></returns>
	public static Result Ok(string message) => new Result(true,message);
	/// <summary>
	/// An empty <see cref="Result"/> with <see cref="Success"/> = <see langword="true"/> and <see cref="Message"/> set to empty string
	/// </summary>
	public static Result Successful => new Result(true,string.Empty);
}