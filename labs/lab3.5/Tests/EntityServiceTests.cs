using Xunit;
using Moq;
using lab3_5.BusinessLogic;
using lab3_5.DataAccessLevel.FileRepositories;
using lab3_5.DataAccessLevel.Models;
using lab3_5.BusinessLogic.DTOs;
using System.Runtime.Serialization;

namespace lab3_5.Tests;

public class EntityServiceTests {
	[Fact]
	public void Ctor_SetsFileRepo() {
		var mockRepo = new Mock<IRepository>();
		mockRepo.SetupProperty(r => r.FilePath,"testfile");
		var service = new EntityService(mockRepo.Object);
		Assert.Equal("testfile",service.FilePath);
		Assert.Equal(0,service.PeopleCount);
	}

	[Fact]
	public void FilePath_GetSet_UpdatesUnderlyingRepo() {
		var mockRepo = new Mock<IRepository>();
		mockRepo.SetupProperty(r => r.FilePath,"init");
		var service = new EntityService(mockRepo.Object);

		service.FilePath = "newpath";
		Assert.Equal("newpath",mockRepo.Object.FilePath);
	}

	[Fact]
	public void ChangeRepo_ReplacesRepository() {
		var repo1 = new Mock<IRepository>();
		repo1.SetupProperty(r => r.FilePath,"initfile");
		var repo2 = new Mock<IRepository>();
		repo2.SetupProperty(r => r.FilePath,"newfile");
		var service = new EntityService(repo1.Object);

		service.ChangeRepo(repo2.Object);

		Assert.Equal("newfile",service.FilePath);
	}

	[Fact]
	public void SaveToFile_ReturnsSuccess_WhenOk() {
		var mockRepo = new Mock<IRepository>();
		var service = new EntityService(mockRepo.Object);

		var result = service.SaveToFile();

		Assert.True(result.IsSuccess);
	}

	[Fact]
	public void SaveToFile_ReturnsError_WhenException() {
		var mockRepo = new Mock<IRepository>();
		mockRepo.Setup(r => r.SaveToFile(It.IsAny<List<Person>>())).Throws(new SerializationException("Cannot serialize object"));
		var service = new EntityService(mockRepo.Object);

		var result = service.SaveToFile();

		Assert.False(result.IsSuccess);
		Assert.Contains("Error while saving",result.Message);
	}

	[Fact]
	public void LoadFromFile_SetsPeople_WhenValid() {
		var mockRepo = new Mock<IRepository>();
		mockRepo.Setup(r => r.GetFromFile<Person>())
				.Returns(new List<Person> { new Student("A","B",1,"A1",true,10,2) });
		var service = new EntityService(mockRepo.Object);

		var result = service.LoadFromFile();

		Assert.True(result.IsSuccess);
		Assert.Equal(1,service.PeopleCount);
	}

	[Fact]
	public void LoadFromFile_ReturnsError_WhenNull() {
		var mockRepo = new Mock<IRepository>();
		mockRepo.Setup(r => r.GetFromFile<Person>()).Returns((List<Person>?)null);
		var service = new EntityService(mockRepo.Object);

		var result = service.LoadFromFile();

		Assert.False(result.IsSuccess);
		Assert.Equal("File repository returned null",result.Message);
	}

	[Fact]
	public void LoadFromFile_ReturnsError_WhenException() {
		var mockRepo = new Mock<IRepository>();
		mockRepo.Setup(r => r.GetFromFile<Person>()).Throws(new SerializationException("Cannot deserialize objects"));
		var service = new EntityService(mockRepo.Object);

		var result = service.LoadFromFile();

		Assert.False(result.IsSuccess);
		Assert.Contains("Error while loading",result.Message);
	}

	[Fact]
	public void AddPerson_AddsEntity() {
		var s = new EntityService(new Mock<IRepository>().Object);
		s.AddPerson(new Student("A","B",1,"C1",true,10f,2));
		Assert.Equal(1,s.PeopleCount);
	}

	[Fact]
	public void AddPerson_FromDTO_AddsEntity() {
		var s = new EntityService(new Mock<IRepository>().Object);
		s.AddPerson(new StudentDTO {
			FirstName = "A",
			LastName = "a",
			PassportId = 1,
			IsSportsAHobby = true,
			Year = 2,
			SportsMetric = 50f,
			StudentId = "A1"
		});

		Assert.Equal(1,s.PeopleCount);
	}

	[Fact]
	public void Clear_ClearsList() {
		var s = new EntityService(new Mock<IRepository>().Object);
		s.AddPerson(new Student("A","a",1,"a1",false,100f,2));

		s.Clear();

		Assert.Equal(0,s.PeopleCount);
	}

	[Fact]
	public void RemovePerson_WorksAndFails_WhenExpected() {
		var s = new EntityService(new Mock<IRepository>().Object);
		s.AddPerson(new Student("A","B",1,"C1",true,10f,2));

		Assert.True(s.RemovePerson(0));
		Assert.False(s.RemovePerson(10));
		Assert.False(s.RemovePerson(-1));
	}

	[Fact]
	public void GetYear2StudentsWhoDoSports_ReturnsMatches() {
		var s = new EntityService(new Mock<IRepository>().Object);
		s.AddPerson(new Student("A","B",2,"C1",true,10f,2));
		var result = s.GetYear2StudentsWhoDoSports();

		Assert.Contains("A",result);
	}

	[Fact]
	public void GetYear2StudentsWhoDoSports_ReturnsNone_WhenNoMatch() {
		var s = new EntityService(new Mock<IRepository>().Object);
		s.AddPerson(new Student("A","B",3,"C1",false,10,5));
		Assert.Equal("None",s.GetYear2StudentsWhoDoSports());
	}

	[Fact]
	public void AddTop50StudentsToTeam_SelectsTopHalf() {
		var s = new EntityService(new Mock<IRepository>().Object);
		s.AddPerson(new Student("A","B",1,"C1",true,10,2));
		s.AddPerson(new Student("C","D",1,"C1",true,20,2));
		s.AddTop50StudentsToTeam();

		var info = s.GetTeamMemberInfo();
		Assert.Contains("Sports metrics",info);
	}

	[Fact]
	public void AddTop50StudentsToTeam_EmptyList() {
		var s = new EntityService(new Mock<IRepository>().Object);
		s.AddTop50StudentsToTeam();

		var info = s.GetTeamMemberInfo();
		Assert.Equal("None",info);
	}

	[Fact]
	public void AddTop50StudentsToTeam_OneStudent() {
		var s = new EntityService(new Mock<IRepository>().Object);
		s.AddPerson(new Student("A","B",1,"C1",true,10,2));
		s.AddTop50StudentsToTeam();

		var info = s.GetTeamMemberInfo();
		Assert.Contains("Sports metrics",info);
	}
	

	[Fact]
	public void GetPeopleFullInfo_ReturnsNone_WhenEmpty() {
		var s = new EntityService(new Mock<IRepository>().Object);
		Assert.Equal("None",s.GetPeopleFullInfo());
	}

	[Fact]
	public void GetPeopleFullInfo_ReturnsDetails() {
		var s = new EntityService(new Mock<IRepository>().Object);
		s.AddPerson(new Student("A","B",1,"C1",true,10,2));
		var result = s.GetPeopleFullInfo();
		Assert.Contains("A",result);
	}

	[Fact]
	public void CreateJsonEntityService_ReturnsValidInstance() {
		var s = EntityService.CreateJsonEntityService("abc.json");

		Assert.Equal("abc.json",s.FilePath);
	}
}
