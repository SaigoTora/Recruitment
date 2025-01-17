using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using RecruitmentServer.Utilities.ServerUtilities;
using SharedModels.Models;

namespace RecruitmentServer.Models.DataBase
{
	internal static class DatabaseManager
	{
		private static readonly RecruitmentEntities _context;

		private static readonly BaseRepo<Employee> _employeeRepo;
		private static readonly BaseRepo<Interview> _interviewRepo;
		private static readonly BaseRepo<Application> _applicationRepo;
		private static readonly BaseRepo<Candidate> _candidateRepo;
		private static readonly BaseRepo<Vacancy> _vacancyRepo;
		private static readonly BaseRepo<EducationDegreeRequirement>
			_educationDegreeRequirementRepo;
		private static readonly BaseRepo<Requirement> _requirementRepo;
		private static readonly BaseRepo<Point> _pointRepo;
		private static readonly BaseRepo<FamilyStatus> _familyStatusRepo;
		private static readonly BaseRepo<BusinessTripOpportunity> _businessTripOpportunityRepo;
		private static readonly BaseRepo<EducationDegree> _educationDegreeRepo;
		private static readonly BaseRepo<EducationForm> _educationFormRepo;
		private static readonly BaseRepo<Position> _positionRepo;

		// Рядок підключення
		private const string CONNECT_STR = @"Data Source=(LocalDB)\MSSQLLocalDB;
			AttachDbFilename=|DataDirectory|\RecruitmentDB.mdf;Integrated Security=True";

		static DatabaseManager()
		{
			_context = new RecruitmentEntities();
			_employeeRepo = new BaseRepo<Employee>(_context);
			_interviewRepo = new BaseRepo<Interview>(_context);
			_applicationRepo = new BaseRepo<Application>(_context);
			_candidateRepo = new BaseRepo<Candidate>(_context);
			_vacancyRepo = new BaseRepo<Vacancy>(_context);
			_educationDegreeRequirementRepo = new BaseRepo<EducationDegreeRequirement>(_context);
			_requirementRepo = new BaseRepo<Requirement>(_context);
			_pointRepo = new BaseRepo<Point>(_context);
			_familyStatusRepo = new BaseRepo<FamilyStatus>(_context);
			_businessTripOpportunityRepo = new BaseRepo<BusinessTripOpportunity>(_context);
			_educationDegreeRepo = new BaseRepo<EducationDegree>(_context);
			_educationFormRepo = new BaseRepo<EducationForm>(_context);
			_positionRepo = new BaseRepo<Position>(_context);

			DatabaseInitializer.Initialize(_context);
		}

		internal static void ExecuteQuery(string commandStr)
		{// Метод, який виконує запит до БД
			SqlConnection connection = new SqlConnection(CONNECT_STR);
			connection.Open();// Відкриваємо підключення до БД
			SqlCommand command = new SqlCommand(commandStr, connection);
			command.ExecuteNonQuery();// Запускаємо команду
			connection.Close();// Закриваємо підключення
		}
		internal static DataTable ExecuteReturnQuery(string commandStr)
		{// Метод, який виконує запит до БД та повертає таблицю
			SqlConnection connection = new SqlConnection(CONNECT_STR);
			connection.Open();// Відкриваємо підключення до БД
			SqlCommand command = new SqlCommand(commandStr, connection);
			SqlDataReader reader = command.ExecuteReader();// Запускаємо команду
			DataTable table = new DataTable();
			table.Load(reader);
			connection.Close();// Закриваємо підключення
			return table;
		}

		#region Create
		internal static void CreatePosition(Position position)
			=> _positionRepo.Add(position);
		internal static void CreateVacancy(Vacancy vacancy)
			=> _vacancyRepo.Add(vacancy);
		internal static void CreateRequirement(Requirement requirement)
			=> _requirementRepo.Add(requirement);
		internal static void CreatePoint(Point point)
			=> _pointRepo.Add(point);
		internal static void CreateInterview(DateTime dateEvent, int idApplication)
		{
			int DEFAULT_STATUS_ID = 1;

			Interview interview = new Interview(dateEvent, idApplication, DEFAULT_STATUS_ID);
			_interviewRepo.Add(interview);
		}
		#endregion

