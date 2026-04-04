package DevWorkshop.lab5;

public class Program {
	public static void main(String[] args) {
		var itDept = new Department("IT Department");

		itDept.addPosition(itDept.new Position("Developer","Writes code"));

		var devPosition = itDept.Search("developer");
		if (devPosition == null) {
			System.out.println("Couldn't find developer position");
			return;
		}

		devPosition.addEmployee("Oleg");
		devPosition.addEmployee("Pablo");
		devPosition.addEmployee("Gregory");

		System.out.println("Found developer named Oleg: %b".formatted(devPosition.Search("oleg")));
		System.out.println("Found developer named Alan: %b".formatted(devPosition.Search("alan")));
	}
}
