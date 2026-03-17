package DevWorkshop.lab4;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Scanner;

//input: DevWorkshop/lab4/testInput.java

public class Program {
	public static void main(String[] args) {
		var scanner = new Scanner(System.in);
		System.out.println("Enter the path to an input .java file:");
		Path inPath,outPath;
		try {
			inPath = Paths.get(scanner.nextLine());
		} catch (Exception e) {
			System.out.println("Couldn't resolve input file path (%s)".formatted(e.getMessage()));
			scanner.close();
			return;
		}
		System.out.println("Enter the path to an output file:");
		try {
			outPath = Paths.get(scanner.nextLine());
		} catch (Exception e) {
			System.out.println("Couldn't resolve input file path (%s)".formatted(e.getMessage()));
			scanner.close();
			return;
		}
		scanner.close();
		
		if (!inPath.toString().endsWith(".java")) {
			System.out.println("Input is not a java file!");
			return;
		}
		if (!outPath.toString().endsWith("java")) {
			System.out.println("Output is not a java file!");
			return;
		}

		if (!Files.exists(inPath)) {
			System.out.println("Input file does not exist!");
			return;
		}
		if (Files.exists(outPath)) {
			System.out.println("Output file already exists, cannot overwrite it!");
			return;
		}

		try (
			BufferedReader reader = Files.newBufferedReader(inPath);
			BufferedWriter writer = Files.newBufferedWriter(outPath)
		) {
			String line;
			boolean isInMultilineComment = false;
			while ((line = reader.readLine()) != null) {
				if (isInMultilineComment) {
					int multilineCommentEndIndex = line.indexOf("*/");
					if (multilineCommentEndIndex != -1) {
						writer.write(line.substring(multilineCommentEndIndex + 2));
						writer.write('\n');
						isInMultilineComment = false;
					}
				} else {
					int commentIndex = line.indexOf("//");
					int multilineCommentStartIndex = line.indexOf("/*");
					if (commentIndex == -1 && multilineCommentStartIndex == -1) {
						writer.write(line);
						writer.write('\n');
					} else if (multilineCommentStartIndex == -1) {
						writer.write(line.substring(0,commentIndex));
						writer.write('\n');
					} else {
						writer.write(line.substring(0,multilineCommentStartIndex));
						int multilineCommentEndIndex = line.indexOf("*/");
						if (multilineCommentEndIndex == -1) {
							isInMultilineComment = true;
						} else {
							writer.write(line.substring(multilineCommentEndIndex + 2));
							writer.write('\n');
						}
					}
				}
			}
		} catch (Exception e) {
			System.out.println(e.getMessage());
		}
	}
}