		#region Read
		internal static Employee GetEmployee(int interviewId)
			=> _employeeRepo.GetAll().Find(employee => employee.IdInterview == interviewId);
		internal static Candidate GetCandidate(int candidateId)
			=> _candidateRepo.GetOne(candidateId);
		internal static Requirement GetRequirement(int requirementId)
			=> _requirementRepo.GetOne(requirementId);
		internal static Point GetPoint(int pointId) => _pointRepo.GetOne(pointId);

		internal static List<FamilyStatus> GetFamilyStatuses()
			=> _familyStatusRepo.GetAll();
		internal static List<BusinessTripOpportunity> GetBusinessTrips()
			=> _businessTripOpportunityRepo.GetAll();
		internal static List<EducationDegree> GetEducationDegrees()
			=> _educationDegreeRepo.GetAll();
		internal static List<EducationForm> GetEducationForms()
			=> _educationFormRepo.GetAll();
		internal static string GetRequirementEducationDegree(int requirementId)
		{
			var degrees = _educationDegreeRequirementRepo.GetAll().
				Where(edr => edr.IdRequirement == requirementId).
				Select(edr => edr.EducationDegree.Degree); ;

			string s = string.Empty;
			foreach (string degree in degrees)
				s += $"{degree}, ";

			return s.TrimEnd(' ', ',').ToLower();
		}

		internal static Vacancy GetVacancy(int vacancyId) => _vacancyRepo.GetOne(vacancyId);
		private static List<Vacancy> GetVacancies(ServerSearcher searcher)
		{
			var vacancies = _vacancyRepo.GetAll();

			if (searcher == null)
				return vacancies.OrderByDescending(v => v.DatePublication).ToList();

			if (searcher.Position != null)
				vacancies = vacancies.
					Where(v => v.Position.Name.ToLower().
					Contains(searcher.Position.ToLower())).ToList();

			if (searcher.MinDate.HasValue)
				vacancies = vacancies.Where(v => v.DatePublication > searcher.MinDate).ToList();

			if (searcher.MinValue.HasValue)
				vacancies = vacancies.
					Where(v => v.Applications.Count >= searcher.MinValue).ToList();

			if (searcher.MaxValue.HasValue)
				vacancies = vacancies.
					Where(v => v.Applications.Count <= searcher.MaxValue).ToList();

			if (searcher.IsRelevance.HasValue)
				vacancies = vacancies.
					Where(v => v.Relevance == searcher.IsRelevance).ToList();

			switch (searcher.SortOption)
			{
				case ServerSortOption.Date:
					return vacancies.OrderByDescending(v => v.DatePublication).ToList();
				case ServerSortOption.AlphabetPosition:
					return vacancies.OrderBy(v => v.Position.Name).ToList();
				case ServerSortOption.NumberOfApplications:
					return vacancies.OrderByDescending(v => v.Applications.Count).ToList();
				default: return vacancies.ToList();
			}
		}
		internal static int GetCountVacancies(ServerSearcher searcher)
			=> GetVacancies(searcher).Count;
		internal static List<Vacancy> GetVacancies(int offset, int amount,
			ServerSearcher searcher)
		{
			var vacancies = GetVacancies(searcher);
			return vacancies.GetRange(offset, Math.Min(vacancies.Count, amount));
		}

