using System.Media;
using System.Runtime.Versioning;

namespace Database.People;

public class Fireman : Person, IGuitarist {
	public bool HasJob { get; private set; }
	public int JobsDone { get; private set; }

	public Fireman(string first,string last,int passportNumber,int jobsDone = 0) : base(first,last,passportNumber) {
		this.JobsDone = jobsDone;
	}
	[SupportedOSPlatform("windows")]
	public void Play() {
		SystemSounds.Hand.Play();
	}
	public void GetJob() => this.HasJob = true;
	public void FinishJob() {
		this.HasJob = false;
		this.JobsDone++;
	}
}