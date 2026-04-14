namespace Algorithms.lab7;

static class Test3 {
	static double f(double x,double y) {
		return 1.0 / (2 * x - y * y);
	}
	static void rungeKutta2(double x0,double y0,double h,int steps) {
		double x = x0;
		double y = y0;

		Console.WriteLine("x\t\ty");

		for (int i = 0; i <= steps; i++) {
			Console.WriteLine($"{x:F3}\t{y:F6}");

			double k1 = f(x, y);
			double k2 = f(x + h, y + h * k1);

			y = y + h * (k1 + k2) / 2.0;

			x += h;
		}
	}
	public static void Run() {
		double x0 = 1d;
		double y0 = 1d;

		double h = 0.1;
		int steps = 20;

		rungeKutta2(x0,y0,h,steps);
	}
}