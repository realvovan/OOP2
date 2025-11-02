using Coursework.BusinessLevel.DTOs;
using Coursework.BusinessLevel.Services;
using Coursework.Commons.Enums;
using Coursework.DataLevel.Entities;

namespace Coursework.Tests;

public class ClientServiceTest {
	[Fact]
	public void AddSuggestion_ReturnsFail_WhenClientNotFound() {
		// Arrange
		var service = new ClientService();
		var reService = new RealEstateService();

		// Act
		var result = service.AddSuggestion(Guid.NewGuid(),Guid.NewGuid(),reService);

		// Assert
		Assert.False(result.Success);
		Assert.Equal("Client with given Guid does not exist",result.Message);
	}

	[Fact]
	public void AddSuggestion_ReturnsFail_WhenRealEstateNotFound() {
		// Arrange
		var clientId = Guid.NewGuid();
		var dict = new Dictionary<Guid,Client> { { clientId,new(
			"A","a","a@gmail.com","099123456789","012345678","UA123",1,1,[]
		) } };
		var service = new ClientService(dict);
		var reService = new RealEstateService();

		// Act
		var result = service.AddSuggestion(clientId,Guid.NewGuid(),reService);

		// Assert
		Assert.False(result.Success);
		Assert.Equal("Real estate with given Guid does not exist",result.Message);
	}

	[Fact]
	public void AddSuggestion_ReturnsFail_WhenClientThrowsException() {
		// Arrange
		var clientId = Guid.NewGuid();
		var clientDict = new Dictionary<Guid,Client> { { clientId,new(
			"A","a","a@gmail.com","099123456789","012345678","UA123",1,1,Enumerable.Repeat(Guid.Empty,5).ToList()
		) } };
		var estateId = Guid.NewGuid();
		var estateDict = new Dictionary<Guid,RealEstate> { { estateId,new(
			"B","b","city","street","1","03200",1,1,RealEstateType.House
		) } };
		var service = new ClientService(clientDict);
		var reService = new RealEstateService(estateDict);

		// Act
		var result = service.AddSuggestion(clientId,estateId,reService);

		// Assert
		Assert.False(result.Success);
	}

	[Fact]
	public void AddSuggestion_ReturnsSuccess_WhenValid() {
		// Arrange
		var clientId = Guid.NewGuid();
		var clientDict = new Dictionary<Guid,Client> { { clientId,new(
			"A","a","a@gmail.com","099123456789","012345678","UA123",1,1,[]
		) } };
		var estateId = Guid.NewGuid();
		var estateDict = new Dictionary<Guid,RealEstate> { { estateId,new(
			"B","b","city","street","1","03200",1,1,RealEstateType.House
		) } };
		var service = new ClientService(clientDict);
		var reService = new RealEstateService(estateDict);

		// Act
		var result = service.AddSuggestion(clientId,estateId,reService);

		// Assert
		Assert.True(result.Success);
		Assert.Empty(result.Message);
	}

	[Fact]
	public void RemoveSuggestion_ReturnsFail_WhenClientNotFound() {
		// Arrange
		var service = new ClientService();

		// Act
		var result = service.RemoveSuggestion(Guid.NewGuid(),Guid.NewGuid());

		// Assert
		Assert.False(result.Success);
		Assert.Equal("Client with given Guid does not exist",result.Message);
	}

	[Fact]
	public void RemoveSuggestion_ReturnsFail_WhenObjectNotFound() {
		// Arrange
		var clientId = Guid.NewGuid();
		var clientDict = new Dictionary<Guid,Client> { { clientId,new(
			"A","a","a@gmail.com","099123456789","012345678","UA123",1,1,[]
		) } };
		var service = new ClientService(clientDict);

		// Act
		var result = service.RemoveSuggestion(clientId,Guid.NewGuid());

		// Assert
		Assert.False(result.Success);
		Assert.Equal("Could not find object with a given Guid",result.Message);
	}

	[Fact]
	public void RemoveSuggestion_ReturnsSuccess_WhenObjectRemoved() {
		// Arrange
		var estateId = Guid.NewGuid();
		var estateDict = new Dictionary<Guid,RealEstate> { { estateId,new(
			"B","b","city","street","1","03200",1d,1,RealEstateType.House
		) } };
		var clientId = Guid.NewGuid();
		var clientDict = new Dictionary<Guid,Client> { { clientId,new(
			"A","a","a@gmail.com","099123456789","012345678","UA123",1,1,[estateId]
		) } };
		var service = new ClientService(clientDict);
		var reService = new RealEstateService(estateDict);

		// Act
		var result = service.RemoveSuggestion(clientId,estateId);

		// Assert
		Assert.True(result.Success);
		Assert.Empty(result.Message);
	}

	[Fact]
	public void GetNumberOfSuggestions_ReturnsMinusOne_WhenClientNotFound() {
		// Arrange
		var service = new ClientService();

		// Act
		int count = service.GetNumberOfSuggestions(Guid.NewGuid());

		// Assert
		Assert.Equal(-1,count);
	}

	[Fact]
	public void GetNumberOfSuggestions_ReturnsCount_WhenClientFound() {
		// Arrange
		var clientId = Guid.NewGuid();
		var clientDict = new Dictionary<Guid,Client> { { clientId,new(
			"A","a","a@gmail.com","099123456789","012345678","UA123",1,1,[]
		) } };
		var service = new ClientService(clientDict);

		// Act
		int count = service.GetNumberOfSuggestions(clientId);

		// Assert
		Assert.Equal(0,count);
	}

	[Fact]
	public void Constructors_WorkCorrectly() {
		// Arrange
		var clients = new Dictionary<Guid,Client>();
		var clientsDto = new Dictionary<Guid,ClientDTO> { { Guid.NewGuid(),new(
			"A","a","a@gmail.com","099123456789","012345678","UA123",1,1,"",[]
		) } };
		// Act
		var s1 = new ClientService();
		var s2 = new ClientService(clients);
		var s3 = new ClientService(clientsDto);

		// Assert
		Assert.NotNull(s1);
		Assert.NotNull(s2);
		Assert.NotNull(s3);
	}
}