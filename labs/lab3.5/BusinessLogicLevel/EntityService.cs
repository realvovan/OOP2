using System.Text;
using lab3_5.BusinessLogic.DTOs;
using lab3_5.DataAccessLevel.FileRepositories;
using lab3_5.DataAccessLevel.Models;

namespace lab3_5.BusinessLogic;

public class EntityService {
	private List<Person> people = new();
	private Student[] sportsTeam = [];
	private IRepository fileRepo;

	public string FilePath {
		get => this.fileRepo.FilePath;
		set => this.fileRepo.FilePath = value;
	}
	public int PeopleCount => this.people.Count;

	public EntityService(IRepository fileRepo) => this.fileRepo = fileRepo;
	public void ChangeRepo(IRepository newRepo) => this.fileRepo = newRepo;
	public FileAccessResult SaveToFile() {
		try {
			this.fileRepo.SaveToFile(this.people);
			return FileAccessResult.EmptySuccess;
		} catch (Exception e) {
			return new FileAccessResult(false,$"Error while saving: {e.Message}");
		}
	}
	public FileAccessResult LoadFromFile() {
		try {
			var loaded = this.fileRepo.GetFromFile<Person>();
			if (loaded == null) return new FileAccessResult(false,"File repository returned null");
			this.people = loaded.ToList();
			return FileAccessResult.EmptySuccess;
		} catch (Exception e) {
			return new FileAccessResult(false,$"Error while loading: {e.Message}");
		}
	}
	public void AddPerson(Person person) => this.people.Add(person);
	public void AddPerson(PersonDTO personDTO) => this.people.Add(personDTO.ToEntity());
	public bool RemovePerson(int index) {
		if (index < 0 || index >= this.people.Count) return false;
		this.people.RemoveAt(index);
		return true;
	}
	public void Clear() => this.people.Clear();
	public string GetYear2StudentsWhoDoSports() {
		var result = new StringBuilder();
		bool found = false;
		for (int i = 0; i < this.people.Count; i++) {
			if (this.people[i] is Student student && student.Year == 2 && student.IsSportsAHobby) {
				result.Append($"{student.ToString()}, under index {i} in the list\n");
				found = true;
			}
		}
		if (!found) return "None";
		return result.ToString();
	}
	public void AddTop50StudentsToTeam() {
		var students = this.people.OfType<Student>().OrderByDescending(i => i.SportsMetric).ToArray();
		if (students.Length == 0) {
			this.sportsTeam = [];
			return;
		}
		int cutoff = (int)(students.Length * 0.5f);
		if (cutoff == 0) cutoff = 1;
		float threshold = students[cutoff - 1].SportsMetric;
		this.sportsTeam = students.Where(i => i.SportsMetric >= threshold).ToArray();
	}
	public string GetTeamMemberInfo() {
		if (this.sportsTeam.Length == 0) return "None";
		var result = new StringBuilder();
		int counter = 1;
		foreach (var i in this.sportsTeam) result.Append($"{counter++}. {i} | Sports metrics: {i.SportsMetric}\n");
		return result.ToString();
	}
	public string GetPeopleFullInfo() {
		if (this.people.Count == 0) return "None";
		var result = new StringBuilder();
		for (int i = 0; i < this.people.Count; i++) {
			var person = this.people[i];
			result.Append($"{new string('=',10)}\n{i})\n");
			foreach(var prop in person.GetType().GetProperties()) {
				result.Append($"{prop.Name} = {prop.GetValue(person)}\n");
			}
		}
		return result.ToString();
	}
	public static EntityService CreateJsonEntityService(string filePath) => new EntityService(new JsonRepository(filePath));
}