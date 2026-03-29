package DevWorkshop.homework1;

public class Program {
	public static void main(String[] args) {
		Thread t1 = new Thread(() -> {
			try {
				while (true) {
					Thread.sleep(1000);
					System.out.println("1");
				}
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
		});

		Thread t2 = new Thread(() -> {
			try {
				while (true) {
					Thread.sleep(2000);
					System.out.println("\t2");
				}
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
		});

		Thread t3 = new Thread(() -> {
			try {
				while (true) {
					Thread.sleep(3000);
					System.out.println("\t\t3");
				}
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
		});

		t1.start();
		t2.start();
		t3.start();
	}
}