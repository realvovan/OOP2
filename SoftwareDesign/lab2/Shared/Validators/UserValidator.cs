using System.Text.RegularExpressions;

namespace SoftwareDesign.lab2.Validators;

public static class UserValidator {
	private static readonly Regex _usernameRegex = new Regex("^[A-Za-z0-9_]{3,24}$",RegexOptions.Compiled);
	public static bool ValidateUsername(string username) => _usernameRegex.IsMatch(username);
	public static bool ValidateDisplayName(string displayName) => displayName.Length > 2 && displayName.Length < 25;
}