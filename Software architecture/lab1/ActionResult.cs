namespace SoftwareArch.lab1;

public readonly struct ActionResult(string message,bool success) {
	public readonly string Message { get; } = message;
	public readonly bool Success { get; } = success;

	public static ActionResult Ok(string message) => new ActionResult(message,true);
	public static ActionResult Fail(string message) => new ActionResult(message,false);

	public static ActionResult Successful => new ActionResult(string.Empty,true);
}