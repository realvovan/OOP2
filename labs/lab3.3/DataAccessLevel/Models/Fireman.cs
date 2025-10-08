using System.Runtime.Versioning;

namespace DataAccessLevel.Models;

public class Fireman : Person, IGuitarist {
	public bool HasJob { get; set; }
	public int JobsDone { get; set; }

	public Fireman() { }
	public Fireman(string first,string last,int jobsDone = 0) : base(first,last) {
		this.JobsDone = jobsDone;
	}
	public void Play() {
		Console.WriteLine("Playing");
	}
	public void GetJob() => this.HasJob = true;
	public void FinishJob() {
		this.HasJob = false;
		this.JobsDone++;
	}
}
