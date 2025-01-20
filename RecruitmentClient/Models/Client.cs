using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using RecruitmentClient.Utilities.ClientUtilities;
using SharedModels.DTOs;
using SharedModels.Models;

namespace RecruitmentClient.Models
{
	internal class Client
	{// Клієнт
		private static readonly HttpClient httpClient;
		private readonly string _serverAddress;

		private readonly string _candidateLoginUrl
			= ConfigurationManager.AppSettings["candidateLoginUrl"];

		internal Client(IPAddress IPaddress, int port)
			=> _serverAddress = $"{IPaddress}:{port}";
		static Client()
		{
			httpClient = new HttpClient()
			{
				Timeout = TimeSpan.FromSeconds(3)
			};
		}

		internal async Task<Candidate> PostCandidateLoginAsync(CandidateLoginDTO candidateLoginDTO)
		{
			string jsonContent = JsonConvert.SerializeObject(candidateLoginDTO,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8,
				"application/json"))
			{
				HttpResponseMessage response = await httpClient.PostAsync($"http://{_serverAddress}{_candidateLoginUrl}", httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<Candidate>(jsonResponse);
			}
		}





















		private const int CHUNK_SIZE = 1024;// Розмір порції при передачі даних
		internal const char SEPARATOR = '¤';// Роздільник

		private static void Send(string message, NetworkStream stream)
		{// Метод відправляє байти до серверу
			byte[] bytes = Encoding.UTF8.GetBytes(message);
			int offset = 0;

			while (offset < bytes.Length)
			{// Поки не дійшли до кінця
			 // Розмір поточної порції
				int currentChunkSize = Math.Min(bytes.Length - offset, CHUNK_SIZE);

				// Записуємо в потік байти та зміщуємо offset
				stream.Write(bytes, offset, currentChunkSize);
				offset += currentChunkSize;
			}
		}
		private static string Read(NetworkStream stream)
		{// Метод зчитує байти від серверу
			List<byte> allBytes = new List<byte>();
			byte[] buffer = new byte[CHUNK_SIZE];
			int bytesRead;

			do
			{// Додаємо до списку масив байтів
				bytesRead = stream.Read(buffer, 0, buffer.Length);
				allBytes.AddRange(buffer.Take(bytesRead));
			} while (bytesRead > 0);

			return Encoding.UTF8.GetString(allBytes.ToArray());
		}

		private static void SendToServer(string message)
		{// Метод, який просто відправляє дані на сервер
			TcpClient client = new TcpClient("127.0.0.1", 7124);// Підключаємось
			NetworkStream stream = client.GetStream();

			Send(message, stream);// Відправляємо дані на сервер

			stream.Close();// Закриваємо stream та client
			client.Close();
		}
		private static string[] SendToServerAndGetResult(string message)
		{// Метод, який відправляє дані на сервер та повертає результат
			TcpClient client = new TcpClient("127.0.0.1", 7124);// Підключаємось
			NetworkStream stream = client.GetStream();

			Send(message, stream);// Відправляємо дані на сервер

			string response = Read(stream);

			stream.Close();// Закриваємо stream та client
			client.Close();

			// Отримуємо масив рядків відповідей
			string[] arr = response.Split(SEPARATOR);
			for (int i = 0; i < arr.Length; i++)
				if (arr[i] == "NULL")
					arr[i] = "";

			return arr;
		}

