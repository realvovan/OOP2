using Coursework.DataLevel.Entities;
using Coursework.Commons.Enums;

namespace Coursework.BusinessLevel.DTOs;

public class RealEstateDTO(
	string country,
	string provice,
	string city,
	string street,
	string houseNum,
	string zip,
	double price,
	byte roomCount,
	string photoPath,
	RealEstateType type,
	DateTime? createdAt = null,
	Guid? guid = null
) : IDTO<RealEstate> {
	public string Country { get; set; } = country;
	public string Provice { get; set; } = provice;
	public string City { get; set; } = city;
	public string Street { get; set; } = street;
	public string HouseNumber { get; set; } = houseNum;
	public string Zip { get; set; } = zip;
	public double Price { get; set; } = price;
	public byte RoomCount { get; set; } = roomCount;
	public string PhotoFilePath { get; set; } = photoPath;
	public RealEstateType Type { get; set; } = type;
	public DateTime? CreatedAt { get; set; } = createdAt;
	public Guid? Guid { get; set; } = guid;

	public RealEstate ToEntity() => new RealEstate(
		Country,
		Provice,
		City,
		Street,
		HouseNumber,
		Zip,
		Price,
		RoomCount,
		Type,
		PhotoFilePath
	);
	// needed for the non-generic interface
	object IDTO.ToEntity() => this.ToEntity();

	public override string ToString() => $"{this.Country}, {this.City}, {this.Street}, {this.HouseNumber}, (zip: {this.Zip})";

	public static RealEstateDTO FromRealEstate(RealEstate realEstate,Guid? guid = null) => new RealEstateDTO(
		realEstate.Country,
		realEstate.Province,
		realEstate.City,
		realEstate.Street,
		realEstate.HouseNumber,
		realEstate.Zip,
		realEstate.Price,
		realEstate.RoomCount,
		realEstate.PhotoFilePath,
		realEstate.Type,
		realEstate.CreatedAt,
		guid
	);
}