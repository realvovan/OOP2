using Coursework.BusinessLevel;

namespace Coursework.Tests;

public class FilterResultTest {
	[Fact]
	public void Constructor_WorksCorrectly() {
		// Arrange
		int[] data = [1,2,3];
		// Act
		var result = new FilterResult<int>(data);
		// Assert
		Assert.Equal(1,result.Entities[0]);
		Assert.Equal(2,result.Entities[1]);
		Assert.Equal(3,result.Entities[2]);
	}
	[Theory]
	[InlineData(new int[] { 3,1,2 },true,new int[] { 1,2,3 })]
	[InlineData(new int[] { 3,1,2 },false,new int[] { 3,2,1 })]
	public void SortBy_WorksProperly(int[] input,bool isAscending,int[] output) {
		// Arrange
		var filterResult = new FilterResult<int>(input);
		// Act
		filterResult = filterResult.SortBy(x => x,isAscending);
		// Assert
		Assert.Equal(output,filterResult.Entities);
	}
	[Fact]
	public void SearchBy_WorkProperly() {
		// Arrange
		var filterResult = new FilterResult<int>([1,2,3]);
		// Act
		filterResult = filterResult.SearchBy(x => x == 2);
		// Assert
		Assert.Equal([2],filterResult.Entities);
	}
	[Fact]
	public void Append_WorksProperly() {
		// Arrange
		var filterResult = new FilterResult<int>([1,2,3]);
		int[] toAppend = [4,5,6];
		// Act
		filterResult = filterResult.Append(toAppend);
		// Assert
		Assert.Equal([1,2,3,4,5,6],filterResult.Entities);
	}
	[Fact]
	public void GetEnumerator_WorksProperly() {
		// Arrange
		int[] input = [1,2,3];
		var filterResult = new FilterResult<int>(input);
		var output = new List<int>();
		// Act
		foreach (var i in filterResult) {
			output.Add(i);
		}
		// Assert
		Assert.Equal(input,output.ToArray());
	}
	[Fact]
	public void ImplicitOperatorT_WorksProperly() {
		// Arrange
		var filterResult = new FilterResult<int>([1,2,3]);
		// Act
		int[] output = filterResult;
		// Assert
		Assert.Equal(filterResult.Entities,output);
	}
}