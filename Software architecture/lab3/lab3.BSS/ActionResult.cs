namespace lab3.BLL;

public readonly struct ActionResult(bool result,string message) {
	public readonly bool Success { get; } = result;
	public readonly string Message { get; } = message;


	public static ActionResult Fail(string message) => new ActionResult(false,message);
	public static ActionResult Ok(string message) => new ActionResult(true,message);

	public static ActionResult Successful => new ActionResult(true,string.Empty);
}