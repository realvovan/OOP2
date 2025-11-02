using System.Text.RegularExpressions;

namespace Coursework.Commons.Validators;

public static class ClientValidator {
	private static readonly Regex nameRegex = new Regex("^[A-ZА-ЯЇІЄҐa-zа-яїієґ'’]+$",RegexOptions.Compiled);
	private static readonly Regex emailRegex = new Regex(@"^[a-zA-Z0-9._%+\-]+@[a-zA-Z0-9.\-]+\.[a-zA-Z]{2,}$",RegexOptions.Compiled);
	private static readonly Regex ibanRegex = new Regex(@"^[A-Z]{2}\d+$",RegexOptions.Compiled);
	private static readonly Regex phoneRegex = new Regex(@"^\+?\d{7,15}$",RegexOptions.Compiled);
	private static readonly Regex passportRegex = new Regex(@"^(?:\d{9}|[A-Z]{2}\d{6})$",RegexOptions.Compiled);
	public static bool ValidateName(string? name) => !string.IsNullOrWhiteSpace(name) && nameRegex.IsMatch(name);
	public static bool ValidateEmail(string? email) => !string.IsNullOrWhiteSpace(email) && emailRegex.IsMatch(email);
	public static bool ValidateIban(string? iban) => !string.IsNullOrWhiteSpace(iban) && ibanRegex.IsMatch(iban);
	public static bool ValidatePhone(string? phone) => !string.IsNullOrWhiteSpace(phone) && phoneRegex.IsMatch(phone);
	public static bool ValidatePassport(string? passport) => !string.IsNullOrWhiteSpace(passport) && passportRegex.IsMatch(passport);
}