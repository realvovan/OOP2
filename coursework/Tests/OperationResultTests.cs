using Coursework.BusinessLevel;

namespace Coursework.Tests;

public class OperationResultTests {
	[Fact]
	public void Ok_CreatesSuccessfulResul() {
		// Arrange
		string message = "Operation successful";
		// Act
		var result = Result.Ok(message);
		// Assert
		Assert.True(result.Success);
		Assert.Equal(message,result.Message);
	}
}