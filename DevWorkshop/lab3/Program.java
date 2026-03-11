package DevWorkshop.lab3;

import java.util.ArrayList;
import java.util.Scanner;
import java.util.function.Predicate;

// 1. Отримати список абітурієнтів, що отримали
// незадовільні оцінки.
// 2. Отримати список абітурієнтів, у яких середній
// бал вище заданого.

public class Program {
	static <T> ArrayList<T> where(ArrayList<T> list,Predicate<T> predicate) {
		var newList = new ArrayList<T>();
		for (T element : list) {
			if (predicate.test(element)) newList.add(element);
		}
		return newList;
	}
	public static void main(String[] args) {
		var scanner = new Scanner(System.in);
		var applicants = new ArrayList<Applicant>();
		
		try {
			applicants.add(new Applicant(
				123,
				"Bob",
				"Brown",
				"+1480123",
				new float[] {176,180,159,175}
			));
			applicants.add(new Applicant(
				234,
				"Alex",
				"Grey",
				"09912345678",
				new float[] {129,140,135,165}
			));
			applicants.add(new Applicant(
				953,
				"Steve",
				"Voznyak",
				"+4895023112",
				new float[] {180,185,179,195}
			));
			applicants.add(new Applicant(
				342,
				"Geena",
				"Miller",
				"0953214585",
				new float[] {150,151,120,129}
			));
			applicants.add(new Applicant(
				4215,
				"Michael",
				"Smith",
				"+380965622156",
				new float[] {162,160,169,158}
			));
			applicants.add(new Applicant(
				1565,
				"Thomas",
				"Buyer",
				"+955132486",
				new float[] {150,170,185,190}
			));
			applicants.add(new Applicant(
				1234,
				"1Name",
				"LastName",
				"0123456",
				new float[] {123,124,125,126}
			));
		} catch (Exception e) {
			System.out.println(e.getMessage());
		}

		System.out.println("Applicants:");
		for (var i : applicants) {
			System.out.println(i.toString());
		}

		var failedApplicants = where(applicants,a -> {
			final float FAILING_GRADE = 130;
			for (float i : a.getNmtScores()) {
				if (i < FAILING_GRADE) return true;
			}
			return false;
		});
		System.out.println("\nFailed applicants:");
		for (var applicant : failedApplicants) {
			System.out.println(applicant.toString());
		}

		var starApplicants = where(applicants,a -> {
			final float REQUIREMENT = 180f;
			float average = 0f;
			for (float i : a.getNmtScores()) {
				average += i;
			}
			average /= a.getNmtScores().length;
			return average >= REQUIREMENT;
		});
		System.out.println("\nStar applicants:");
		for (var applicant : starApplicants) {
			System.out.println(applicant.toString());
		}

		scanner.close();
	}
}
