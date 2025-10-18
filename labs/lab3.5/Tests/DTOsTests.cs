using lab3_5.BusinessLogic.DTOs;
using lab3_5.DataAccessLevel.Models;
using Xunit;

namespace lab3_5.Tests;

public class DTOsTests {
	[Fact]
	public void ToEntity_FiremanDTO_To_Fireman() {
		var dto = new FiremanDTO() {
			FirstName = "A",
			LastName = "a",
			PassportId = 1,
			JobsDone = 12,
			HasJob = true,
		};

		Fireman? fireman = dto.ToEntity() as Fireman;
		
		Assert.NotNull(fireman);
		Assert.Equal("A", fireman.FirstName);
		Assert.Equal("a", fireman.LastName);
		Assert.Equal(1, fireman.PassportId);
		Assert.Equal(12, fireman.JobsDone);
		Assert.True(fireman.HasJob);
	}
	[Fact]
	public void ToEntity_CourierDTO_To_Courier() {
		var expectedTime = DateTime.Now.AddMinutes(5d);
		var startedAt = DateTime.Now;
		var dto = new CourierDTO() {
			FirstName = "A",
			LastName = "a",
			PassportId = 1,
			JobsDone = 12,
			HasJob = true,
			ExpectedDeliveryTime = expectedTime,
			DeliveryStartedAt = startedAt,
		};

		Courier? courier = dto.ToEntity() as Courier;

		Assert.NotNull(courier);
		Assert.Equal("A",courier.FirstName);
		Assert.Equal("a",courier.LastName);
		Assert.Equal(1,courier.PassportId);
		Assert.Equal(12,courier.JobsDone);
		Assert.Equal(expectedTime,courier.ExpectedDeliveryTime);
		Assert.Equal(startedAt,courier.DeliveryStartedAt);
		Assert.True(courier.HasJob);
	}
}
