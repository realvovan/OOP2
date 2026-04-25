namespace Algorithms.Homework;

static class RungeKutta4thOrder {
	static double F(double x, double y, double dy, double d2y, double d3y) {
		// equation: y'''' = -y''' + 2*y'' - y' + y
		return -d3y + 2 * d2y - dy + y;
	}
 
	static double[] EquationSystem(double x, double[] z) {
		double z1 = z[0]; // y
		double z2 = z[1]; // y'
		double z3 = z[2]; // y''
		double z4 = z[3]; // y'''
 
		return
		[
			z2,                        // z1' = z2
			z3,                        // z2' = z3
			z4,                        // z3' = z4
			F(x, z1, z2, z3, z4)      // z4' = f(x, z1, z2, z3, z4)
		];
	}
 
	static double[] VectorAdd(double[] a, double[] b) {
		double[] result = new double[a.Length];
		for (int i = 0; i < a.Length; i++)
			result[i] = a[i] + b[i];
		return result;
	}
 
	static double[] VectorScale(double[] v, double s) {
		double[] result = new double[v.Length];
		for (int i = 0; i < v.Length; i++)
			result[i] = v[i] * s;
		return result;
	}
 
	// Один крок методу Рунге-Кутта 2-го порядку (метод середньої точки)
	static double[] RK2Step(double x, double[] z, double h) {
		// k1 = h * F(x, z)
		double[] k1 = VectorScale(EquationSystem(x, z), h);
 
		// Середня точка: z + k1/2
		double[] zMid = VectorAdd(z, VectorScale(k1, 0.5));
 
		// k2 = h * F(x + h/2, z + k1/2)
		double[] k2 = VectorScale(EquationSystem(x + h / 2.0, zMid), h);
 
		// z_{n+1} = z_n + k2
		return VectorAdd(z, k2);
	}
 
	// Основний метод розв'язання
	static List<(double x, double[] z)> Solve(
		double x0, double xEnd, double h,
		double y0, double dy0, double d2y0, double d3y0)
	{
		var results = new List<(double x, double[] z)>();
 
		double x = x0;
		double[] z = { y0, dy0, d2y0, d3y0 };
 
		results.Add((x, (double[])z.Clone()));
 
		int steps = (int)Math.Round((xEnd - x0) / h);
 
		for (int i = 0; i < steps; i++) {
			z = RK2Step(x, z, h);
			x += h;
			results.Add((x,(double[])z.Clone()));
		}
 
		return results;
	}
 
	// Виведення результатів у таблиці
	static void PrintResults(List<(double x, double[] z)> results) {
		Console.WriteLine();
		Console.WriteLine("╔══════════╦══════════════╦══════════════╦══════════════╦══════════════╗");
		Console.WriteLine("║    x     ║     y        ║     y'       ║     y''      ║     y'''     ║");
		Console.WriteLine("╠══════════╬══════════════╬══════════════╬══════════════╬══════════════╣");
 
		foreach (var (x, z) in results) {
			Console.WriteLine($"║{x,9:F4} ║{z[0],13:F8} ║{z[1],13:F8} ║{z[2],13:F8} ║{z[3],13:F8} ║");
		}
 
		Console.WriteLine("╚══════════╩══════════════╩══════════════╩══════════════╩══════════════╝");
	}
 
	// Оцінка похибки методом Рунге (подвоєний крок)
	static void EstimateError(
		double x0, double xEnd,
		double y0, double dy0, double d2y0, double d3y0,
		double h)
	{
		var r1 = Solve(x0, xEnd, h,     y0, dy0, d2y0, d3y0);
		var r2 = Solve(x0, xEnd, h / 2, y0, dy0, d2y0, d3y0);
 
		double yH  = r1[r1.Count - 1].z[0];
		double yH2 = r2[r2.Count - 1].z[0];
 
		// Для методу 2-го порядку: похибка ~ (y_h/2 - y_h) / (2^p - 1), p=2
		double error = Math.Abs(yH2 - yH) / (Math.Pow(2, 2) - 1);
		Console.WriteLine($"\n  Оцінка похибки за Рунге (в точці x={xEnd:F4}): {error:E6}");
		Console.WriteLine($"  y(h)   = {yH:F10}");
		Console.WriteLine($"  y(h/2) = {yH2:F10}");
	}

	public static void Run() {
 
		Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
		Console.WriteLine("║   Метод Рунге-Кутта 2-го порядку для ДР 4-го порядку         ║");
		Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");
		Console.WriteLine();
		Console.WriteLine("  Рівняння: y'''' = -y''' + 2y'' - y' + y");
		Console.WriteLine("  (змінюється у функції F у вихідному коді)");
 
		Console.WriteLine();
		Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
		Console.WriteLine("  Введіть параметри (або натисніть Enter для значень за замовч.)");
		Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
 
		double x0    = ReadDouble("  x0  (початок відрізка)         [0]   : ", 0.0);
		double xEnd  = ReadDouble("  xEnd (кінець відрізка)          [1]   : ", 1.0);
		double h     = ReadDouble("  h   (крок)                      [0.1] : ", 0.1);
		double y0    = ReadDouble("  y(x0)   = y0                    [1]   : ", 1.0);
		double dy0   = ReadDouble("  y'(x0)  = dy0                   [0]   : ", 0.0);
		double d2y0  = ReadDouble("  y''(x0) = d2y0                  [0]   : ", 0.0);
		double d3y0  = ReadDouble("  y'''(x0)= d3y0                  [0]   : ", 0.0);
 
		Console.WriteLine();
		Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
		Console.WriteLine("  Результати розв'язання:");
		Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
 
		var results = Solve(x0, xEnd, h, y0, dy0, d2y0, d3y0);
		PrintResults(results);
 
		Console.WriteLine();
		Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
		Console.WriteLine("  Оцінка похибки методом Рунге:");
		EstimateError(x0, xEnd, y0, dy0, d2y0, d3y0, h);
 
		Console.WriteLine();
		Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
	}
 
	static double ReadDouble(string prompt, double defaultVal) {
		Console.Write(prompt);
		string? input = Console.ReadLine()?.Trim();
		if (string.IsNullOrWhiteSpace(input)) {
			Console.CursorTop -= 1;
			Console.Write(prompt + defaultVal);
			Console.WriteLine();
			return defaultVal;
		}
		return double.TryParse(input,System.Globalization.NumberStyles.Any,
							   System.Globalization.CultureInfo.InvariantCulture,
							   out double val) ? val : defaultVal;
	}
}