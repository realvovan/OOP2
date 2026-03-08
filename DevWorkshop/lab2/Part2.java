package DevWorkshop.lab2;

import java.util.Scanner;

public class Part2 {
	static int getIntFromInput(Scanner scanner,String prompt) {
		System.out.print(prompt);
		while (true) {
			try {
				int input = scanner.nextInt();
				scanner.nextLine();
				return input;
			} catch(Exception _) {
				scanner.nextLine();
				System.out.println("Invalid input, please try again!");
			}
		}
	}
	public static void run() {
		var scanner = new Scanner(System.in);
		String originalText = "This text here is just for testing. It's a text..... It is just random words lol,"
							+ "but I tried adding certain words multiple times for better testing";
		
		int replacementLen = getIntFromInput(scanner, "Please enter the length of words you want to replace: ");
		System.out.print("Please enter the string that will be placed: ");
		String replacementString = scanner.nextLine();

		var builder = new StringBuilder();
		String[] split = originalText.split(" ");
		for (int i = 0; i < split.length; i++) {
			var word = split[i];
			builder.append(word.length() == replacementLen ? replacementString : word);
			if (i != split.length - 1) builder.append(' ');
		}
		System.out.println();
		System.out.println("%d letter words will be replaced with the word '%s'".formatted(replacementLen,replacementString));
		System.out.println("Original text:\n[%s]".formatted(originalText));
		System.out.println("Edited text:\n[%s]".formatted(builder.toString()));

		scanner.close();
	}
}
