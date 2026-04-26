namespace Algorithms.lab8;

static class Test2 {
	//+\d+[A-Z]*
	enum States {
			S0,
			S1,
			S2,
			S3,
			ERR
	}
	static bool isValud(string? input) {
		if (input is null) return false;
		var state = States.S0;
		foreach (char c in input) {
			switch (state) {
				case States.S0:
					if (c == '+') state = States.S1;
					else state = States.ERR;
					break;
				case States.S1:
					if (char.IsDigit(c)) state = States.S2;
					else state = States.ERR;
					break;
				case States.S2:
					if (char.IsDigit(c)) state = States.S2;
					else if (c >= 'A' && c <= 'Z') state = States.S3;
					else state = States.ERR;
					break;
				case States.S3:
					if (c >= 'A' && c <= 'Z') state = States.S3;
					else state = States.ERR;
					break;
				default:
					return false;
			}
			if (state == States.ERR) return false;
		}
		if (state == States.S2 || state == States.S3) return true;
		return false;
	}
	public static void Run() {
		while (true) {
			string? input = Console.ReadLine();
			Console.WriteLine($"\"{input}\" is a match: {isValud(input)}");
		}
	}
}