		internal static int GetCountVacancies(string login, ClientSearcher searcher)
		{// Метод повертає кількість вакансій для користувача
			string condition = string.Empty;
			if (searcher != null)
				condition = searcher.GetFilter("date_publication");

			return Int32.Parse(SendToServerAndGetResult("SELECT COUNT(id) as id FROM View_Vacancy " +
				"WHERE relevance = 'True' AND (SELECT COUNT(id) FROM Application " +
				"WHERE id_vacancy = View_Vacancy.id AND id_candidate = " +
				$"(SELECT id FROM Candidate WHERE login = '{login}')) = 0 {condition}")[0]);
		}
		internal static List<Vacancy> GetFreeVacancies(string login, int offset, int amount, ClientSearcher searcher)
		{// Метод, який повертає список актуальних вакансій, на які ще не відправляв заявки користувач
			List<Vacancy> vacancies = new List<Vacancy>();
			string condition = string.Empty, orderBy;
			if (searcher != null)
			{
				condition = searcher.GetFilter("date_publication");
				orderBy = searcher.GetSort("date_publication");
			}
			else
			{ orderBy = "ORDER BY date_publication DESC"; }

			string[] arr = SendToServerAndGetResult("SELECT id,position_name,position_description,salary,date_publication,info " +
				"FROM View_Vacancy WHERE relevance = 'True' AND " +
				"(SELECT COUNT(id) FROM Application WHERE id_vacancy = View_Vacancy.id AND id_candidate = " +
				$"(SELECT id FROM Candidate WHERE login = '{login}')) = 0 {condition} {orderBy} " +
				$"OFFSET {offset} ROWS FETCH NEXT {amount} ROWS ONLY");

			if (arr.Length < 6)
				return null;
			for (int i = 0; i < arr.Length; i += 6)
			{
				vacancies.Add(new Vacancy(Int32.Parse(arr[i]), arr[i + 1], arr[i + 2], Decimal.Parse(arr[i + 3]), DateTime.Parse(arr[i + 4]).ToLocalTime(), arr[i + 5]));
			}

			return vacancies;
		}
		internal static int GetCountApplications(string login, ClientSearcher searcher)
		{// Метод повертає кількість заявок користувача
			string condition = string.Empty;
			if (searcher != null)
				condition = searcher.GetFilter("date_submission");

			return Int32.Parse(SendToServerAndGetResult("SELECT COUNT(id) as id FROM View_Application " +
				$"WHERE id_candidate = (SELECT id FROM Candidate WHERE login = '{login}') {condition}")[0]);
		}
		internal static List<Application> GetApplications(string login, int offset, int amount, ClientSearcher searcher)
		{// Метод, який повертає список заявок, які відправляв користувач
			List<Application> applications = new List<Application>();
			string condition = string.Empty, orderBy;
			if (searcher != null)
			{
				condition = searcher.GetFilter("date_submission");
				orderBy = searcher.GetSort("date_submission");
			}
			else
			{ orderBy = "ORDER BY date_submission DESC"; }

			string[] arr = SendToServerAndGetResult("SELECT position_name,position_description," +
				"status,date_submission,reason_rejection " +
				"FROM View_Application WHERE id_candidate = " +
				$"(SELECT id FROM Candidate WHERE login = '{login}') {condition} {orderBy} " +
				$"OFFSET {offset} ROWS FETCH NEXT {amount} ROWS ONLY");

			if (arr.Length < 5)
				return null;
			for (int i = 0; i < arr.Length; i += 5)
			{
				applications.Add(new Application(arr[i], arr[i + 1],
					arr[i + 2],
					DateTime.Parse(arr[i + 3]).ToLocalTime(), arr[i + 4]));
			}

			return applications;
		}
		internal static int GetCountInterviews(string login, ClientSearcher searcher)
		{// Метод повертає кількість співбесід користувача
			string condition = string.Empty;
			if (searcher != null)
				condition = searcher.GetFilter("date_event");

			return Int32.Parse(SendToServerAndGetResult("SELECT COUNT(id) as id FROM View_Interview " +
				"WHERE id_application IN (SELECT id FROM Application " +
				$"WHERE id_candidate = (SELECT id FROM Candidate WHERE login = '{login}')) {condition}")[0]);
		}
		internal static List<Interview> GetInterviews(string login, int offset, int amount, ClientSearcher searcher)
		{// Метод, який повертає список заявок, які відправляв користувач
			List<Interview> interviews = new List<Interview>();
			string condition = string.Empty, orderBy;
			if (searcher != null)
			{
				condition = searcher.GetFilter("date_event");
				orderBy = searcher.GetSort("date_event");
			}
			else
			{ orderBy = "ORDER BY date_event DESC"; }

			string[] arr = SendToServerAndGetResult("SELECT position_name," +
				"position_description,status,date_event " +
				"FROM View_Interview WHERE id_application IN " +
				"(SELECT id FROM Application  WHERE id_candidate = " +
				$"(SELECT id FROM Candidate WHERE login = '{login}')) {condition} {orderBy} " +
				$"OFFSET {offset} ROWS FETCH NEXT {amount} ROWS ONLY");

			if (arr.Length < 4)
				return null;
			for (int i = 0; i < arr.Length; i += 4)
			{
				interviews.Add(new Interview(arr[i], arr[i + 1], arr[i + 2],
					DateTime.Parse(arr[i + 3]).ToLocalTime()));
			}

			return interviews;
		}

