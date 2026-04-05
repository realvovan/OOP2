using System.Diagnostics;
using static Algorithms.lab6.Helper;

namespace Algorithms.lab6;

static class Test2 {
	public static void Run() {
		const int N = 100;
		int[] sizes = [
			N,
			N * N,
			N * N * N
		];

		using var writer = new StreamWriter("test2result.csv");
		writer.WriteLine("Size,BottomUp,TopDown");

		foreach (int size in sizes) {
			int[] arr1 = GetRandomArray(size);
			var sw1 = Stopwatch.StartNew();
			BottomUpMergeSort(arr1);
			sw1.Stop();
			
			int[] arr2 = arr1.ToArray();
			var sw2 = Stopwatch.StartNew();
			TopDownMergeSort(arr2);
			sw2.Stop();

			Console.WriteLine($"Size: {size}, bottom-up: {sw1.ElapsedMilliseconds}, top-down: {sw2.ElapsedMilliseconds}");
			writer.WriteLine($"{size},{sw1.ElapsedMilliseconds},{sw2.ElapsedMilliseconds}");
		}
	}
}