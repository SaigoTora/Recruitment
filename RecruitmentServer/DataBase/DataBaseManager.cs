using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using RecruitmentServer.Database.Repositories;
using RecruitmentServer.Database.Repositories.Base;
using RecruitmentServer.Models;
using SharedModels.DTOs;
using SharedModels.Models;
using SharedModels.Search;
using SharedModels.Static;

namespace RecruitmentServer.Database
{
	internal static class DatabaseManager
	{
		private static readonly RecruitmentEntities _context;

		private static readonly EmployeeRepo _employeeRepo;
		private static readonly InterviewRepo _interviewRepo;
		private static readonly ApplicationRepo _applicationRepo;
		private static readonly BaseRepo<Candidate> _candidateRepo;
		private static readonly BaseRepo<Education> _educationRepo;
		private static readonly BaseRepo<Language> _languageRepo;
		private static readonly BaseRepo<Questionnaire> _questionnaireRepo;
		private static readonly VacancyRepo _vacancyRepo;
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

			_employeeRepo = new EmployeeRepo(_context);
			_interviewRepo = new InterviewRepo(_context);
			_applicationRepo = new ApplicationRepo(_context);
			_candidateRepo = new BaseRepo<Candidate>(_context);
			_educationRepo = new BaseRepo<Education>(_context);
			_languageRepo = new BaseRepo<Language>(_context);
			_questionnaireRepo = new BaseRepo<Questionnaire>(_context);
			_vacancyRepo = new VacancyRepo(_context);
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
			DatabaseValidator.CheckValidCandidate(candidate);
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
		internal static void CreateApplication(CreateApplicationDTO createApplication)
		{
			int DEFAULT_STATUS_ID = 1;

			Candidate candidate = GetCandidate(createApplication.CandidateLogin);
			Vacancy vacancy = GetVacancy(createApplication.VacancyId);
			Application application = new Application(DateTime.UtcNow,
				createApplication.AdditionalInfo, DEFAULT_STATUS_ID, candidate.Id, vacancy.Id);

			_applicationRepo.Add(application);
		}
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
		{
			Candidate candidate = _candidateRepo.GetAll().FirstOrDefault(c =>
				c.Login == candidateLogin.Login && c.Password == candidateLogin.Password);

			return candidate
				?? throw new UnauthorizedAccessException("Invalid login or password.");
		}

		internal static Requirement GetRequirement(int requirementId)
			=> _requirementRepo.GetOne(requirementId);
		internal static Point GetPoint(int pointId) => _pointRepo.GetOne(pointId);

		internal static FamilyStatus GetFamilyStatus(int familyStatusId)
		{
			FamilyStatus familyStatus = _familyStatusRepo.GetOne(familyStatusId);

			return familyStatus
				?? throw new KeyNotFoundException($"Family status with id {familyStatusId} " +
				$"was not found.");
		}
		internal static BusinessTripOpportunity GetBusinessTripOpportunity(
			int businessTripOpportunityId)
		{
			BusinessTripOpportunity businessTripOpportunity
				= _businessTripOpportunityRepo.GetOne(businessTripOpportunityId);

			return businessTripOpportunity
				?? throw new KeyNotFoundException($"Business trip opportunity with id " +
				$"{businessTripOpportunityId} was not found.");
		}
		internal static EducationDegree GetEducationDegree(int educationDegreeId)
		{
			EducationDegree educationDegree = _educationDegreeRepo.GetOne(educationDegreeId);

			return educationDegree
				?? throw new KeyNotFoundException($"Education degree with id " +
				$"{educationDegreeId} was not found.");
		}
		internal static EducationForm GetEducationForm(int educationFormId)
		{
			EducationForm educationForm = _educationFormRepo.GetOne(educationFormId);

			return educationForm
				?? throw new KeyNotFoundException($"Education form with id {educationFormId} " +
				$"was not found.");
		}

