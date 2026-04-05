using System.Diagnostics;
using static Algorithms.lab6.Helper;

namespace Algorithms.lab6;

static class Test1 {
	public static void Run() {
		const int N = 100;
		int[] sizes = [
			N,
			N * N,
			N * N * N
		];
		using var writer = new StreamWriter("test1result.csv");
		writer.WriteLine("Size,Time");
		foreach (int size in sizes) {
			int[] array = GetRandomArray(size);
			var stopwatch = Stopwatch.StartNew();
			BottomUpMergeSort(array);
			stopwatch.Stop();
			Console.WriteLine($"Size: {size}, time: {stopwatch.ElapsedMilliseconds} ms");
			writer.WriteLine($"{size},{stopwatch.ElapsedMilliseconds}");
		}
	}
}