		internal static Application GetApplication(int applicationId)
			=> _applicationRepo.GetOne(applicationId);
		private static List<Application> GetApplications(ServerSearcher searcher)
		{
			var applications = _applicationRepo.GetAll();

			if (searcher == null)
				return applications.OrderByDescending(a => a.DateSubmission).ToList();

			if (searcher.Position != null)
				applications = applications.
					Where(a => a.Vacancy.Position.Name.ToLower().
					Contains(searcher.Position.ToLower())).ToList();

			if (searcher.MinDate.HasValue)
				applications = applications.
					Where(a => a.DateSubmission > searcher.MinDate).ToList();

			if (searcher.MinValue.HasValue)
				applications = applications.
					Where(a => a.Scores >= searcher.MinValue).ToList();

			if (searcher.MaxValue.HasValue)
				applications = applications.
					Where(a => a.Scores <= searcher.MaxValue).ToList();

			if (searcher.Status != null)
				applications = applications.
					Where(a => a.ApplicationStatus.Status == searcher.Status).ToList();

			switch (searcher.SortOption)
			{
				case ServerSortOption.Date:
					return applications.OrderByDescending(a => a.DateSubmission).ToList();
				case ServerSortOption.AlphabetPosition:
					return applications.OrderBy(a => a.Vacancy.Position.Name).ToList();
				case ServerSortOption.NumberOfPoints:
					return applications.OrderByDescending(a => a.Scores).ToList();
				default: return applications.ToList();
			}
		}
		internal static int GetCountApplications(ServerSearcher searcher)
			=> GetApplications(searcher).Count;
		internal static List<Application> GetApplications(int offset, int amount,
			ServerSearcher searcher)
		{
			var applications = GetApplications(searcher);
			return applications.GetRange(offset, Math.Min(applications.Count, amount));
		}
		internal static Application GetApplication(int idVacancy, int idCandidate)
			=> _applicationRepo.GetAll().
				Find(a => a.IdVacancy == idVacancy && a.IdCandidate == idCandidate);

		private static List<Interview> GetInterviews(ServerSearcher searcher)
		{
			var interviews = _interviewRepo.GetAll();

			if (searcher == null)
				return interviews.OrderByDescending(i => i.DateEvent).ToList();

			if (searcher.Position != null)
				interviews = interviews.
					Where(i => i.Application.Vacancy.Position.Name.ToLower().
					Contains(searcher.Position.ToLower())).ToList();

			if (searcher.MinDate.HasValue)
				interviews = interviews.
					Where(i => i.DateEvent > searcher.MinDate).ToList();

			if (searcher.Status != null)
				interviews = interviews.
					Where(i => i.InterviewStatus.Status == searcher.Status).ToList();

			switch (searcher.SortOption)
			{
				case ServerSortOption.Date:
					return interviews.OrderByDescending(i => i.DateEvent).ToList();
				case ServerSortOption.AlphabetPosition:
					return interviews.OrderBy(i => i.Application.Vacancy.Position.Name).ToList();
				default: return interviews.ToList();
			}
		}
		internal static int GetCountInterviews(ServerSearcher searcher)
			=> GetInterviews(searcher).Count;
		internal static List<Interview> GetInterviews(int offset, int amount,
			ServerSearcher searcher)
		{
			var interviews = GetInterviews(searcher);
			return interviews.GetRange(offset, Math.Min(interviews.Count, amount));
		}

		private static List<Employee> GetEmployees(ServerSearcher searcher)
		{
			var employees = _employeeRepo.GetAll();

			if (searcher == null)
				return employees.OrderByDescending(e => e.DateEmployment).ToList();

			if (searcher.Position != null)
				employees = employees.
					Where(e => e.Interview.Application.Vacancy.Position.Name.ToLower().
					Contains(searcher.Position.ToLower())).ToList();

			if (searcher.FullName != null)
				employees = employees.
					Where(e => e.GetFullName.ToLower().
					Contains(searcher.FullName.ToLower())).ToList();

			if (searcher.MinDate.HasValue)
				employees = employees.
					Where(e => e.DateEmployment > searcher.MinDate).ToList();

			switch (searcher.SortOption)
			{
				case ServerSortOption.Date:
					return employees.OrderByDescending(e => e.DateEmployment).ToList();
				case ServerSortOption.AlphabetPosition:
					return employees.
						OrderBy(e => e.Interview.Application.Vacancy.Position.Name).ToList();
				case ServerSortOption.AlphabetName:
					return employees.OrderBy(e => e.GetFullName).ToList();
				default: return employees.ToList();
			}
		}

