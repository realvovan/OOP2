namespace Algorithms.lab9;

static class Test3 {
	public static void Run() {
		const int n = 10;
		const int A = 1;
		const int B = 2;

		var others = new List<int>();
		for (int i = 1; i <= n; i++) {
			if (i != A && i != B) others.Add(i);
		}

		using var writer = new StreamWriter("permutations.txt");
		GeneratePermutations(others, 0, perm => {
			// Для кожної перестановки вставляємо блок
			for (int pos = 0; pos <= perm.Count; pos++) {
				// варіант A B
				var list1 = new List<int>(perm);
				list1.Insert(pos, A);
				list1.Insert(pos + 1, B);
				writer.WriteLine(string.Join(" ", list1));
				// варіант B A
				var list2 = new List<int>(perm);
				list2.Insert(pos, B);
				list2.Insert(pos + 1, A);
				writer.WriteLine(string.Join(" ", list2));
			}
		});

		Console.WriteLine("done!");
	}

	static void GeneratePermutations(List<int> list, int start, Action<List<int>> action) {
		if (start == list.Count) {
			action(new List<int>(list));
			return;
		}

		for (int i = start; i < list.Count; i++) {
			swap(list,start,i);
			GeneratePermutations(list,start + 1,action);
			swap(list,start,i);
		}
	}

	static void swap(List<int> list, int i, int j) => (list[j],list[i]) = (list[i],list[j]);
}