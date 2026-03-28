namespace SoftwareDesign.lab2.Models;

public readonly struct ActionResult(bool success,string message) {
	public readonly bool Success { get; } = success;
	public readonly string Message { get; } = message;

	public static ActionResult Ok(string message = "") => new ActionResult(true,message);
	public static ActionResult Fail(string message = "") => new ActionResult(false,message);
}

public readonly struct ActionResult<TData>(bool success,string message,TData? data) {
	public readonly bool Success { get; } = success;
	public readonly string Message { get; } = message;
	public readonly TData? Data { get; } = data;

	public static ActionResult<TData> Ok(TData? data,string message = "") => new ActionResult<TData>(true,message,data);
	public static ActionResult<TData> Fail(TData? data,string message = "") => new ActionResult<TData>(false,message,data);
}