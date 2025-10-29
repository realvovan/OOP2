using System.Collections;
using Coursework.BusinessLevel.DTOs;

namespace Coursework.BusinessLevel;

/// <summary>
/// Class that allows to sort and search in an array of objects of type T
/// </summary>
public class FilterResult<T>(T[] entities) {
	public T[] Entities { get; private set; } = entities;
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
	public FilterResult<T> SearchBy(Func<T,bool> searchFunc) {
		this.Entities = this.Entities
			.Where(searchFunc)
			.ToArray();
		return this;
	}
	public IEnumerator<T> GetEnumerator() {
		foreach (var i in this.Entities) yield return i;
	}
	public static implicit operator T[](FilterResult<T> instance) => instance.Entities;
}