		internal static Requirement GetRequirement(int vacancyId)
		{// Метод, який повертає вимоги для заданої вакансії
			string[] arr = SendToServerAndGetResult($"SELECT city,age_min,age_max," +
				$"exp_min,diploma,no_chronic_diseases,driver_license,no_smoker," +
				$"no_drink_alcohol,business_trip_opportunity,student" +
				$" FROM Requirement WHERE Requirement.id = (SELECT id FROM Vacancy WHERE id = {vacancyId})");

			string city = arr[0] == "" ? null : arr[0];
			bool? student;// Знаходимо вимогу "student"
			if (arr[10] == "")
				student = null;
			else
				student = bool.Parse(arr[10]);

			return new Requirement(city, byte.Parse(arr[1]), byte.Parse(arr[2]), int.Parse(arr[3]), bool.Parse(arr[4]), bool.Parse(arr[5]), bool.Parse(arr[6]), bool.Parse(arr[7]), bool.Parse(arr[8]), bool.Parse(arr[9]), student);
		}
		internal static string GetRequirementEducationDegree(int vacancyId)
		{// Метод, який повертає вимоги до ступенів освіти для заданої вакансії
			string[] arr = SendToServerAndGetResult("SELECT degree FROM Education_Degree WHERE id IN " +
				"(SELECT id_education_degree FROM EducationDegree_Requirement " +
				$"WHERE id_requirement = (SELECT id_requirement FROM Vacancy WHERE Vacancy.id = {vacancyId}))");

			if (arr.Length == 1 && arr[0] == "")// Якщо результату немає
				return null;

			string s = string.Empty;
			for (int i = 0; i < arr.Length; i++)
				s += $"{arr[i]}, ";

			return s.TrimEnd(' ').TrimEnd(',').ToLower();

		}

		internal static string[] GetFamilyStatuses() // Сімейні стани
			=> SendToServerAndGetResult("SELECT status FROM Family_Status ORDER BY id");
		internal static string[] GetBusinessTripOpportunities() // Можливості відряджень
			=> SendToServerAndGetResult("SELECT opportunity FROM Business_Trip_Opportunity ORDER BY id");

		// Методи для перевірки унікальності
		private static bool CandidateDataIsUnique(string login, string dbField, string value)
		{// Метод, який перевіряє значення поля кандидата на унікальність
			string message = $"SELECT COUNT(id) FROM Candidate WHERE {dbField} = '{value}'";
			if (login != null)// Якщо логін вказаний
				message += $" AND login != '{login}'";

			string[] arr = SendToServerAndGetResult(message);
			if (Int32.Parse(arr[0]) > 0)// Якщо унікальність відсутня
				return false;
			return true;
		}
		internal static bool EmailIsUnique(string login, string email) => CandidateDataIsUnique(login, "email", email);
		internal static bool PhoneIsUnique(string login, string phone) => CandidateDataIsUnique(login, "phone", phone);
		internal static bool LoginIsUnique(string login) => CandidateDataIsUnique(null, "login", login);

