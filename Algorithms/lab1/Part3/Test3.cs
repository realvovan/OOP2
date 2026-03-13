using System.ComponentModel;

namespace Algorithms.lab1;

static class Test3 {
	public static MyList<T> Where<T>(this MyList<T> list,Predicate<T> predicate) {
		var newList = new MyList<T>();
		foreach (var i in list) {
			if (predicate(i)) newList.Add(i);
		}
		return newList;
	}
	public static MyList<T> InsertionSort<T>(this MyList<T> list,bool ascending = true) where T : IComparable<T> {
		var newList = new MyList<T>(list);
		for (int i = 1; i < newList.Count; i++) {
			var value = newList[i];
			int j = i - 1;
			while (j >= 0 && (ascending ? newList[j].CompareTo(value) > 0 : newList[j].CompareTo(value) < 0)) {
				newList[j + 1] = newList[j];
				j--;
			}
			newList[j + 1] = value;
		}
		return newList;
	}
	public static void Run() {
		var rng = new Random();
		int capacity = 10;
		var list1 = new MyList<int>(capacity);
		for (int i = 0; i < capacity; i++) {
			list1.Add(rng.Next(100));
		}
		Console.WriteLine($"List1 after init: {list1}");
		var list2 = new DoubleLinkedList<int>(
			list1.Where(i => i % 2 != 0)
				.InsertionSort(true)
				.ToArray()
		);
		Console.WriteLine($"Second list after removing even numbers and sorting in ascending order:\n{list2}");
	}
}