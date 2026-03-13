using System.Diagnostics.CodeAnalysis;

namespace Algorithms.lab2;

readonly struct Point2(int x,int y) {
	public readonly int X { get; } = x;
	public readonly int Y { get; } = y;
	public float DistanceTo(Point2 other) => GetDistance(this,other);
	public override string ToString() => $"[{this.X}, {this.Y}]";
	public override int GetHashCode() => HashCode.Combine(this.X,this.Y);
	public override bool Equals(object? obj) => obj is Point2 && obj.GetHashCode() == this.GetHashCode();
	public static float GetDistance(Point2 pointA,Point2 pointB) {
		return MathF.Sqrt(MathF.Pow(pointB.X - pointA.X,2) + MathF.Pow(pointB.Y - pointA.Y,2));
	}
}

class Square {
	public Point2 A { get; }
	public Point2 B { get; }
	public Point2 C { get; }
	public Point2 D { get; }

	public float GetPerimeter() => 4f * this.A.DistanceTo(this.B);
	public float GetArea() => MathF.Pow(this.A.DistanceTo(this.B),2);
	public override string ToString() => $"Square: perimeter = {this.GetPerimeter()}|area = {this.GetArea()}";
	public string GetFullInfo() {
		return $"Square: {this.A}\t{this.B}\n"
			 + $"        {this.C}\t{this.D}\n"
			 + $"Perimeter: {this.GetPerimeter()}, area: {this.GetArea()}";
	}
	public override int GetHashCode() => HashCode.Combine(this.GetPerimeter(),this.GetArea());
	public override bool Equals(object? obj) => obj is Square && this.GetHashCode() == obj.GetHashCode();
	public Square(Point2 pointA,int length) {
		if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length));
		this.A = pointA;
		this.B = new Point2(pointA.X + length,pointA.Y);
		this.C = new Point2(pointA.X,pointA.Y + length);
		this.D = new Point2(pointA.X + length,pointA.Y + length);
	}
	public Square(int aX,int aY,int length) : this(new Point2(aX,aY),length) {}
}