		// Методи для зміни даних на сервері
		private static string Change(string field, string oldS, string newS, bool isString = true)
		{
			string res = string.Empty;
			if (oldS != newS)
			{
				if (newS == "")
				{
					newS = "NULL";
					isString = false;
				}
				if (isString)
					res += $" {field} = '{newS}',";
				else
					res += $" {field} = {newS},";
			}
			return res;
		}
		private static string Change(string field, int oldI, int newI)
			=> Change(field, oldI.ToString(), newI.ToString(), false);
		private static string Change(string field, bool oldB, bool newB)
			=> Change(field, oldB.ToString(), newB.ToString());
		private static void ChangeHealth(string login, Health oldH, Health newH)
		{// Метод, який змінює здоров’я на сервері
			string message = "UPDATE Health SET";
			message += Change("chronic_diseases", oldH.ChronicDiseases, newH.ChronicDiseases);
			message += Change("smoker", oldH.Smoker, newH.Smoker);
			message += Change("drink_alcohol", oldH.DrinkAlcohol, newH.DrinkAlcohol);
			message = message.TrimEnd(',');// Видаляємо останню кому

			if (message != "UPDATE Health SET")// Якщо потрібно змінити дані
				SendToServer(message + $" WHERE id = (SELECT id_health FROM Questionnaire " +
					$"WHERE id = (SELECT id_questionnaire FROM Candidate WHERE login = '{login}'))");
		}
		private static void ChangeLanguages(string login, List<Language> oldL, List<Language> newL)
		{// Метод, який змінює мови на сервері
			int n = Math.Min(oldL.Count, newL.Count);
			string condition = $" WHERE id_questionnaire = (SELECT id_questionnaire" +
				$" FROM Candidate WHERE login = '{login}')";
			for (int i = 0; i < n; i++)
			{
				string message = "UPDATE Language SET";
				message += Change("name", oldL[i].Name, newL[i].Name);
				message += Change("level", oldL[i].Level, newL[i].Level);
				message = message.TrimEnd(',');// Видаляємо останню кому

				if (message != "UPDATE Language SET")// Якщо потрібно змінити дані
					SendToServer(message + condition + $" AND name = '{oldL[i].Name}'");
			}

			if (oldL.Count > newL.Count)// Якщо кількість мов зменшилась
				for (int i = newL.Count; i < oldL.Count; i++)
					SendToServer("DELETE FROM Language" + condition + $" AND name = '{oldL[i].Name}'");

			else if (oldL.Count < newL.Count)// Якщо кількість мов збільшилась
				SendToServer(CreateLanguages(newL.GetRange(oldL.Count, newL.Count - oldL.Count),
					$"(SELECT id_questionnaire FROM Candidate WHERE login = '{login}')"));
		}
		private static void ChangeEducations(string login, List<Education> oldE, List<Education> newE)
		{// Метод, який змінює освіти на сервері
			int n = Math.Min(oldE.Count, newE.Count);
			string condition = $" WHERE id_questionnaire = (SELECT id_questionnaire" +
				$" FROM Candidate WHERE login = '{login}')";
			for (int i = 0; i < n; i++)
			{
				string message = "UPDATE Education SET";
				message += Change("name_institution", oldE[i].NameInstitution, newE[i].NameInstitution);
				message += Change("specialty", oldE[i].Specialty, newE[i].Specialty);
				message += Change("year_admission", oldE[i].YearAdmission, newE[i].YearAdmission);
				message += Change("date_end", oldE[i].DateEnd.ToString("yyyy-MM-dd"), newE[i].DateEnd.ToString("yyyy-MM-dd"));
				message += Change("id_education_degree", oldE[i].EducationDegreeId, newE[i].EducationDegreeId);
				message += Change("id_education_form", oldE[i].EducationFormId, newE[i].EducationFormId);
				message = message.TrimEnd(',');// Видаляємо останню кому

				if (message != "UPDATE Education SET")// Якщо потрібно змінити дані
					SendToServer(message + condition + $" AND name_institution = '{oldE[i].NameInstitution}'" +
						$" AND specialty = '{oldE[i].Specialty}' AND year_admission = {oldE[i].YearAdmission}" +
						$" AND date_end = '{oldE[i].DateEnd:yyyy-MM-dd}' AND id_education_degree =" +
						$" {oldE[i].EducationDegreeId} AND id_education_form = {oldE[i].EducationFormId}");
			}

			if (oldE.Count > newE.Count)// Якщо кількість освіт зменшилась
				for (int i = newE.Count; i < oldE.Count; i++)
					SendToServer("DELETE FROM Education" + condition + $" AND name_institution = '{oldE[i].NameInstitution}'" +
						$" AND specialty = '{oldE[i].Specialty}' AND year_admission = {oldE[i].YearAdmission}" +
						$" AND date_end = '{oldE[i].DateEnd:yyyy-MM-dd}' AND id_education_degree =" +
						$" {oldE[i].EducationDegreeId} AND id_education_form = {oldE[i].EducationFormId}");

			else if (oldE.Count < newE.Count)// Якщо кількість освіт збільшилась
				SendToServer(CreateEducations(newE.GetRange(oldE.Count, newE.Count - oldE.Count),
					$"(SELECT id_questionnaire FROM Candidate WHERE login = '{login}')"));
		}


