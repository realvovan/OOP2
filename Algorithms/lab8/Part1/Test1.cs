using System.Text.RegularExpressions;

namespace Algorithms.lab8;

static class Test1 {
	public static void Run() {
		var regex = new Regex(@"^\+[0-9]+[0-9A-Z]+$");
		string filePath = "Part1/words.txt";
		foreach (var line in File.ReadAllLines(filePath)) {
			Console.WriteLine($"\"{line}\" is a match: {regex.IsMatch(line)}");
		}
	}
}