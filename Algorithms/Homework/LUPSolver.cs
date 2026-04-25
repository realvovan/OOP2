namespace Algorithms.Homework;

class LupSolver
{
	static int n;

	static int[] LUPDecompose(double[,] A) {
		int[] pi = new int[n];
		for (int i = 0; i < n; i++) pi[i] = i;
 
		for (int k = 0; k < n; k++) {
			// Searching for the greatest element in column k
			double maxVal = 0;
			int kPrime = k;
			for (int i = k; i < n; i++) {
				if (Math.Abs(A[i, k]) > maxVal) {
					maxVal = Math.Abs(A[i, k]);
					kPrime = i;
				}
			}
 
			if (maxVal == 0) throw new Exception("Singular matrix (det(A) = 0). Cannot solve equation");
 
			(pi[k], pi[kPrime]) = (pi[kPrime], pi[k]);
			for (int i = 0; i < n; i++)
				(A[k, i], A[kPrime, i]) = (A[kPrime, i], A[k, i]);
 
			// Gaussian elimination
			for (int i = k + 1; i < n; i++) {
				A[i, k] /= A[k, k];
				for (int j = k + 1; j < n; j++)
					A[i, j] -= A[i, k] * A[k, j];
			}
		}
 
		return pi;
	}
	static double[] LUPSolve(double[,] LU, int[] pi, double[] b) {
		double[] x = new double[n];
		double[] y = new double[n];
 
		// Direct substitution
		for (int i = 0; i < n; i++) {
			y[i] = b[pi[i]];
			for (int j = 0; j < i; j++)
				y[i] -= LU[i, j] * y[j];
		}
 
		// Backwards sub
		for (int i = n - 1; i >= 0; i--) {
			x[i] = y[i];
			for (int j = i + 1; j < n; j++)
				x[i] -= LU[i, j] * x[j];
			x[i] /= LU[i, i];
		}
 
		return x;
	}
 
	static void PrintLU(double[,] LU) {
		Console.WriteLine("\n=== Матриця L ===");
		for (int i = 0; i < n; i++) {
			for (int j = 0; j < n; j++) {
				double val = (j < i) ? LU[i, j] : (i == j ? 1.0 : 0.0);
				Console.Write($"{val,10:F4}");
			}
			Console.WriteLine();
		}
 
		Console.WriteLine("\n=== Матриця U ===");
		for (int i = 0; i < n; i++) {
			for (int j = 0; j < n; j++) {
				double val = (j >= i) ? LU[i, j] : 0.0;
				Console.Write($"{val,10:F4}");
			}
			Console.WriteLine();
		}
	}
 
	static void Verify(double[,] A_orig, double[] x, double[] b)
	{
		Console.WriteLine("\n=== Verifying A*x == b ===");
		double maxError = 0;
		for (int i = 0; i < n; i++) {
			double sum = 0;
			for (int j = 0; j < n; j++)
				sum += A_orig[i, j] * x[j];
			double error = Math.Abs(sum - b[i]);
			if (error > maxError) maxError = error;
			Console.WriteLine($"Row {i + 1}: {sum,10:F6}  (expected {b[i],10:F6})  error = {error:E2}");
		}
		Console.WriteLine($"\nMax absolute error: {maxError:E4}");
	}
 
	static void Main() {
		Console.WriteLine(@"
Given a system:
	-x₁ + 2x₂ - 5x₃ -  x₄ = -14
	6x₁ + 2x₂ - 7x₃ + 2x₄ = -49
	6x₁ + 4x₂ + 8x₃ + 5x₄ =  37
	-8x₁ + 9x₂ - 5x₃ - 2x₄ =  61
");
 
		n = 4;
 
		double[,] A_orig = {
			{ -1,  2, -5, -1 },
			{  6,  2, -7,  2 },
			{  6,  4,  8,  5 },
			{ -8,  9, -5, -2 }
		};
 
		// Copy of the matrix because the algorithm changes it
		double[,] A = (double[,])A_orig.Clone();
 
		double[] b = [ -14, -49, 37, 61 ];
 
		Console.WriteLine("=== Step 1: LUP-decomposition ===");
		int[] pi = LUPDecompose(A);
 
		Console.Write("Permutation vector Pi = [ ");
		foreach (int p in pi) Console.Write($"{p + 1} ");
		Console.WriteLine("]");
 
		PrintLU(A);
 
		Console.WriteLine("\n=== Step 2: Solving the system ===");
		double[] x = LUPSolve(A, pi, b);
 
		for (int i = 0; i < n; i++)
			Console.WriteLine($"x{i + 1} = {x[i],12:F6}");
 
		Verify(A_orig, x, b);
	}
}