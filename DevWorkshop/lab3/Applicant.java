package DevWorkshop.lab3;

public class Applicant {
	public final int id;

	private String firstName;
	public String getFirstName() { return this.firstName; }
	public void setFirstName(String newName) {
		if (!newName.matches("^[A-Za-z]+$")) throw new IllegalArgumentException("Invalid argument");
		this.firstName = newName;
	}

	private String lastName;
	public String getLastName() { return this.lastName; }
	public void setLastName(String newName) {
		if (!newName.matches("^[A-Za-z]+$")) throw new IllegalArgumentException("Invalid argument");
		this.lastName = newName;
	}

	public String phoneNumber;
	public String getPhoneNumber() { return this.phoneNumber; }
	public void setPhoneNumber(String newNumber) {
		if (!newNumber.matches("^\\+?\\d+$")) throw new IllegalArgumentException("Invalid argument");
		this.phoneNumber = newNumber;
	}

	public float[] nmtScores;
	public float[] getNmtScores() { return this.nmtScores; }
	public void setNmtScores(float[] newNmtScore) {
		this.nmtScores = new float[newNmtScore.length];
		for (int i = 0; i < newNmtScore.length; i++) {
			float score = newNmtScore[i];
			if (score < 99 || score > 200) throw new IllegalArgumentException();
			this.nmtScores[i] = score;
		}
	}

	public String toString() {
		var result = new StringBuilder("%s %s [id:%d | phone number:%s | nmt:{ ".formatted(
			this.firstName,this.lastName,this.id,this.phoneNumber
		));
		float average = 0f;
		for (float i : this.nmtScores) {
			result.append("%.1f ".formatted(i));
			average += i;
		}
		average /= this.nmtScores.length;
		result.append("}");
		result.append("| nmt avg:%.1f ]".formatted(average));
		return result.toString();
	}
	
	public Applicant(int id,String first,String last,String phoneNumber,float[] nmtScores) {
		this.id = id;
		this.setFirstName(first);
		this.setLastName(last);
		this.setPhoneNumber(phoneNumber);
		this.setNmtScores(nmtScores);
	}
}