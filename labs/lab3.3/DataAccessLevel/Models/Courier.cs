using System.Runtime.Versioning;

namespace DataAccessLevel.Models;

public class Courier : Person, IGuitarist {
	public bool IsFree { get; set; } = true;
	public int OrdersDelivered { get; set; }

	public Courier() { }
	public Courier(string first,string last,int ordersDelivered = 0) : base(first,last) {
		this.OrdersDelivered = ordersDelivered;
	}
	public void Play() {
		Console.WriteLine("Playing");
	}
	public void GetJob() {
		if (!this.IsFree) throw new Exception("Already have a job");
		this.IsFree = false;
	}
	public void DeliverOrder() {
		if (this.IsFree) throw new Exception("No orders available");
		this.OrdersDelivered++;
		this.IsFree = true;
	}
}
