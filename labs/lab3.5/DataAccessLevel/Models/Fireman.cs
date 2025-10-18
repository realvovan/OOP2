using Newtonsoft.Json;

namespace lab3_5.DataAccessLevel.Models;

public class Fireman(string first,string last,int passportId,bool hasJob,int jobsDone) : Person(first,last,passportId),IGuitarist {
	public int JobsDone { get; set; } = jobsDone;
	public bool HasJob { get; set; } = hasJob;
	[JsonConstructor]
	public Fireman() : this("NA","NA",-1,false,-1) { }
	public void GetJob() {
		if (this.HasJob) throw new Exception("Already has a job");
		this.HasJob = true;
	}
	public void FinishJob() {
		if (this.HasJob) {
			this.HasJob = false;
			this.JobsDone++;
		} else {
			throw new Exception("Fireman has no active jobs");
		}
	}
	public void Play() {
		Console.WriteLine("Playing guitar");
	}
}
