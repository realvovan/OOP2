using System.Runtime.Serialization;
using Coursework.BusinessLevel.DTOs;
using Coursework.BusinessLevel.Services;
using Coursework.DataLevel.DataProviders;
using Coursework.DataLevel.Entities;
using Moq;

namespace Coursework.Tests;

public class BaseEntityServiceTests {
	[Fact]
	public void Constructor_LogsWarning_WhenInvalidData() {
		// Arrange
		using var writer = new StringWriter();
		var dict = new Dictionary<Guid,ClientDTO> { { Guid.NewGuid(),new(
			"","","","","","",0,0,"",[]
		) } };
		Console.SetOut(writer);
		// Act
		var service = new BaseEntityService<Client,ClientDTO>(dict,ClientDTO.FromClient);
		// Assert
		Assert.Contains("[Warning]",writer.ToString());
	}
	[Fact]
	public void AddEntity_ReturnsSuccess() {
		// Arrange
		var service = new BaseEntityService<Client,ClientDTO>(ClientDTO.FromClient);
		var toAdd = new ClientDTO("A","a","email@gmail.com","0991234567","012345678","UA123",1,1,"",[]);
		// Act
		var result = service.AddEntity(toAdd);
		// Assert
		Assert.True(result.Success);
		Assert.Equal(1,service.Count);
	}
	[Fact]
	public void AddEntity_ReturnsNotSuccess_WhenInvalidData() {
		// Arrange
		var service = new BaseEntityService<Client,ClientDTO>(ClientDTO.FromClient);
		var toAdd = new ClientDTO("","","","","","",0,0,"",[]);
		// Act
		var result = service.AddEntity(toAdd);
		// Assert
		Assert.False(result.Success);
	}
	[Fact]
	public void RemoveEntity_ReturnsSuccess() {
		// Arrange
		var clientId = Guid.NewGuid();
		var dict = new Dictionary<Guid,Client> { { clientId,new(
			"A","a","email@gmail.com","0991234567","012345678","UA123",1,1,[]
		) } };
		var serivce = new BaseEntityService<Client,ClientDTO>(dict,ClientDTO.FromClient);
		// Act
		var result = serivce.RemoveEntity(clientId);
		// Assert
		Assert.True(result.Success);
		Assert.Equal(0,serivce.Count);
	}
	[Fact]
	public void RemoveEntity_ReturnsNotSuccess_WhenNonExistantEntity() {
		// Arrange
		var service = new BaseEntityService<Client,ClientDTO>(ClientDTO.FromClient);
		// Act
		var result = service.RemoveEntity(Guid.NewGuid());
		// Assert
		Assert.False(result.Success);
	}
	[Fact]
	public void LoadEntitiesFromFile_Loads_FromIDataProvider() {
		// Arrange
		var mockRepo = new Mock<IDataProvider>();
		mockRepo.Setup(n => n.LoadFromFile<Dictionary<Guid,Client>>())
			.Returns(new Dictionary<Guid,Client> { { Guid.NewGuid(),new(
				"A","a","email@gmail.com","0991234567","012345678","UA123",1,1,[]
			) } });
		var service = new BaseEntityService<Client,ClientDTO>(ClientDTO.FromClient);
		// Act
		var result = service.LoadEntitiesFromFile(mockRepo.Object);
		// Assert
		Assert.True(result.Success);
		Assert.Equal(1,service.Count);
	}
	[Fact]
	public void LoadEntitiesFromFile_ReturnsNull() {
		// Arrange
		var mockRepo = new Mock<IDataProvider>();
		mockRepo.Setup(n => n.LoadFromFile<Dictionary<Guid,Client>>())
			.Returns((Dictionary<Guid,Client>?)null);
		var serivce = new BaseEntityService<Client,ClientDTO>(ClientDTO.FromClient);
		// Act
		var result = serivce.LoadEntitiesFromFile(mockRepo.Object);
		// Assert
		Assert.False(result.Success);
	}
	[Fact]
	public void LoadEntitiesFromFile_ReturnsError_WhenException() {
		// Arrange
		var exception = new SerializationException("Error while deserializing objects");
		var mockRepo = new Mock<IDataProvider>();
		mockRepo.Setup(n => n.LoadFromFile<Dictionary<Guid,Client>>())
			.Throws(exception);
		var serivce = new BaseEntityService<Client,ClientDTO>(ClientDTO.FromClient);
		// Act
		var result = serivce.LoadEntitiesFromFile(mockRepo.Object);
		// Assert
		Assert.False(result.Success);
		Assert.Contains(exception.Message,result.Message);
	}
}