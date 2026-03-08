package DevWorkshop.lab2;

public class Program {
	public static void main(String[] args) throws Exception {
		if (args.length == 0) throw new Exception("Invalid arguments");
		String argument = args[0];
		switch (argument.toLowerCase()) {
			case "test1":
				Part1.run();
				break;
			case "test2":
				Part2.run();
				break;
			default:
				throw new Exception("Invalid argument");
		}
	}
}
