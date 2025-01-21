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

using SharedModels.DTOs;
using SharedModels.Models;
using SharedModels.Search;

namespace RecruitmentClient.Models
{
	internal class Client
	{
		private const string HTTP_PREFIX = "http://";
		private const string MEDIA_TYPE = "application/json";

		private static readonly HttpClient httpClient;
		private readonly string _serverAddress;

		private readonly string _candidateLoginUrl
			= ConfigurationManager.AppSettings["candidateLoginUrl"];
		private readonly string _vacanciesCountUrl
			= ConfigurationManager.AppSettings["vacanciesCountUrl"];
		private readonly string _vacanciesUrl
			= ConfigurationManager.AppSettings["vacanciesUrl"];
		private readonly string _applicationsCountUrl
			= ConfigurationManager.AppSettings["applicationsCountUrl"];
		private readonly string _applicationsCreateUrl
			= ConfigurationManager.AppSettings["applicationsCreateUrl"];
		private readonly string _applicationsUrl
			= ConfigurationManager.AppSettings["applicationsUrl"];
		private readonly string _interviewsCountUrl
			= ConfigurationManager.AppSettings["interviewsCountUrl"];
		private readonly string _interviewsUrl
			= ConfigurationManager.AppSettings["interviewsUrl"];

		internal Client(IPAddress IPaddress, int port)
			=> _serverAddress = $"{HTTP_PREFIX}{IPaddress}:{port}";
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

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_candidateLoginUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<Candidate>(jsonResponse);
			}
		}

		#region Vacancy
		internal async Task<int> PostFreeVacanciesCountAsync(
			AccountSearchSettingsDTO accountSearch)
		{
			string jsonContent = JsonConvert.SerializeObject(accountSearch,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_vacanciesCountUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<int>(jsonResponse);
			}
		}
		internal async Task<List<Vacancy>> PostFreeVacanciesAsync(
			PagedAccountSearchSettingsDTO pagedAccountSearch)
		{
			string jsonContent = JsonConvert.SerializeObject(pagedAccountSearch,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_vacanciesUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<Vacancy>>(jsonResponse);
			}
		}
		#endregion

		#region Application
		internal async Task<int> PostApplicationsCountAsync(
			AccountSearchSettingsDTO accountSearch)
		{
			string jsonContent = JsonConvert.SerializeObject(accountSearch,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_applicationsCountUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<int>(jsonResponse);
			}
		}
		internal async Task PostApplicationsCreateAsync(Application application)
		{
			string jsonContent = JsonConvert.SerializeObject(application,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_applicationsCreateUrl, httpContent);
				response.EnsureSuccessStatusCode();
			}
		}
		internal async Task<List<Application>> PostApplicationsAsync(
			PagedAccountSearchSettingsDTO pagedAccountSearch)
		{
			string jsonContent = JsonConvert.SerializeObject(pagedAccountSearch,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_applicationsUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<Application>>(jsonResponse);
			}
		}
		#endregion


		#region Interview
		internal async Task<int> PostInterviewsCountAsync(
			AccountSearchSettingsDTO accountSearch)
		{
			string jsonContent = JsonConvert.SerializeObject(accountSearch,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_interviewsCountUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<int>(jsonResponse);
			}
		}
		internal async Task<List<Interview>> PostInterviewsAsync(
			PagedAccountSearchSettingsDTO pagedAccountSearch)
		{
			string jsonContent = JsonConvert.SerializeObject(pagedAccountSearch,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_interviewsUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<Interview>>(jsonResponse);
			}
		}
		#endregion














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
	}
}