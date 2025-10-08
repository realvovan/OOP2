using DataAccessLevel.Models;

namespace BusinessLogicLevel.DTOs;

public class PersonDTO {
	public string FirstName = string.Empty;
	public string LastName = string.Empty;
	public virtual Person ToEntity() {
		return new Person(this.FirstName,this.LastName);
	}
}

public class StudentDTO : PersonDTO {
	public string StudentId = string.Empty;
	public int Year = 1;
	public int IdentificationCode = 0;
	public bool IsSportsAHobby = false;
	public override Person ToEntity() {
		return new Student(this.FirstName,this.LastName,this.StudentId,this.Year,this.IdentificationCode,this.IsSportsAHobby);
	}
}

public class FiremanDTO : PersonDTO {
	public bool HasJob = false;
	public int JobsDone = 0;
	public override Person ToEntity() {
		return new Fireman(this.FirstName,this.LastName,this.JobsDone) { HasJob = this.HasJob };
	}
}

public class CourierDTO : PersonDTO {
	public bool IsFree = true;
	public int OrdersDelivered = 0;
	public override Person ToEntity() {
		return new Courier(this.FirstName,this.LastName,this.OrdersDelivered) { IsFree = this.IsFree };
	}
}
