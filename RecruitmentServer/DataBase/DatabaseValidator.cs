using System;
using System.Text.RegularExpressions;

using RecruitmentLibrary.Validation;
using SharedModels.Models;

namespace RecruitmentServer.DataBase
{
	internal class DatabaseValidator
	{
		#region Candidate
		internal static void CheckValidCandidate(Candidate candidate)
		{
			CheckValidLoginPassword(candidate.Login, candidate.Password);
			CheckValidFullName(candidate);
			CheckValidPhoneNumber(candidate);
			CheckValidEmail(candidate.Email);
			CheckValidBirthday(candidate.Birthday);
			CheckValidQuestionnaire(candidate.Questionnaire);
		}
		internal static void CheckValidLoginPassword(string login, string password)
		{
			CheckValidSymbols(login, "Candidate's login", "._-0123456789", ValidLanguage.English);
			CheckValidInterval(login, "Candidate's login", 4, 16);

			CheckValidSymbols(password, "Candidate's password", "@-_.*0123456789",
				ValidLanguage.English);
			CheckValidInterval(password, "Candidate's password", 8, 16);
			if (!Validator.CheckMinCountSymbols(password, 2, "0123456789"))
				throw new ArgumentException("Password must contain at least 2 digits.");
			if (!Validator.CheckMinCountSymbols(password, 4,
				Validator.GetAllowedCharactersForLanguage(ValidLanguage.English)))
				throw new ArgumentException("Password must contain at least 4 English letters.");

			if (login == password)
				throw new ArgumentException("Login and password cannot be the same.");
		}

		private static void CheckValidFullName(Candidate candidate)
		{
			CheckValidSymbols(candidate.Surname, "Candidate's surname", "'-");
			CheckValidInterval(candidate.Surname, "Candidate's surname", 2, 64);

			CheckValidSymbols(candidate.Name, "Candidate's name", "'-");
			CheckValidInterval(candidate.Name, "Candidate's name", 2, 64);

			CheckValidSymbols(candidate.FatherName, "Candidate's father name", "'-");
			CheckValidInterval(candidate.FatherName, "Candidate's father name", null, 64);
		}
		private static void CheckValidPhoneNumber(Candidate candidate)
		{
			if (!candidate.Phone.StartsWith("+380"))
				throw new ArgumentException("Candidate's phone number must start with '+380'.");
			if (candidate.Phone.Length != 13)
				throw new ArgumentException("Candidate's phone number must be 13 " +
					"characters long, including the country code.");
			if (!Validator.CheckAllNumbers(candidate.Phone.Substring(1)))
				throw new ArgumentException("Candidate's phone number must contain only " +
					"numeric characters after the '+' symbol.");
		}
		private static void CheckValidEmail(string email)
		{
			string pattern = @"^.+@.{2,}\..{2,}$";
			if (!Regex.IsMatch(email, pattern))
				throw new ArgumentException("Candidate's email address is invalid. " +
					"Please provide a valid email address in the format 'example@domain.com'.");
			CheckValidInterval(email, "Candidate's email", null, 64);
		}
		private static void CheckValidBirthday(DateTime birthday)
		{
			if (birthday >= DateTime.Now)
				throw new ArgumentException("Candidate's date of birth cannot be in the future.");
		}
		#endregion