		#region Vacancy
		internal static Vacancy GetVacancy(int vacancyId)
		{
			Vacancy vacancy = _vacancyRepo.GetOne(vacancyId);

			return vacancy
				?? throw new KeyNotFoundException($"Vacancy with id {vacancyId} " +
				$"was not found.");
		}
		internal static int GetVacanciesCount(FullSearcher searcher)
			=> _vacancyRepo.GetFilteredCount(searcher);
		internal static List<Vacancy> GetVacancies(int index, int count,
			FullSearcher searcher)
			=> _vacancyRepo.GetFiltered(index, count, searcher);
		internal static int GetVacanciesCount(AccountSearchSettingsDTO accountSearch)
		{
			Candidate candidate = GetCandidate(accountSearch.CandidateLogin);
			return _vacancyRepo.GetFilteredCount(candidate, accountSearch);
		}
		internal static List<Vacancy> GetVacancies(
			PagedAccountSearchSettingsDTO pagedAccountSearch)
		{
			Candidate candidate = GetCandidate(pagedAccountSearch.CandidateLogin);
			return _vacancyRepo.GetFiltered(candidate, pagedAccountSearch);
		}
		#endregion

		#region Application
		internal static Application GetApplication(int applicationId)
			=> _applicationRepo.GetOne(applicationId);
		internal static Application GetApplication(int vacancyId, int candidateId)
			=> _applicationRepo.GetAll().
				Find(a => a.VacancyId == vacancyId && a.CandidateId == candidateId);

		internal static int GetApplicationsCount(FullSearcher searcher)
			=> _applicationRepo.GetFilteredCount(searcher);
		internal static List<Application> GetApplications(int index, int count,
			FullSearcher searcher)
			=> _applicationRepo.GetFiltered(index, count, searcher);
		internal static int GetApplicationsCount(AccountSearchSettingsDTO accountSearch)
		{
			Candidate candidate = GetCandidate(accountSearch.CandidateLogin);
			return _applicationRepo.GetFilteredCount(candidate, accountSearch);
		}
		internal static List<Application> GetApplications(
			PagedAccountSearchSettingsDTO pagedAccountSearch)
		{
			Candidate candidate = GetCandidate(pagedAccountSearch.CandidateLogin);
			return _applicationRepo.GetFiltered(candidate, pagedAccountSearch);
		}
		#endregion

		#region Interview
		internal static int GetInterviewsCount(FullSearcher searcher)
			=> _interviewRepo.GetFilteredCount(searcher);
		internal static List<Interview> GetInterviews(int index, int count,
			FullSearcher searcher)
			=> _interviewRepo.GetFiltered(index, count, searcher);
		internal static int GetInterviewsCount(AccountSearchSettingsDTO accountSearch)
		{
			Candidate candidate = GetCandidate(accountSearch.CandidateLogin);
			return _interviewRepo.GetFilteredCount(candidate, accountSearch);
		}
		internal static List<Interview> GetInterviews(
			PagedAccountSearchSettingsDTO pagedAccountSearch)
		{
			Candidate candidate = GetCandidate(pagedAccountSearch.CandidateLogin);
			return _interviewRepo.GetFiltered(candidate, pagedAccountSearch);
		}
		#endregion

		#region Employee
		internal static int GetEmployeesCount(FullSearcher searcher)
			=> _employeeRepo.GetFilteredCount(searcher);
		internal static List<Employee> GetEmployees(int index, int count,
			FullSearcher searcher)
			=> _employeeRepo.GetFiltered(index, count, searcher);
		#endregion

		#region Check unique
		internal static bool CheckCandidateLoginUnique(StringDataUniqueDTO stringDataUnique)
			=> !_candidateRepo.GetAll().Any(c => c.Login == stringDataUnique.Data);
		internal static bool CheckCandidatePhoneUnique(StringDataUniqueDTO stringDataUnique)
		{
			CandidateLoginDTO candidateLogin = stringDataUnique.CandidateLogin;

			return !_candidateRepo.GetAll().Any(c => c.Phone == stringDataUnique.Data
				&& candidateLogin.Login != c.Login && candidateLogin.Password != c.Password);
		}
		internal static bool CheckCandidateEmailUnique(StringDataUniqueDTO stringDataUnique)
		{
			CandidateLoginDTO candidateLogin = stringDataUnique.CandidateLogin;

			return !_candidateRepo.GetAll().Any(c => c.Email == stringDataUnique.Data
				&& candidateLogin.Login != c.Login && candidateLogin.Password != c.Password);
		}
		#endregion

		#region Static data
		internal static StaticData GetStaticData()
			=> new StaticData(GetFamilyStatuses(), GetBusinessTripOpportunities(),
				GetEducationDegrees(), GetEducationForms());

