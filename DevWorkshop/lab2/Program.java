package DevWorkshop.lab2;

import java.util.Scanner;

public class Program {
	static int getIntFromInput(Scanner scanner,String prompt) {
		System.out.print(prompt);
		while (true) {
			try {
				int input = scanner.nextInt();
				scanner.nextLine();
				return input;
			} catch(Exception _) {
				System.out.println("Invalid input, please try again!");
			}
		}
	}
	public static void main(String[] args) {
		var scanner = new Scanner(System.in);
		// 123 -> 321
		int input = getIntFromInput(scanner, "Please enter an integer: ");
		System.out.print("%d -> ".formatted(input));
		int result = 0;
		while (input != 0) {
			int digit = input % 10;
			result = result * 10 + digit;
			input /= 10;
		}
		System.out.println(result);
	}
}
