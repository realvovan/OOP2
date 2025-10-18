using lab3_5.BusinessLogic;

namespace lab3_5.PresentationLevel;

static class Program {
	static void Main() {
		var entityService = EntityService.CreateJsonEntityService("People.json");
		/*entityService.AddPerson(new StudentDTO {
			FirstName = "Vova",
			LastName = "Hordiienko",
			Year = 2,
			IsSportsAHobby = true,
			PassportId = 1234,
			StudentId = "KX12345677",
			SportsMetric = 95f
		});
		entityService.AddPerson(new StudentDTO {
			FirstName = "john",
			LastName = "doe",
			Year = 4,
			IsSportsAHobby = true,
			PassportId = 5315125,
			StudentId = "GD35325132",
			SportsMetric = 54f
		});
		entityService.AddPerson(new StudentDTO {
			FirstName = "Jane",
			LastName = "doe",
			Year = 2,
			IsSportsAHobby = false,
			PassportId = 432142,
			StudentId = "AC42421413",
			SportsMetric = 21f
		});
		entityService.AddPerson(new StudentDTO {
			FirstName = "oleg",
			LastName = "avramenko",
			Year = 2,
			IsSportsAHobby = true,
			PassportId = 3213,
			StudentId = "PO234214",
			SportsMetric = 89f
		});
		entityService.AddPerson(new FiremanDTO {
			FirstName = "Mister",
			LastName = "Firefighter",
			PassportId = 987654,
			JobsDone = 21,
			HasJob = false
		});
		entityService.AddPerson(new CourierDTO {
			FirstName = "Missus",
			LastName = "Delivery",
			PassportId = 645732,
			HasJob = false,
			JobsDone = 12,
			ExpectedDeliveryTime = null,
			DeliveryStartedAt = null,
		});
		entityService.SaveToFile();*/
		var result = entityService.LoadFromFile();
		if (!result.IsSuccess) throw new Exception(result.Message);
		Console.WriteLine("Year two students who also do sports:");
		Console.WriteLine(entityService.GetYear2StudentsWhoDoSports());
		entityService.AddTop50StudentsToTeam();
		Console.WriteLine("Team members");
		Console.WriteLine(entityService.GetTeamMemberInfo());
	}
}