		#region Questionnaire
		internal static void CheckValidQuestionnaire(Questionnaire questionnaire)
		{
			CheckValidNationalityAndCity(questionnaire.Nationality, questionnaire.City);
			CheckValidNumbers(questionnaire);
			DatabaseManager.GetFamilyStatus(questionnaire.FamilyStatusId);
			DatabaseManager.GetBusinessTripOpportunity(questionnaire.BusinessTripOpportunityId);

			if (questionnaire.Health != null)
				CheckValidSymbols(questionnaire.Health.ChronicDiseases, "Candidate's " +
					"chronic diseases", "'- 0123456789");
			foreach (var language in questionnaire.Languages)
				CheckValidLanguage(language);
			foreach (var education in questionnaire.Educations)
				CheckValidEducation(education);
		}
		private static void CheckValidNationalityAndCity(string nationality, string city)
		{
			CheckValidSymbols(nationality, "Candidate's nationality", "'- ");
			CheckValidInterval(nationality, "Candidate's nationality", 2, 64);

			CheckValidSymbols(city, "Candidate's city", "'- ");
			CheckValidInterval(city, "Candidate's city", 2, 64);
		}
		private static void CheckValidNumbers(Questionnaire questionnaire)
		{
			if (questionnaire.ChildrenAmount < 0)
				throw new ArgumentException("Candidate's number of children cannot be negative.");
			if (questionnaire.Experience < 0)
				throw new ArgumentException("Candidate's experience cannot be negative.");
			if (questionnaire.Readiness < 1 || questionnaire.Readiness > 14)
				throw new ArgumentException("Candidate's readiness level must be " +
					"between 1 and 14.");
		}
		private static void CheckValidLanguage(Language language)
		{
			CheckValidSymbols(language.Name, "Language name", "'- ");
			CheckValidInterval(language.Name, "Language name", 2, 64);

			if (language.Level < 1 || language.Level > 10)
				throw new ArgumentException("Language level must be between 1 and 10.");
		}
		private static void CheckValidEducation(Education education)
		{
			CheckValidSymbols(education.NameInstitution, "Institution name", "'.\"-№ 0123456789");
			CheckValidInterval(education.NameInstitution, "Institution name", 2, 128);

			CheckValidSymbols(education.Specialty, "Specialty", "'- ");
			CheckValidInterval(education.Specialty, "Specialty", 2, 64);

			CheckEducationDates(education);
			DatabaseManager.GetEducationDegree(education.EducationDegreeId);
			DatabaseManager.GetEducationForm(education.EducationFormId);
		}
		private static void CheckEducationDates(Education education)
		{
			if (education.YearAdmission < 1950)
				throw new ArgumentException("The admission year must be no earlier than 1950.");
			if (education.DateEnd.Year < 1951)
				throw new ArgumentException("The graduation year must be no earlier than 1951.");
			if (education.YearAdmission > education.DateEnd.Year)
				throw new ArgumentException("Year of admission cannot be greater than " +
					"the year of graduation.");
		}
		#endregion

		#region General methods
		private static void CheckValidSymbols(string value, string name, string allowedChars,
			ValidLanguage language = ValidLanguage.Ukrainian)
		{
			if (value == null)
				return;

			string languageName = string.Empty;
			if (language == ValidLanguage.Ukrainian)
				languageName = "Ukrainian";
			else if (language == ValidLanguage.English)
				languageName = "English";

			if (!string.IsNullOrWhiteSpace(languageName))
				languageName += " letters and ";

			if (!Validator.CheckSymbols(value, language, allowedChars))
				throw new ArgumentException($"{name} contains invalid characters. " +
					$"Only {languageName}symbols: ({allowedChars}) are allowed.");
		}
		private static void CheckValidInterval(string text, string name, int? minValue = null,
			int? maxValue = null)
		{
			if (text == null)
				return;

			int value = text.Length;

			if (minValue.HasValue && maxValue.HasValue)
			{
				if (value < minValue || value > maxValue)
					throw new ArgumentException($"{name} must be between {minValue.Value} and {maxValue.Value} characters long.");
			}
			else if (minValue.HasValue && !maxValue.HasValue)
			{
				if (value < minValue)
					throw new ArgumentException($"{name} must be at least {minValue.Value} characters long.");
			}
			else if (!minValue.HasValue && maxValue.HasValue)
			{
				if (value > maxValue)
					throw new ArgumentException($"{name} must be no more than {maxValue.Value} characters long.");
			}
		}
		#endregion
	}
}