		internal static int GetCountEmployees(ServerSearcher searcher)
			=> GetEmployees(searcher).Count;
		internal static List<Employee> GetEmployees(int offset, int amount,
			ServerSearcher searcher)
		{
			var employees = GetEmployees(searcher);
			return employees.GetRange(offset, Math.Min(employees.Count, amount));
		}

		internal static List<AssignmentItem> GetAssignmentItems()
		{// Applications will NOT be accepted if the vacancies have at least one interview
		 // with the status "Candidate invited" or "Candidate awaiting decision"
			List<AssignmentItem> assignmentItems = new List<AssignmentItem>();

			foreach (AssignmentItem item in _context.Database.SqlQuery(typeof(AssignmentItem),
				"SELECT Vacancy.id AS VacancyId, View_Application.id_candidate AS CandidateId, " +
				"Scores " +
				"FROM Vacancy " +
				"INNER JOIN View_Application ON View_Application.id_vacancy = Vacancy.id " +
				"WHERE relevance = 'True' AND View_Application.status = 'В очікуванні' " +
				"AND (SELECT COUNT(View_Interview.id) " +
				"FROM View_Interview " +
				"INNER JOIN Application ON Application.id = View_Interview.id_application " +
				"WHERE Application.id_vacancy = Vacancy.id " +
				"AND (View_Interview.status = 'Кандидат запрошений' " +
				"OR View_Interview.status = 'Кандидат чекає на рішення')) <= 0 " +
				"ORDER BY Vacancy.id, View_Application.id"))
			{
				assignmentItems.Add(item);
			}

			return assignmentItems;
		}
		#endregion

		// Методи для зміни даних
		internal static void SetApplicationStatus(int idApplication, int idStatus, string reasonRejection)
		{// Метод встановлює статус заявці
			if (reasonRejection == null || reasonRejection.Length < 0)
				reasonRejection = "NULL";
			else
				reasonRejection = $"'{reasonRejection}'";

			ExecuteQuery($"UPDATE Application SET id_application_status = {idStatus}, reason_rejection = {reasonRejection} " +
				$"WHERE Application.id = {idApplication}");
		}
		internal static void SetInterviewStatus(int idInterview, int idStatus)
		{// Метод встановлює статус співбесіді
			ExecuteQuery($"UPDATE Interview SET id_interview_status = {idStatus} " +
				$"WHERE id = {idInterview}");
		}
		internal static void ChangeInterviewDateEvent(int idInterview, DateTime dateTime)
		{// Метод, який змінює дату співбесіди
			ExecuteQuery($"UPDATE Interview SET date_event = " +
				$"'{dateTime:yyyy-MM-dd} {dateTime:HH:mm:ss}' WHERE id = {idInterview}");
		}
		internal static void UpdateEmployeePosition(string position, int employeeId)
		{
			ExecuteQuery($"UPDATE Employee SET position_name  = '{position}' " +
				$"WHERE id = {employeeId}");
		}
		internal static void UpdateEmployeeSalary(double salary, int employeeId)
		{
			ExecuteQuery($"UPDATE Employee SET salary = " +
				$"{salary.ToString().Replace(",", ".")} WHERE id = {employeeId}");
		}

		#region Delete
		internal static void DeleteVacancy(Vacancy vacancy) => _vacancyRepo.Delete(vacancy);
		internal static void DeleteEmployee(Employee employee) => _employeeRepo.Delete(employee);
		#endregion

		public static void Dispose()
		{
			_context?.Dispose();

			_employeeRepo?.Dispose();
			_interviewRepo?.Dispose();
			_applicationRepo?.Dispose();
			_candidateRepo?.Dispose();
			_vacancyRepo?.Dispose();
			_educationDegreeRequirementRepo?.Dispose();
			_requirementRepo?.Dispose();
			_pointRepo?.Dispose();
			_familyStatusRepo?.Dispose();
			_businessTripOpportunityRepo?.Dispose();
			_educationDegreeRepo?.Dispose();
			_educationFormRepo?.Dispose();
			_positionRepo?.Dispose();
		}
	}
}