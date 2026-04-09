namespace lab3.PL;

internal static class ApiEndpoints {
	public const string BASE_URL = "http://localhost:5201";

	public class ProjectsController {
		public const string ROUTE = BASE_URL + "/api/projects";

		public const string DELETE_URL = ROUTE + "/delete";
		public const string UPDATE_URL = ROUTE + "/update";
	}

	public class TaskItemCotroller {
		public const string ROUTE = BASE_URL + "/api/tasks";

		public const string DELETE_URL = ROUTE + "/delete";
		public const string UPDATE_URL = ROUTE + "/update";
		public const string UPDATE_PRIORITY_URL = ROUTE + "/update_priority";
		public const string UPDATE_STATUS_URL = ROUTE + "/update_status";
	}
}