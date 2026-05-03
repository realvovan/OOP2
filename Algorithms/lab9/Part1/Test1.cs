namespace Algorithms.lab9;

static class Test1 {
	public static void Run() {
		const int n = 10;

		// 9! * 2!
		long result = factorial(n - 1) * factorial(2);

		Console.WriteLine(result);
	}
	static long factorial(int n) {
		long result = 1;
		for (int i = 1; i <= n; i++) {
			result *= i;
		}
		return result;
	}
}