		private static FamilyStatus[] GetFamilyStatuses()
			=> _familyStatusRepo.GetAll().OrderBy(fs => fs.Id).ToArray();
		private static BusinessTripOpportunity[] GetBusinessTripOpportunities()
			=> _businessTripOpportunityRepo.GetAll().OrderBy(bto => bto.Id).ToArray();
		private static EducationDegree[] GetEducationDegrees()
			=> _educationDegreeRepo.GetAll().OrderBy(ed => ed.Id).ToArray();
		private static EducationForm[] GetEducationForms()
			=> _educationFormRepo.GetAll().OrderBy(ef => ef.Id).ToArray();
		#endregion

		internal static List<AssignmentItem> GetAssignmentItems()
		{// Select data where vacancies are relevant, applications have the status "Pending",
		 // and there are no interviews with the status "Candidate invited"
		 // or "Candidate awaiting decision".
			var assignmentItems = _context.Vacancies
				.Where(v => v.Relevance)
				.SelectMany(v => v.Applications
					.Where(a => a.ApplicationStatus.Status == "В очікуванні")
					.Where(a => !_context.Interviews
						.Any(i => i.Application.VacancyId == v.Id
							&& (i.InterviewStatus.Status == "Кандидат запрошений"
							|| i.InterviewStatus.Status == "Кандидат чекає на рішення")))
					.Select(a => new AssignmentItem()
					{
						VacancyId = v.Id,
						CandidateId = a.CandidateId,
						Scores = a.Scores
					}))
					.OrderBy(ai => ai.VacancyId)
					.ThenBy(ai => ai.CandidateId)
					.ToList();

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
		internal static Candidate UpdateCandidate(Candidate candidate)
		{
			Candidate candidateToUpdate = GetCandidate(new CandidateLoginDTO(candidate.Login,
				candidate.Password));

			DatabaseValidator.CheckValidCandidate(candidate);
			if (candidateToUpdate == null)
				return candidateToUpdate;

			_context.Entry(candidateToUpdate).CurrentValues.SetValues(candidate);

			if (candidate.Questionnaire != null)
				UpdateQuestionnaire(candidate, candidateToUpdate);

			_candidateRepo.Save(candidateToUpdate);

			return candidateToUpdate;
		}
		private static void UpdateQuestionnaire(Candidate candidate,
			Candidate candidateToUpdate)
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
			Candidate candidate = GetCandidate(candidateChangePassword.CandidateLogin);
			DatabaseValidator.CheckValidLoginPassword(
				candidateChangePassword.CandidateLogin.Login,
				candidateChangePassword.NewPassword);

			candidate.ChangeLoginPassword(candidate.Login, candidateChangePassword.NewPassword);
			_candidateRepo.Save(candidate);
		}
		#endregion

		#region Questionnaire
		internal static Questionnaire UpdateQuestionnaire(
			QuestionnaireChangeDTO questionnaire)
		{
			Candidate candidate = GetCandidate(questionnaire.CandidateLogin);
			var questionnaireToUpdate = _questionnaireRepo.GetOne(candidate.QuestionnaireId);

			DatabaseValidator.CheckValidQuestionnaire(questionnaire.Questionnaire);
			if (questionnaireToUpdate == null)
				return questionnaireToUpdate;

			_context.Entry(questionnaireToUpdate).CurrentValues.SetValues(
				questionnaire.Questionnaire);

			if (questionnaire.Questionnaire.Health != null)
				UpdateHealth(questionnaire.Questionnaire, questionnaireToUpdate);

			if (questionnaire.Questionnaire.Languages != null)
				UpdateLanguages(questionnaire.Questionnaire.Languages.ToArray(),
					questionnaireToUpdate.Languages.ToArray(), questionnaireToUpdate.Id);

			if (questionnaire.Questionnaire.Educations != null)
				UpdateEducations(questionnaire.Questionnaire.Educations.ToArray(),
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
				educationsToUpdate[i].Change(newEducation.NameInstitution,
					newEducation.Specialty, newEducation.YearAdmission, newEducation.DateEnd,
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
		internal static void DeleteEmployee(Employee employee)
			=> _employeeRepo.Delete(employee);
		internal static void DeleteEducation(Education education)
			=> _educationRepo.Delete(education);
		internal static void DeleteLanguage(Language language)
			=> _languageRepo.Delete(language);
		#endregion

		internal static void Dispose()
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