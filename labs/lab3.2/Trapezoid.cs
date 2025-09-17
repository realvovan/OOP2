using System.Drawing;

namespace lab3_2;

public class Trapezoid(double base1,double base2,double height) : IComparable<Trapezoid> {
	public Color FillColor { get; set; } = Color.White;
	public Color BorderColor { get; set; } = Color.Black;
	public double Base1 { get; set; } = base1;
	public double Base2 { get; set; } = base2;
	public double Height { get; set; } = height;
	
	public Trapezoid(double base1,double base2,double height,Color fillColor,Color borderColor) : this(base1,base2,height) {
		this.BorderColor = borderColor;
		this.FillColor = fillColor;
	}

	public double GetArea() => (this.Base1 + this.Base2) / 2 * this.Height;
	public double GetPerimeter() {
		double side = Math.Sqrt(Math.Pow(Math.Abs(this.Base1 - this.Base2) / 2,2) + this.Height*this.Height);
		return this.Base1 + this.Base2 + 2 * side;
	}
	public override string ToString() {
		return $"Trapezoid [base1: {this.Base1}, base2: {this.Base2}, height: {this.Height}, ared: {this.GetArea()}]";
	}
	public int CompareTo(Trapezoid? other) {
		if (other == null) return 1;
		return this.GetArea().CompareTo(other.GetArea());
	}
}