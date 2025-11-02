using Coursework.BusinessLevel.DTOs;
using Coursework.Commons.Enums;
using Coursework.DataLevel.Entities;

namespace Coursework.Tests;

public class RealEstateDTOTests {
	private static RealEstateDTO createRealEstateDTO() => new RealEstateDTO(
		"country","province","city","street","1a","09800",1,1,"",RealEstateType.Apartment
	);

	[Fact]
	public void Constructor_WorksCorrectly() {
		// Arrange
		string country = "Country";
		string province = "Province";
		string city = "City";
		string street = "Street";
		string house = "1A";
		string zip = "09800";
		double price = 1000;
		byte rooms = 1;
		string photoPath = "";
		RealEstateType type = RealEstateType.Apartment;
		// Act
		var dto = new RealEstateDTO(country,province,city,street,house,zip,price,rooms,photoPath,type);
		// Assert
		Assert.Equal(country,dto.Country);
		Assert.Equal(province,dto.Provice);
		Assert.Equal(city,dto.City);
		Assert.Equal(street,dto.Street);
		Assert.Equal(house,dto.HouseNumber);
		Assert.Equal(zip,dto.Zip);
		Assert.Equal(price,dto.Price);
		Assert.Equal(rooms,dto.RoomCount);
		Assert.Equal(photoPath,dto.PhotoFilePath);
		Assert.Equal(type,dto.Type);
		Assert.Null(dto.CreatedAt);
		Assert.Null(dto.Guid);
	}
	[Fact]
	public void ToEntity_ReturnsRealEstate() {
		// Arrange
		var dto = createRealEstateDTO();
		// Act
		var entity = dto.ToEntity();
		// Assert
		Assert.NotNull(entity);
	}
	[Fact]
	public void ToEntity_ReturnsObject() {
		// Arrange
		IDTO dto = createRealEstateDTO();
		// Act
		object entity = dto.ToEntity();
		// Assert
		Assert.NotNull(entity);
	}
	[Fact]
	public void ToEntity_Throws_WhenInvalidData() {
		// Arrange
		var dto = createRealEstateDTO();
		dto.Country = "_"; // invalid country name
		// Act
		Func<RealEstate> act = dto.ToEntity;
		// Assert
		Assert.Throws<FormatException>(act);
	}
	[Fact]
	public void ToString_WorksCorrectly() {
		// Arrange
		var dto = createRealEstateDTO();
		// Act
		string str = dto.ToString();
		// Assert
		Assert.Contains("country",str);
	}
}