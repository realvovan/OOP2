package DevWorkshop.lab5;

import java.util.ArrayList;
import java.util.List;

public class Department implements Searchable<Department.Position> {
	class Position implements Searchable<String> {
		public String title;
		public String description;
		private List<String> _employees;

		public List<String> getEmployees() {
			return this._employees;
		}
		public void addEmployee(String name) {
			this._employees.add(name);
		}

		@Override
		public String Search(String keyword) {
			for (String i : this._employees) {
				if (i.toLowerCase().equals(keyword.toLowerCase())) return i;
			}
			return null;
		}

		public Position(String title,String description) {
			this.title = title;
			this.description = description;
			this._employees = new ArrayList<>();
		}
	}

	public String title;
	private List<Position> _positions;

	public List<Position> getPositions() {
		return this._positions;
	}
	public void addPosition(Position position) {
		this._positions.add(position);
	}

	@Override
	public Position Search(String keyword) {
		String lowerCaseKeyword = keyword.toLowerCase();
		for (Position i : this._positions) {
			if (i.title.toLowerCase().equals(lowerCaseKeyword) || i.description.toLowerCase().equals(lowerCaseKeyword)) return i;
		}
		return null;
	}

	public Department(String title) {
		this.title = title;
		this._positions = new ArrayList<>();
	}
}
