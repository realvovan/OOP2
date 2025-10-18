using Newtonsoft.Json;

namespace lab3_5.DataAccessLevel.Models;

public class Courier(
	string first,
	string last,
	int passportId,
	bool hasJob,
	int jobsDone,
	DateTime? deliveryTime = null,
	DateTime? startedAt = null) : Person(first,last,passportId),IGuitarist {
	public int JobsDone { get; set; } = jobsDone;
	public bool HasJob { get; set; } = hasJob;
	public DateTime? ExpectedDeliveryTime { get; set; } = hasJob ? deliveryTime : null;
	public DateTime? DeliveryStartedAt { get; set; } = hasJob ? startedAt : null;
	[JsonConstructor]
	public Courier() : this("NA","NA",-1,false,-1) { }
	public void Play() {
		Console.WriteLine("Playing guitar");
	}
	public void StartJob(double expectedDeliveryInMinutes) {
		if (this.HasJob) throw new Exception("Already has a job");
		if (expectedDeliveryInMinutes <= 0) throw new ArgumentException("Expected time cannot be negative or zero",nameof(expectedDeliveryInMinutes));
		this.HasJob = true;
		this.DeliveryStartedAt = DateTime.Now;
		this.ExpectedDeliveryTime = DateTime.Now.AddMinutes(expectedDeliveryInMinutes);
	}
	public void FinishJob() {
		if (!this.HasJob) throw new Exception("Courier has no job");
		this.HasJob = false;
		this.DeliveryStartedAt = null;
		this.ExpectedDeliveryTime = null;
	}
	public TimeSpan GetElapsedJobTime() {
		if (this.DeliveryStartedAt == null) return new TimeSpan(-1);
		return DateTime.Now - this.DeliveryStartedAt.Value;
	}
	public TimeSpan GetDeliveryEstimate() {
		if (this.ExpectedDeliveryTime == null) return new TimeSpan(-1);
		return this.ExpectedDeliveryTime.Value - DateTime.Now;
	}
}