package DevWorkshop.lab6;

import java.util.ArrayList;

public class Polynomial {
	public final int degree;
	public final float[] coefficients;

	public Polynomial multiply(Polynomial other) {
		int capacity = this.degree + other.degree + 1;
		ArrayList<ArrayList<Float>> terms = new ArrayList<>(capacity);
		for (int i = 0; i < capacity; i++) {
			terms.add(new ArrayList<>());
		}
		for (int i = 0; i < this.coefficients.length; i++) {
			for (int j = 0; j < other.coefficients.length; j++) {
				terms.get(i + j).add(this.coefficients[i] * other.coefficients[j]);
			}
		}
		
		float[] finalCoefficients = new float[terms.size()];
		for (int i = 0; i < finalCoefficients.length; i++) {
			float sum = 0f;
			for (float j : terms.get(i)) {
				sum += j;
			}
			finalCoefficients[i] = sum;
		}

		return new Polynomial(finalCoefficients);
	}

	@Override
	public String toString() {
		var result = new StringBuilder();
		for (int i = 0; i < this.coefficients.length; i++) {
			float coefficient = this.coefficients[i];
			int exponent = this.degree - i;
			
			if (coefficient != 0) {
				result.append(coefficient);

				if (exponent == 1) {
					result.append('x');
				} else if (exponent != 0) {
					result.append("x^%d".formatted(exponent));
				}
			}
			
			if (i != this.coefficients.length - 1 && this.coefficients[i + 1] > 0f) {
				result.append('+');
			}
		}
		return result.toString();
	}

	public Polynomial(float[] coefficients) {
		if (coefficients.length == 0) {
			this.degree = 0;
			this.coefficients = new float[] {0};
		} else {
			this.degree = coefficients.length - 1;
			this.coefficients = coefficients;
		}
	}
}