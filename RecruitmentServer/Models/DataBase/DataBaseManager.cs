using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SharedModels.DTOs;
using SharedModels.Models;
using SharedModels.Search;

namespace RecruitmentServer.Models.DataBase
{
	internal static class DatabaseManager
	{
		private static readonly RecruitmentEntities _context;

		private static readonly BaseRepo<Employee> _employeeRepo;
		private static readonly BaseRepo<Interview> _interviewRepo;
		private static readonly BaseRepo<Application> _applicationRepo;
		private static readonly BaseRepo<Candidate> _candidateRepo;
		private static readonly BaseRepo<Education> _educationRepo;
		private static readonly BaseRepo<Language> _languageRepo;
		private static readonly BaseRepo<Questionnaire> _questionnaireRepo;
		private static readonly BaseRepo<Vacancy> _vacancyRepo;
		private static readonly BaseRepo<EducationDegreeRequirement>
			_educationDegreeRequirementRepo;
		private static readonly BaseRepo<Requirement> _requirementRepo;
		private static readonly BaseRepo<Point> _pointRepo;
		private static readonly BaseRepo<InterviewStatus> _interviewStatusRepo;
		private static readonly BaseRepo<FamilyStatus> _familyStatusRepo;
		private static readonly BaseRepo<BusinessTripOpportunity> _businessTripOpportunityRepo;
		private static readonly BaseRepo<Health> _healthRepo;
		private static readonly BaseRepo<EducationDegree> _educationDegreeRepo;
		private static readonly BaseRepo<EducationForm> _educationFormRepo;
		private static readonly BaseRepo<Position> _positionRepo;

		static DatabaseManager()
		{
			_context = new RecruitmentEntities();
			_employeeRepo = new BaseRepo<Employee>(_context);
			_interviewRepo = new BaseRepo<Interview>(_context);
			_applicationRepo = new BaseRepo<Application>(_context);
			_candidateRepo = new BaseRepo<Candidate>(_context);
			_educationRepo = new BaseRepo<Education>(_context);
			_languageRepo = new BaseRepo<Language>(_context);
			_questionnaireRepo = new BaseRepo<Questionnaire>(_context);
			_vacancyRepo = new BaseRepo<Vacancy>(_context);
			_educationDegreeRequirementRepo = new BaseRepo<EducationDegreeRequirement>(_context);
			_requirementRepo = new BaseRepo<Requirement>(_context);
			_pointRepo = new BaseRepo<Point>(_context);
			_interviewStatusRepo = new BaseRepo<InterviewStatus>(_context);
			_familyStatusRepo = new BaseRepo<FamilyStatus>(_context);
			_businessTripOpportunityRepo = new BaseRepo<BusinessTripOpportunity>(_context);
			_healthRepo = new BaseRepo<Health>(_context);
			_educationDegreeRepo = new BaseRepo<EducationDegree>(_context);
			_educationFormRepo = new BaseRepo<EducationForm>(_context);
			_positionRepo = new BaseRepo<Position>(_context);

			DatabaseInitializer.Initialize(_context);
		}

		#region Create
		internal static Candidate CreateCandidate(Candidate candidate)
		{
			_candidateRepo.Add(candidate);
			return candidate;
		}
		private static void CreateEducation(Education education)
			=> _educationRepo.Add(education);
		private static void CreateLanguage(Language language)
			=> _languageRepo.Add(language);
		internal static void CreatePosition(Position position)
			=> _positionRepo.Add(position);
		internal static void CreateVacancy(Vacancy vacancy)
			=> _vacancyRepo.Add(vacancy);
		internal static void CreateApplication(Application application)
			=> _applicationRepo.Add(application);
		internal static void CreateRequirement(Requirement requirement)
			=> _requirementRepo.Add(requirement);
		internal static void CreatePoint(Point point)
			=> _pointRepo.Add(point);
		internal static void CreateInterview(int applicationId, DateTime dateEvent)
		{
			int DEFAULT_STATUS_ID = 1;

			Interview interview = new Interview(dateEvent, applicationId, DEFAULT_STATUS_ID);
			interview.ChangeStatusId(_interviewStatusRepo.GetOne(DEFAULT_STATUS_ID));
			_interviewRepo.Add(interview);
		}
		#endregion