		internal static void ChangeQuestionnaire(string login, Questionnaire oldQ, Questionnaire newQ)
		{// Метод, який змінює анкету на сервері
			string message = "UPDATE Questionnaire SET";
			message += Change("nationality", oldQ.Nationality, newQ.Nationality);
			message += Change("city", oldQ.City, newQ.City);
			message += Change("children_amount", oldQ.ChildrenAmount, newQ.ChildrenAmount);
			message += Change("experience", oldQ.Experience, newQ.Experience);
			message += Change("driver_license", oldQ.DriverLicense, newQ.DriverLicense);
			message += Change("readiness", oldQ.Readiness, newQ.Readiness);
			message += Change("additional_info", oldQ.AdditionalInfo, newQ.AdditionalInfo);
			message += Change("id_family_status", oldQ.FamilyStatusId, newQ.FamilyStatusId);
			message += Change("id_business_trip_opportunity", oldQ.BusinessTripOpportunityId, newQ.BusinessTripOpportunityId);
			message = message.TrimEnd(',');// Видаляємо останню кому

			if (message != "UPDATE Questionnaire SET")// Якщо потрібно змінити дані
				SendToServer(message + $" WHERE id = (SELECT id_questionnaire FROM Candidate WHERE login = '{login}')");

			ChangeHealth(login, oldQ.Health, newQ.Health);
			ChangeLanguages(login, oldQ.Languages.ToList(), newQ.Languages.ToList());
			ChangeEducations(login, oldQ.Educations.ToList(), newQ.Educations.ToList());
		}
		internal static void ChangeCandidate(string login, Candidate oldC, Candidate newC)
		{// Метод, який змінює кандидата на сервері
			string message = "UPDATE Candidate SET";
			message += Change("surname", oldC.Surname, newC.Surname);
			message += Change("name", oldC.Name, newC.Name);
			message += Change("father_name", oldC.FatherName, newC.FatherName);
			message += Change("phone", oldC.Phone, newC.Phone);
			message += Change("birthday", oldC.Birthday.ToString("yyyy-MM-dd"), newC.Birthday.ToString("yyyy-MM-dd"));
			message += Change("email", oldC.Email, newC.Email);
			message = message.TrimEnd(',');// Видаляємо останню кому

			if (message != "UPDATE Candidate SET")// Якщо потрібно змінити дані
				SendToServer(message + $" WHERE login = '{login}'");
		}
		internal static void ChangePassword(string login, string oldPassword, string newPassword)
		{// Метод змінює пароль кандидата
			SendToServer($"UPDATE Candidate SET password = '{newPassword}' " +
				$"WHERE login = '{login}' AND password = '{oldPassword}'");
		}

