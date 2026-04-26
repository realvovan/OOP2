using System.Text.RegularExpressions;

namespace Algorithms.lab8;

static class Test3 {
	const int S0 = 0;
	const int S1 = 1;
	const int S2 = 2;
	const int S3 = 3;
	const int ERR = -1;
	static int[,] transitionTable = {
		// +     digit  A-Z    other
		{  1,    -1,    -1,    -1},
		{  -1,    2,    -1,    -1},
		{  -1,    2,     3,    -1},
		{  -1,   -1,     3,    -1},
	};
	static int getCharType(char c) {
		if (c == '+') return 0;
		if (char.IsDigit(c)) return 1;
		if (c >= 'A' && c <= 'Z') return 2;
		return 3;
	}
	static bool isValid(string input) {
		int state = S0;
		for (int i = 0; i < input.Length; i++) {
			int type = getCharType(input[i]);
			state = transitionTable[state,type];
			if (state == ERR) return false;
		}
		return state == S2 || state == S3;
	}
	public static void Run() {
		var splitRegex = new Regex(@"[ :]+");
		string path = "Part3/words.txt";
		string[] words = splitRegex.Split(File.ReadAllText(path));
		foreach (string word in words) {
			Console.WriteLine($"\"{word}\" is valid: {isValid(word)}");
		}
	}
}