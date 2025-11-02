namespace Coursework.BusinessLevel;

/// <summary>
/// Class that allows to sort and search an array of any objects
/// </summary>
/// <typeparam name="T">Type of the elements of the array <see cref="Entities"/></typeparam>
public class FilterResult<T>(T[] entities) {
	/// <summary>
	/// Gets or privately sets the elements that can be sorted and searched
	/// </summary>
	public T[] Entities { get; private set; } = entities;
	/// <summary>
	/// Sorts elements of the array and returns the updated <see cref="FilterResult{T}"/> object
	/// </summary>
	/// <typeparam name="TKey">Type of the value to be sorted by</typeparam>
	/// <param name="sortingFunc">Sorting function, which accepts an element of the array and returns the value to sort by</param>
	/// <param name="ascending">Whether the array will be sorted in an ascending or descending order</param>
	public FilterResult<T> SortBy<TKey>(Func<T,TKey> sortingFunc,bool ascending = true) {
		if (ascending) {
			this.Entities = this.Entities
				.OrderBy(sortingFunc)
				.ToArray();
		} else {
			this.Entities = this.Entities
				.OrderByDescending(sortingFunc)
				.ToArray();
		}
		return this;
	}
	/// <summary>
	/// Filters elements of the array and returns the updated <see cref="FilterResult{T}"/> object
	/// </summary>
	/// <param name="searchFunc">Filtering function, which accepts an element of the array
	/// and returns True if the element should be present in the filtered array</param>
	public FilterResult<T> SearchBy(Func<T,bool> searchFunc) {
		this.Entities = this.Entities
			.Where(searchFunc)
			.ToArray();
		return this;
	}
	/// <summary>
	/// Appends the specified array of entities to the current collection
	/// and returns an updated <see cref="FilterResult{T}"/>
	/// </summary>
	/// <param name="entities">The array of entities to append</param>
	public FilterResult<T> Append(T[] entities) {
		this.Entities = [..this.Entities,..entities];
		return this;
	}
	public IEnumerator<T> GetEnumerator() {
		foreach (var i in this.Entities) yield return i;
	}
	public static implicit operator T[](FilterResult<T> instance) => instance.Entities;
}