		// Методи для створення даних на сервері
		private static string CreateLanguages(List<Language> languages, string idQuestionnaire)
		{// Метод який повертає запит створення мов
			string res = string.Empty;

			foreach (Language item in languages)
				res += $"INSERT INTO Language(name,level,id_questionnaire) " +
				$"values('{item.Name}',{item.Level},{idQuestionnaire}) ";

			return res;
		}
		private static string CreateEducations(List<Education> educations, string idQuestionnaire)
		{// Метод який повертає запит створення освіт
			string res = string.Empty;

			foreach (Education item in educations)
				res += $"INSERT INTO Education(name_institution,specialty,year_admission," +
					$"date_end,id_questionnaire,id_education_degree,id_education_form) " +
					$"values('{item.NameInstitution}','{item.Specialty}',{item.YearAdmission}," +
					$"'{item.DateEnd:yyyy-MM-dd}',{idQuestionnaire},{item.EducationDegreeId},{item.EducationFormId}) ";

			return res;
		}
		internal static void CreateCandidate(Account account)
		{// Метод який створює на сервері кандидата

			// Оголошуємо змінні
			Candidate candidate = account.candidate;
			Questionnaire questionnaire = candidate.Questionnaire;
			Health health = questionnaire.Health;

			string fatherName = candidate.FatherName == "" ? "NULL" : $"'{candidate.FatherName}'";
			string chronicDiseases = health.ChronicDiseases == "" ? "NULL" : $"'{health.ChronicDiseases}'";
			string info = questionnaire.AdditionalInfo == "" ? "NULL" : $"'{questionnaire.AdditionalInfo}'";

			// Відправляємо запит
			SendToServer($"INSERT INTO Health(chronic_diseases,smoker,drink_alcohol) " +
				$"values({chronicDiseases}, '{health.Smoker}', '{health.DrinkAlcohol}') " +
				$"INSERT INTO Questionnaire(nationality,city,children_amount,experience,driver_license,readiness,additional_info, " +
				$"id_health,id_family_status,id_business_trip_opportunity) " +
				$"values('{questionnaire.Nationality}','{questionnaire.City}',{questionnaire.ChildrenAmount}, " +
				$"{questionnaire.Experience},'{questionnaire.DriverLicense}',{questionnaire.Readiness}, " +
				$"{info},SCOPE_IDENTITY(),{questionnaire.FamilyStatusId}, " +
				$"{questionnaire.BusinessTripOpportunityId}) " +
				$"DECLARE @id_q int " +
				$"SET @id_q = SCOPE_IDENTITY() " + CreateLanguages(questionnaire.Languages.ToList(), "@id_q") +
				CreateEducations(questionnaire.Educations.ToList(), "@id_q") +
				$"INSERT INTO Candidate(surname,name,father_name,login,password,phone,birthday,email,id_questionnaire) " +
				$"values('{candidate.Surname}','{candidate.Name}',{fatherName},'{account.Login}', " +
				$"'{account.Password}','{candidate.Phone}','{candidate.Birthday:yyyy-MM-dd}','{candidate.Email}',@id_q)");
		}
		internal static void CreateApplication(string login, string info, int vacancyId)
		{// Метод, який створює заявку на роботу
			info = info == "" ? "NULL" : $"'{info}'";
			SendToServer("INSERT INTO Application(date_submission,additional_info,id_application_status,id_candidate,id_vacancy)" +
				$" values('{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}',{info},1,(SELECT id FROM Candidate WHERE login = '{login}'),{vacancyId})");
		}
	}
}