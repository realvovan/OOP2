package DevWorkshop.lab2;

import java.util.Random;
import java.util.Scanner;

public class Part1 {
	public static void run() {
		var scanner = new Scanner(System.in);
		// 123 -> 321
		Integer input = new Random().nextInt(100,1000);
		String output = new StringBuilder(input.toString()).reverse().toString();
		System.out.print("%d -> %s".formatted(input,output));
		scanner.close();
	}
}


// while (input != 0) {
// 	int digit = input % 10;
// 	result = result * 10 + digit;
// 	input /= 10;
// }