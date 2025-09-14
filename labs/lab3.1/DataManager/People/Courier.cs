using System.Media;
using System.Runtime.Versioning;

namespace Database.People;

public enum CourierJobStatus {
	Free,
	OrderReceived,
	Driving,
	Shopping
}

public class Courier : Person, IGuitarist {
	public CourierJobStatus JobStatus { get; private set; } = CourierJobStatus.Free;
	public int OrdersDelivered { get; private set; }

	public Courier(string first,string last,int passportNumber,int ordersDelivered = 0) : base(first,last,passportNumber) {
		this.OrdersDelivered = ordersDelivered;
	}
	[SupportedOSPlatform("windows")]
	public void Play() {
		SystemSounds.Hand.Play();
	}
	public void SendOrder() {
		if (this.JobStatus != CourierJobStatus.Free) throw new Exception("Already got order");
		this.JobStatus = CourierJobStatus.OrderReceived;
	}
	public void Drive() {
		if (this.JobStatus == CourierJobStatus.Driving) throw new Exception("Already driving");
		if (this.JobStatus == CourierJobStatus.Free) throw new Exception("Cannot drive because got no order");
		this.JobStatus = CourierJobStatus.Driving;
	}
	public void Shop() {
		if (this.JobStatus == CourierJobStatus.Shopping) throw new Exception("Already shopping");
		this.JobStatus = CourierJobStatus.Shopping;
	}
	public void Deliver() {
		if (this.JobStatus == CourierJobStatus.Free) throw new Exception("Got no order to deliver");
		this.JobStatus = CourierJobStatus.Free;
		this.OrdersDelivered++;
	}
}