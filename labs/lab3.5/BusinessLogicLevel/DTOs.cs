using lab3_5.DataAccessLevel.Models;

namespace lab3_5.BusinessLogic.DTOs;

public abstract class PersonDTO {
	public string FirstName = "John";
	public string LastName = "Doe";
	public int PassportId;
	public abstract Person ToEntity();
}

public class StudentDTO : PersonDTO {
	public string StudentId = "AB12345678";
	public bool IsSportsAHobby;
	public int Year;
	public float SportsMetric;
	public override Person ToEntity() => new Student(
		this.FirstName,
		this.LastName,
		this.PassportId,
		this.StudentId,
		this.IsSportsAHobby,
		this.SportsMetric,
		this.Year
	);
}

public class FiremanDTO : PersonDTO {
	public bool HasJob;
	public int JobsDone;
	public override Person ToEntity() => new Fireman(
		this.FirstName,
		this.LastName,
		this.PassportId,
		this.HasJob,
		this.JobsDone
	);
}

public class CourierDTO : PersonDTO {
	public bool HasJob;
	public int JobsDone;
	public DateTime? ExpectedDeliveryTime;
	public DateTime? DeliveryStartedAt;
	public override Person ToEntity() => new Courier(
		this.FirstName,
		this.LastName,
		this.PassportId,
		this.HasJob,
		this.JobsDone,
		this.ExpectedDeliveryTime,
		this.DeliveryStartedAt
	);
}