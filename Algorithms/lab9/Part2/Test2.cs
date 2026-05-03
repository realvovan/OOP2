namespace Algorithms.lab9;

static class Test2 {
	public static void Run() {
		int[] digits = [0,2,4,6];
		var numbers = new List<string>();

		foreach (int d1 in digits) {
			if (d1 == 0) continue;
			foreach (int d2 in digits) {
				foreach (int d3 in digits) {
					numbers.Add($"{d1}{d2}{d3}");
				}
			}
		}

		Console.WriteLine(numbers.Count);
	}
}