using lab3_5.DataAccessLevel.Models;
using Xunit;

namespace lab3_5.Tests;

public class EntityTests {
	[Fact]
	public void Student_Ctor_NoParams_SetsValuesToDefault() {
		var student = new Student();

		Assert.Equal("NA",student.FirstName);
		Assert.Equal("NA",student.LastName);
		Assert.Equal(-1,student.PassportId);
		Assert.Equal("NA",student.StudentId);
		Assert.Equal(-1f,student.SportsMetric);
		Assert.Equal(-1,student.Year);
		Assert.False(student.IsSportsAHobby);
	}
	[Fact]
	public void Student_IncreaseYear_ShouldIncrease_WhenValidYear() {
		var student = new Student { Year = 1 };

		student.IncreaseYear();

		Assert.Equal(2,student.Year);
	}
	[Fact]
	public void Student_IncreaseYear_Throws_WhenInvalidYear() {
		var student = new Student { Year = 6 };

		var e = Assert.Throws<InvalidOperationException>(student.IncreaseYear);

		Assert.Equal("Student is on the last year",e.Message);
	}
	[Fact]
	public void Courier_Ctor_NoParams_SetsValuesToDefault() {
		var courier = new Courier();

		Assert.Equal("NA",courier.FirstName);
		Assert.Equal("NA",courier.LastName);
		Assert.Equal(-1,courier.PassportId);
		Assert.Equal(-1,courier.JobsDone);
		Assert.False(courier.HasJob);
		Assert.Null(courier.ExpectedDeliveryTime);
		Assert.Null(courier.DeliveryStartedAt);
	}
	[Fact]
	public void Courier_Play_ShouldOutputToConsole() {
		using var writer = new StringWriter();
		var courier = new Courier();
		Console.SetOut(writer);

		courier.Play();

		Assert.Equal("Playing guitar",writer.ToString().Trim());
	}
	[Fact]
	public void Courier_StartJob_Throws_WhenHasJobIsTrue() {
		var courier = new Courier { HasJob = true };

		var e = Assert.Throws<Exception>(() => courier.StartJob(1f));

		Assert.Equal("Already has a job",e.Message);
	}
	[Fact]
	public void Courier_StartJob_Throws_WhenNegativeParam() {
		var courier = new Courier();

		var e = Assert.Throws<ArgumentException>(() => courier.StartJob(-1));

		Assert.Contains("Expected time cannot be negative or zero",e.Message);
		Assert.Equal("expectedDeliveryInMinutes",e.ParamName);
	}
	[Fact]
	public void Courier_StartJob_Works() {
		double expectedTime = 5;
		var courier = new Courier();
		var now = DateTime.Now;
		var expected = now.AddMinutes(expectedTime);

		courier.StartJob(expectedTime);

		Assert.True(courier.HasJob);
		Assert.NotNull(courier.DeliveryStartedAt);
		Assert.NotNull(courier.ExpectedDeliveryTime);
		Assert.InRange((DateTime)courier.DeliveryStartedAt,now.AddSeconds(-2),now.AddSeconds(2));
		Assert.InRange((DateTime)courier.ExpectedDeliveryTime,expected.AddSeconds(-2),expected.AddSeconds(2));
	}
	[Fact]
	public void Courier_FinishJob_Works() {
		var courier = new Courier {
			HasJob = true,
			DeliveryStartedAt = DateTime.Now,
			ExpectedDeliveryTime = DateTime.Now,
		};

		courier.FinishJob();

		Assert.False(courier.HasJob);
		Assert.Null(courier.DeliveryStartedAt);
		Assert.Null(courier.ExpectedDeliveryTime);
	}
	[Fact]
	public void Courier_FinishJob_Throws_WhenHasJobIsFalse() {
		var courier = new Courier {
			HasJob = false,
		};

		var e = Assert.Throws<Exception>(courier.FinishJob);

		Assert.Equal("Courier has no job",e.Message);
	}
	[Fact]
	public void Courier_GetElapsedJobTime_ReturnsNeg1() {
		var courier = new Courier {
			DeliveryStartedAt = null
		};

		var result = courier.GetElapsedJobTime();

		Assert.Equal(new TimeSpan(-1),result);
	}
	[Fact]
	public void Courier_GetElapsedJobTime_ReturnsTime() {
		var courier = new Courier {
			DeliveryStartedAt = DateTime.Now.AddSeconds(-5)
		};

		var result = courier.GetElapsedJobTime();

		Assert.InRange(result.TotalSeconds,4,6);
	}
	[Fact]
	public void Courier_GetDeliverEstimate_ReturnsNeg1() {
		var courier = new Courier {
			ExpectedDeliveryTime = null
		};

		var result = courier.GetDeliveryEstimate();

		Assert.Equal(new TimeSpan(-1),result);
	}
	[Fact]
	public void Courier_GetDeliverEstimate_ReturnsTime() {
		var courier = new Courier {
			ExpectedDeliveryTime = DateTime.Now.AddSeconds(5)
		};

		var result = courier.GetDeliveryEstimate();

		Assert.InRange(result.TotalSeconds,4,6);
	}
}