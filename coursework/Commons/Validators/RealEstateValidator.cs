using System.Text.RegularExpressions;

namespace Coursework.Commons.Validators;

public static class RealEstateValidators {
	private static readonly Regex addressRegex = new Regex(@"^[a-zа-яїієґA-ZА-ЯЇІЄҐ'’\- ]{1,49}$",RegexOptions.Compiled);
	private static readonly Regex zipRegex = new Regex(@"^\d{4,10}$",RegexOptions.Compiled);
	private static readonly Regex houseRegex = new Regex(@"^\d+[A-ZА-ЯЇІЄҐa-zа-яїієґ]?$",RegexOptions.Compiled);
	
	public static bool ValidateAddress(string? address) => !string.IsNullOrWhiteSpace(address) && addressRegex.IsMatch(address);
	public static bool ValidateZip(string? zip) => !string.IsNullOrWhiteSpace(zip) && zipRegex.IsMatch(zip);
	public static bool ValidateHouseNumber(string? houseNum) => !string.IsNullOrWhiteSpace(houseNum) && houseRegex.IsMatch(houseNum);
	public static bool ValidatePrice(double price) => price > 0;
	public static bool ValidateRoomNumber(byte numberOfRooms) => numberOfRooms > 0;
}