using Coursework.Commons.Validators;
using Coursework.Commons.Enums;

namespace Coursework.DataLevel.Entities;

public class RealEstate {
	private string country = "";
	private string province = "";
	private string city = "";
	private string street = "";
	private string houseNum = "";
	private string zip = "";

	private double price;
	private byte rooms;

	public string Country {
		get => this.country;
		set {
			if (!RealEstateValidators.ValidateAddress(value)) throw new FormatException("Invalid country format");
			this.country = value;
		}
	}
	public string Province {
		get => this.province;
		set {
			if (!RealEstateValidators.ValidateAddress(value)) throw new FormatException("Invalid provice format");
			this.province = value;
		}
	}
	public string City {
		get => this.city;
		set {
			if (!RealEstateValidators.ValidateAddress(value)) throw new FormatException("Invalid city format");
			this.city = value;
		}
	}
	public string Street {
		get => this.street;
		set {
			if (!RealEstateValidators.ValidateAddress(value)) throw new FormatException("Invalid street format");
			this.street = value;
		}
	}
	public string HouseNumber {
		get => this.houseNum;
		set {
			if (!RealEstateValidators.ValidateHouseNumber(value)) throw new FormatException("Invalid house number format");
			this.houseNum = value;
		}
	}
	public string Zip {
		get => this.zip;
		set {
			if (!RealEstateValidators.ValidateZip(value)) throw new FormatException("Invalid postal (zip) code format. Postal code must be 4-10 characters long");
			this.zip = value;
		}
	}
	public double Price {
		get => this.price;
		set {
			if (!RealEstateValidators.ValidatePrice(value)) throw new InvalidDataException("Price cannot be negative or zero");
			this.price = value;
		}
	}
	public byte RoomCount {
		get => this.rooms;
		set {
			if (!RealEstateValidators.ValidateRoomNumber(value)) throw new InvalidDataException("Number of rooms cannot be negative or zero");
			this.rooms = value;
		}
	}
	public string PhotoFilePath { get; set; }
	public RealEstateType Type { get; set; }
	public DateTime CreatedAt { get; init; }
	public RealEstate(
		string country,
		string province,
		string city,
		string street,
		string houseNumber,
		string zip,
		double price,
		byte roomCount,
		RealEstateType type,
		string photoPath = ""
	) {
		this.Country = country;
		this.Province = province;
		this.City = city;
		this.Street = street;
		this.HouseNumber = houseNumber;
		this.Zip = zip;
		this.Price = price;
		this.RoomCount = roomCount;
		this.Type = type;
		this.PhotoFilePath = photoPath;
		this.CreatedAt = DateTime.Now;
	}
}