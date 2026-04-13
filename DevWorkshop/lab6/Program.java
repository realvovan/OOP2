package DevWorkshop.lab6;

import java.util.Scanner;

public class Program {
	static Polynomial polynomialFromInput(Scanner scanner) {
		try {
			System.out.println("Please enter the degree of the polynomial:");
			int degree = scanner.nextInt();
			if (degree < 0) throw new RuntimeException("Degree of the polynomian cannot be less than zero.");
			float[] coefficients = new float[degree + 1];
			for (int i = 0; i < coefficients.length; i++) {
				System.out.println("Enter the power %d coefficient".formatted(degree - i));
				coefficients[i] = scanner.nextFloat();
			}
			return new Polynomial(coefficients);
		} catch (Exception e) {
			throw new RuntimeException("Couldn't construct a polynomial",e);
		}
	}

	public static void main(String[] args) {
		var scanner = new Scanner(System.in);
		Polynomial p1 = polynomialFromInput(scanner);
		Polynomial p2 = polynomialFromInput(scanner);
		Polynomial result = p1.multiply(p2);
		System.out.println(p1.toString());
		System.out.println('*');
		System.out.println(p2.toString());
		System.out.println('=');
		System.out.println(result.toString());
		scanner.close();
	}
}