		#region Read
		internal static Employee GetEmployee(int interviewId)
			=> _employeeRepo.GetAll().Find(employee => employee.InterviewId == interviewId);
		internal static Candidate GetCandidate(int candidateId)
			=> _candidateRepo.GetOne(candidateId);
		internal static Candidate GetCandidate(CandidateLoginDTO candidateLogin)
			=> _candidateRepo.GetAll().FirstOrDefault(c =>
				c.Login == candidateLogin.Login && c.Password == candidateLogin.Password);
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
				Where(edr => edr.RequirementId == requirementId).
				Select(edr => edr.EducationDegree?.Degree); ;

			string s = string.Empty;
			foreach (string degree in degrees)
				s += $"{degree}, ";

			return s.TrimEnd(' ', ',').ToLower();
		}

		#region Vacancy
		internal static Vacancy GetVacancy(int vacancyId)
		{
			Vacancy vacancy = _vacancyRepo.GetOne(vacancyId);
			vacancy.ChangeDatePublication(vacancy.DatePublication.ToLocalTime());
			return vacancy;
		}
		private static List<Vacancy> GetVacancies(FullSearcher searcher)
		{
			var vacancies = _vacancyRepo.GetAll();
			vacancies.ForEach(v => v.ChangeDatePublication(v.DatePublication.ToLocalTime()));

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
				case SortOption.Date:
					return vacancies.OrderByDescending(v => v.DatePublication).ToList();
				case SortOption.AlphabetPosition:
					return vacancies.OrderBy(v => v.Position.Name).ToList();
				case SortOption.NumberOfApplications:
					return vacancies.OrderByDescending(v => v.Applications.Count).ToList();
				default: return vacancies.ToList();
			}
		}
		internal static int GetVacanciesCount(FullSearcher searcher)
			=> GetVacancies(searcher).Count;
		internal static List<Vacancy> GetVacancies(int index, int count,
			FullSearcher searcher)
		{
			var vacancies = GetVacancies(searcher);
			return vacancies.GetRange(index, Math.Min(vacancies.Count - index, count));
		}
		internal static int GetVacanciesCount(AccountSearchSettingsDTO accountSearch)
			=> GetVacancies(accountSearch.Searcher)
				.Where(v => v.Relevance
				&& v.Applications.All(a => a.Candidate.Login != accountSearch.Login))
				.Count();
		internal static List<Vacancy> GetVacancies(
			PagedAccountSearchSettingsDTO pagedAccountSearch)
		{
			var filteredList = GetVacancies(pagedAccountSearch.Searcher)
				.Where(v => v.Relevance
				&& v.Applications.All(a => a.Candidate.Login != pagedAccountSearch.Login))
				.ToList();

			return filteredList.GetRange(pagedAccountSearch.StartIndex,
				Math.Min(filteredList.Count - pagedAccountSearch.StartIndex,
					pagedAccountSearch.Count));
		}
		#endregion

		#region Application
		internal static Application GetApplication(int applicationId)
		{
			Application application = _applicationRepo.GetOne(applicationId);
			application.ChangeDateSubmission(application.DateSubmission.ToLocalTime());
			return application;
		}
		internal static Application GetApplication(int vacancyId, int candidateId)
		{
			Application application = _applicationRepo.GetAll().
				Find(a => a.VacancyId == vacancyId && a.CandidateId == candidateId);
			application.ChangeDateSubmission(application.DateSubmission.ToLocalTime());
			return application;
		}

		private static List<Application> GetApplications(FullSearcher searcher)
		{
			var applications = _applicationRepo.GetAll();
			applications.ForEach(a => a.ChangeDateSubmission(a.DateSubmission.ToLocalTime()));

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
				case SortOption.Date:
					return applications.OrderByDescending(a => a.DateSubmission).ToList();
				case SortOption.AlphabetPosition:
					return applications.OrderBy(a => a.Vacancy.Position.Name).ToList();
				case SortOption.NumberOfPoints:
					return applications.OrderByDescending(a => a.Scores).ToList();
				default: return applications.ToList();
			}
		}
		internal static int GetApplicationsCount(FullSearcher searcher)
			=> GetApplications(searcher).Count;
		internal static List<Application> GetApplications(int index, int count,
			FullSearcher searcher)
		{
			var applications = GetApplications(searcher);
			return applications.GetRange(index, Math.Min(applications.Count - index, count));
		}
		internal static int GetApplicationsCount(AccountSearchSettingsDTO accountSearch)
			=> GetApplications(accountSearch.Searcher)
			.Where(a => a.Candidate.Login == accountSearch.Login).Count();
		internal static List<Application> GetApplications(
			PagedAccountSearchSettingsDTO pagedAccountSearch)
		{
			var filteredList = GetApplications(pagedAccountSearch.Searcher)
				.Where(a => a.Candidate.Login == pagedAccountSearch.Login).ToList();

			return filteredList.GetRange(pagedAccountSearch.StartIndex,
				Math.Min(filteredList.Count - pagedAccountSearch.StartIndex,
					pagedAccountSearch.Count));
		}
		#endregion

		#region Interview
		private static List<Interview> GetInterviews(FullSearcher searcher)
		{
			var interviews = _interviewRepo.GetAll();
			interviews.ForEach(i => i.ChangeDateEvent(i.DateEvent.ToLocalTime()));

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
				case SortOption.Date:
					return interviews.OrderByDescending(i => i.DateEvent).ToList();
				case SortOption.AlphabetPosition:
					return interviews.OrderBy(i => i.Application.Vacancy.Position.Name).ToList();
				default: return interviews.ToList();
			}
		}
		internal static int GetInterviewsCount(FullSearcher searcher)
			=> GetInterviews(searcher).Count;
		internal static List<Interview> GetInterviews(int index, int count,
			FullSearcher searcher)
		{
			var interviews = GetInterviews(searcher);
			return interviews.GetRange(index, Math.Min(interviews.Count - index, count));
		}
		internal static int GetInterviewsCount(AccountSearchSettingsDTO accountSearch)
			=> GetInterviews(accountSearch.Searcher)
				.Where(i => i.Application.Candidate.Login == accountSearch.Login).Count();
		internal static List<Interview> GetInterviews(
			PagedAccountSearchSettingsDTO pagedAccountSearch)
		{
			var filteredList = GetInterviews(pagedAccountSearch.Searcher)
				.Where(i => i.Application.Candidate.Login == pagedAccountSearch.Login).ToList();

			return filteredList.GetRange(pagedAccountSearch.StartIndex,
				Math.Min(filteredList.Count - pagedAccountSearch.StartIndex,
					pagedAccountSearch.Count));
		}
		#endregion

		#region Employee
		private static List<Employee> GetEmployees(FullSearcher searcher)
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
				case SortOption.Date:
					return employees.OrderByDescending(e => e.DateEmployment).ToList();
				case SortOption.AlphabetPosition:
					return employees.
						OrderBy(e => e.Interview.Application.Vacancy.Position.Name).ToList();
				case SortOption.AlphabetName:
					return employees.OrderBy(e => e.GetFullName).ToList();
				default: return employees.ToList();
			}
		}
		internal static int GetEmployeesCount(FullSearcher searcher)
			=> GetEmployees(searcher).Count;
		internal static List<Employee> GetEmployees(int index, int count,
			FullSearcher searcher)
		{
			var employees = GetEmployees(searcher);
			return employees.GetRange(index, Math.Min(employees.Count - index, count));
		}
		#endregion

		#region Check unique
		internal static bool CheckCandidateLoginUnique(StringDataUniqueDTO stringDataUnique)
			=> !_candidateRepo.GetAll().Any(c => c.Login == stringDataUnique.Data);
		internal static bool CheckCandidatePhoneUnique(StringDataUniqueDTO stringDataUnique)
			=> !_candidateRepo.GetAll().Any(c => c.Phone == stringDataUnique.Data
				&& c.Id != stringDataUnique.CandidateId);
		internal static bool CheckCandidateEmailUnique(StringDataUniqueDTO stringDataUnique)
			=> !_candidateRepo.GetAll().Any(c => c.Email == stringDataUnique.Data
				&& c.Id != stringDataUnique.CandidateId);
		#endregion

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

		#region Update
		internal static void UpdateEmployeePositionName(int employeeId, string positionName)
		{
			Employee employeeToUpdate = _employeeRepo.GetOne(employeeId);
			employeeToUpdate.ChangePosition(positionName);
			_employeeRepo.Save(employeeToUpdate);
		}
		internal static void UpdateEmployeeSalary(int employeeId, decimal salary)
		{
			Employee employeeToUpdate = _employeeRepo.GetOne(employeeId);
			employeeToUpdate.ChangeSalary(salary);
			_employeeRepo.Save(employeeToUpdate);
		}
		internal static void UpdateInterviewDateEvent(int interviewId, DateTime dateEvent)
		{
			Interview interviewToUpdate = _interviewRepo.GetOne(interviewId);
			interviewToUpdate.ChangeDateEvent(dateEvent);
			_interviewRepo.Save(interviewToUpdate);
		}
		internal static void UpdateInterviewStatus(int interviewId, int statusId)
		{
			Interview interviewToUpdate = _interviewRepo.GetOne(interviewId);
			interviewToUpdate.ChangeStatusId(_interviewStatusRepo.GetOne(statusId));
			_interviewRepo.Save(interviewToUpdate);
		}
		internal static void UpdateApplicationStatus(int applicationId, int statusId,
			string reasonRejection)
		{
			Application applicationToUpdate = _applicationRepo.GetOne(applicationId);
			applicationToUpdate.ChangeStatusId(statusId);
			applicationToUpdate.ChangeReasonRejection(reasonRejection);
			_applicationRepo.Save(applicationToUpdate);
		}

		#region Candidate
		internal static Candidate UpdateCandidate(int candidateId, Candidate candidate)
		{
			Candidate candidateToUpdate = _candidateRepo.GetOne(candidateId);
			if (candidateToUpdate == null)
				return candidateToUpdate;

			_context.Entry(candidateToUpdate).CurrentValues.SetValues(candidate);

			if (candidate.Questionnaire != null)
				UpdateQuestionnaire(candidate, candidateToUpdate);

			_candidateRepo.Save(candidateToUpdate);

			return candidateToUpdate;
		}
		private static void UpdateQuestionnaire(Candidate candidate, Candidate candidateToUpdate)
		{
			Questionnaire questionnaireToUpdate =
				_questionnaireRepo.GetOne(candidate.Questionnaire.Id);

			if (questionnaireToUpdate != null)
				candidateToUpdate.Questionnaire = questionnaireToUpdate;
			else
			{
				_questionnaireRepo.Add(candidate.Questionnaire);
				candidateToUpdate.Questionnaire = candidate.Questionnaire;
			}
		}

		internal static void UpdateCandidatePassword(
			CandidateChangePasswordDTO candidateChangePassword)
		{
			Candidate candidate = _candidateRepo.GetOne(candidateChangePassword.CandidateId);
			candidate.ChangeLoginPassword(candidate.Login, candidateChangePassword.NewPassword);
			_candidateRepo.Save(candidate);
		}
		#endregion

		#region Questionnaire
		internal static Questionnaire UpdateQuestionnaire(int questionnaireId,
			Questionnaire questionnaire)
		{
			var questionnaireToUpdate = _questionnaireRepo.GetOne(questionnaireId);
			if (questionnaireToUpdate == null)
				return questionnaireToUpdate;

			_context.Entry(questionnaireToUpdate).CurrentValues.SetValues(questionnaire);

			if (questionnaire.Health != null)
				UpdateHealth(questionnaire, questionnaireToUpdate);

			if (questionnaire.Languages != null)
				UpdateLanguages(questionnaire.Languages.ToArray(),
					questionnaireToUpdate.Languages.ToArray(), questionnaireToUpdate.Id);

			if (questionnaire.Educations != null)
				UpdateEducations(questionnaire.Educations.ToArray(),
					questionnaireToUpdate.Educations.ToArray(), questionnaireToUpdate.Id);

			_questionnaireRepo.Save(questionnaireToUpdate);

			return questionnaireToUpdate;
		}
		private static void UpdateHealth(Questionnaire questionnaire,
			Questionnaire questionnaireToUpdate)
		{
			Health healthToUpdate =
				_healthRepo.GetOne(questionnaire.Health.Id);

			if (healthToUpdate != null)
				questionnaireToUpdate.Health = healthToUpdate;
			else
			{
				_healthRepo.Add(questionnaire.Health);
				questionnaireToUpdate.Health = questionnaire.Health;
			}
		}
		private static void UpdateLanguages(Language[] languages,
			Language[] languagesToUpdate, int questionnaireId)
		{
			for (int i = 0;
				i < Math.Min(languages.Length, languagesToUpdate.Length);
				i++)
			{
				Language newLanguage = languages[i];
				languagesToUpdate[i].Change(newLanguage.Name, newLanguage.Level);
			}

			if (languages.Length > languagesToUpdate.Length)
				for (int i = languagesToUpdate.Length; i < languages.Length; i++)
					CreateLanguage(new Language(languages[i].Name, languages[i].Level,
						questionnaireId));
			else if (languages.Length < languagesToUpdate.Length)
				for (int i = languages.Length; i < languagesToUpdate.Length; i++)
					DeleteLanguage(languagesToUpdate[i]);
		}
		private static void UpdateEducations(Education[] educations,
			Education[] educationsToUpdate, int questionnaireId)
		{
			for (int i = 0;
				i < Math.Min(educations.Length, educationsToUpdate.Length);
				i++)
			{
				Education newEducation = educations[i];
				educationsToUpdate[i].Change(newEducation.NameInstitution, newEducation.Specialty,
					newEducation.YearAdmission, newEducation.DateEnd,
					newEducation.EducationDegreeId, newEducation.EducationFormId);
			}

			if (educations.Length > educationsToUpdate.Length)
				for (int i = educationsToUpdate.Length; i < educations.Length; i++)
					CreateEducation(new Education(educations[i].NameInstitution,
						educations[i].Specialty, educations[i].YearAdmission,
						educations[i].DateEnd, questionnaireId, educations[i].EducationDegreeId,
						educations[i].EducationFormId));
			else if (educations.Length < educationsToUpdate.Length)
				for (int i = educations.Length; i < educationsToUpdate.Length; i++)
					DeleteEducation(educationsToUpdate[i]);
		}
		#endregion
		#endregion

		#region Delete
		internal static void DeleteVacancy(Vacancy vacancy) => _vacancyRepo.Delete(vacancy);
		internal static void DeleteEmployee(Employee employee) => _employeeRepo.Delete(employee);
		internal static void DeleteEducation(Education education)
			=> _educationRepo.Delete(education);
		internal static void DeleteLanguage(Language language) => _languageRepo.Delete(language);
		#endregion

		public static void Dispose()
		{
			_context?.Dispose();

			_employeeRepo?.Dispose();
			_interviewRepo?.Dispose();
			_applicationRepo?.Dispose();
			_candidateRepo?.Dispose();
			_educationRepo?.Dispose();
			_languageRepo?.Dispose();
			_questionnaireRepo?.Dispose();
			_vacancyRepo?.Dispose();
			_educationDegreeRequirementRepo?.Dispose();
			_requirementRepo?.Dispose();
			_pointRepo?.Dispose();
			_interviewStatusRepo?.Dispose();
			_familyStatusRepo?.Dispose();
			_businessTripOpportunityRepo?.Dispose();
			_healthRepo?.Dispose();
			_educationDegreeRepo?.Dispose();
			_educationFormRepo?.Dispose();
			_positionRepo?.Dispose();
		}
	}
}