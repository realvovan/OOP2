package DevWorkshop.lab1;

import java.util.Scanner;

/*
Some magic squares
=====
2 7 6
9 5 1
4 3 8
=====
1 14 15 4
12 7 6 9
8 11 10 5
13 2 3 16
=====
*/

public class Program {
	public static int getIntFromInput(Scanner scanner,String prompt) {
		System.out.print(prompt);
		while (true) {
			try {
				return scanner.nextInt();
			} catch(Exception _) {
				System.out.println("Invalid input, please try again!");
			}
		}
	}
	public static int[] getColFromInput(Scanner scanner,String prompt,int size) {
		System.out.println(prompt);
		int[] column = new int[size];
		while (true) {
			try {
				String[] strColumn = scanner.nextLine().split(" ");
				if (strColumn.length != size) throw new Exception("Invalid column size");
				for (int i = 0; i < size; i++) {
					column[i] = Integer.parseInt(strColumn[i]);
				}
				return column;
			} catch (Exception e) {
				System.out.println("%s. Please try again".formatted(e.getMessage()));
			}
		}
	}
	public static Integer getMagicNumber(int[][] matrix) {
		if (matrix.length != matrix[0].length) return null;

		boolean isMagicNumberComputed = false;
		int magicNumber = 0;
		int size = matrix.length;

		for (int y = 0; y < size; y++) {
			int sum = 0;
			for (int x = 0; x < size; x++) {
				sum += matrix[y][x];
			}
			if (!isMagicNumberComputed) {
				isMagicNumberComputed = true;
				magicNumber = sum;
			} else if (magicNumber != sum) {
				return null;
			}
		}

		for (int x = 0; x < size; x++) {
			int sum = 0;
			for (int y = 0; y < size; y++) {
				sum += matrix[y][x];
			}
			if (magicNumber != sum) return null;
		}

		int sum1 = 0;
		int sum2 = 0;
		for (int i = 0; i < size; i++) {
			sum1 += matrix[i][i];
			sum2 += matrix[size - i - 1][size - i - 1];
		}
		if (sum1 != magicNumber || sum2 != magicNumber) return null;

		return magicNumber;
	}

	public static void main(String[] args) {
		var scanner = new Scanner(System.in);

		int size = getIntFromInput(scanner, "Please enter matrix size: ");
		int[][] matrix = new int[size][];

		scanner.nextLine(); // needed because nextInt() was called before

		for (int i = 0;i < size;i++) {
			matrix[i] = getColFromInput(scanner, "Please enter values for column %d, separated with a space: ".formatted(i+1), size);
		}

		System.out.println("Matrix:");
		for (int[] rows : matrix) {
			for (int i : rows) {
				System.out.print("%d ".formatted(i));
			}
			System.out.println();
		}

		var magicNumber = getMagicNumber(matrix);
		if (magicNumber == null) {
			System.out.println("is not a magic square");
		} else {
			System.out.println("is a magic square. Magic number is %d".formatted(magicNumber));
		}

		scanner.close();
	}
}