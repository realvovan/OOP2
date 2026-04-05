using System.Diagnostics;
using static Algorithms.lab6.Helper;

namespace Algorithms.lab6;

static class Test3 {
	static int[] getSorted(int size) {
		int[] arr = new int[size];
		for (int i = 0; i < size; i++) arr[i] = i;
		return arr;
	}
	static int[] getReversed(int size) {
		int[] arr = new int[size];
		for (int i = 0; i < size; i++) arr[i] = size - i;
		return arr;
	}
	static long measure(Action<int[]> sortAction,int[] original) {
		int[] arr = original.ToArray();
		var stopwatch = Stopwatch.StartNew();
		sortAction(arr);
		stopwatch.Stop();
		return stopwatch.ElapsedMilliseconds;
	}
	static void testCase(string name,int[] arr,StreamWriter writer) {
		long bottomUp = measure(BottomUpMergeSort,arr);
		long topDown = measure(TopDownMergeSort,arr);

		Console.WriteLine($"{name}: bottom-up: {bottomUp}, top-down: {topDown}");
		writer.WriteLine($"{name},{bottomUp},{topDown}");
	}

	public static void Run() {
		const int SIZE = 100_000;
		int[] sorted = getSorted(SIZE);
		int[] reversed = getReversed(SIZE);

		using var writer = new StreamWriter("test3result.csv");
		writer.WriteLineAsync("Case,BottomUp,TopDown");

		testCase("Sorted",sorted,writer);
		testCase("Reversed",reversed,writer);
	}
}