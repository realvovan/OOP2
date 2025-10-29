using Coursework.Commons.Validators;

namespace Coursework.DataLevel.Entities;

public class Client {
	public const int MAX_SUGGESTIONS = 5;

	private string firstName = "";
	private string lastName = "";
	private string email = "";
	private string phone = "";
	private string passport = "";
	private string bankId = "";
	private double desiredPrice;
	private byte desiredRooms;

	public string FirstName {
		get => this.firstName;
		set {
			if (!ClientValidator.ValidateName(value)) throw new FormatException("Invalid name format");
			this.firstName = value;
		}
	}
	public string LastName {
		get => this.lastName;
		set {
			if (!ClientValidator.ValidateName(value)) throw new FormatException("Invalid name format");
			this.lastName = value;
		}
	}
	public string Email {
		get => this.email;
		set {
			if (!ClientValidator.ValidateEmail(value)) throw new FormatException("Invalid email format");
			this.email = value;
		}
	}
	public string PhoneNumber {
		get => this.phone;
		set {
			if (!ClientValidator.ValidatePhone(value)) throw new FormatException("Invalid phone number format");
			this.phone = value;
		}
	}
	public string Passport {
		get => this.passport;
		set {
			if (!ClientValidator.ValidatePassport(value)) throw new FormatException("Invalid passport number format");
			this.passport = value;
		}
	}
	public string IBAN {
		get => this.bankId;
		set {
			if (!ClientValidator.ValidateIban(value)) throw new FormatException("Invalid IBAN format");
			this.bankId = value;
		}
	}
	public double DesiredPrice {
		get => this.desiredPrice;
		set {
			if (!RealEstateValidators.ValidatePrice(value)) throw new InvalidDataException("Price must be a positive number");
			this.desiredPrice = value;
		}
	}
	public byte DesiredRoomCount {
		get => this.desiredRooms;
		set {
			if (!RealEstateValidators.ValidateRoomNumber(value)) throw new InvalidDataException("Room count must be a positive number");
			this.desiredRooms = value;
		}
	}
	public string PhotoFilePath { get; set; }
	public List<Guid> SuggestedRealEstates { get; init; }
	public DateTime CreatedAt { get; init; }

	public Client(
		string firstName,
		string lastName,
		string email,
		string phoneNumber,
		string passport,
		string iban,
		double desiredPrice,
		byte desiredRoomCount,
		IList<Guid> suggestedRealEstates,
		string photoPath = ""
	) {
		this.FirstName = firstName;
		this.LastName = lastName;
		this.Email = email;
		this.PhoneNumber = phoneNumber;
		this.Passport = passport;
		this.IBAN = iban;
		this.DesiredPrice = desiredPrice;
		this.DesiredRoomCount = desiredRoomCount;
		this.PhotoFilePath = photoPath;
		this.SuggestedRealEstates = new List<Guid>();
		for (int i = 0; i < MAX_SUGGESTIONS; i++) {
			this.SuggestedRealEstates[i] = suggestedRealEstates[i];
		}
		this.CreatedAt = DateTime.Now;
	}

	public void AddSuggestion(Guid guid) {
		if (this.SuggestedRealEstates.Count >= MAX_SUGGESTIONS) throw new TooManySuggestionsException(MAX_SUGGESTIONS);
		if (this.SuggestedRealEstates.Contains(guid)) throw new SuggestionAlreadyExistsException(guid);
		this.SuggestedRealEstates.Add(guid);
	}

	public bool RemoveSuggestion(Guid guid) => this.SuggestedRealEstates.Remove(guid);
}