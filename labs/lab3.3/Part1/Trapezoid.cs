using System.Drawing;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using DataAccessLevel.DataProviders;

namespace lab3_3;

public class Trapezoid(double base1,double base2,double height) {
	[XmlIgnore]
	[CustomProviderIgnore]
	public Color FillColor { get; set; } = Color.White;
	[XmlIgnore]
	[CustomProviderIgnore]
	public Color BorderColor { get; set; } = Color.Black;
	public double Base1 { get; set; } = base1;
	public double Base2 { get; set; } = base2;
	public double Height { get; set; } = height;
	[JsonIgnore]
	public int FillColorArgb {
		get => this.FillColor.ToArgb();
		set => this.FillColor = Color.FromArgb(value);
	}
	[JsonIgnore]
	public int BorderColorArgb {
		get => this.BorderColor.ToArgb();
		set => this.BorderColor = Color.FromArgb(value);
	}

	public Trapezoid(double base1,double base2,double height,Color fillColor,Color borderColor) : this(base1,base2,height) {
		this.BorderColor = borderColor;
		this.FillColor = fillColor;
	}
	[JsonConstructor]
	public Trapezoid() : this(0,0,0) { }

	public double GetArea() => (this.Base1 + this.Base2) / 2 * this.Height;
	public double GetPerimeter() {
		double side = Math.Sqrt(Math.Pow(Math.Abs(this.Base1 - this.Base2) / 2,2) + this.Height * this.Height);
		return this.Base1 + this.Base2 + 2 * side;
	}
	public override string ToString() {
		return $"Trapezoid [base1: {this.Base1}, base2: {this.Base2}, height: {this.Height}, area: {this.GetArea()}, fill color: {this.FillColor}]";
	}
}