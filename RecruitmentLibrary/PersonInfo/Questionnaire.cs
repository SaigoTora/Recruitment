using System.Collections.Generic;

namespace RecruitmentLibrary.PersonInfo
{
    public class Questionnaire
    {// Анкета
        public string Nationality { get; private set; }// Громадянство
        public string City { get; private set; }// Місто/село проживання
        public int ChildrenAmount { get; private set; }// Кількість дітей
        public int Experience { get; private set; }// Досвід роботи(в місяцях)
        public bool DriverLicense { get; private set; }// Є посвідчення водія
        public int Readiness { get; private set; }// Готовність до роботи від 1 до 14 днів
        public string AdditionalInfo { get; private set; }// Додаткова інформація
        public Health CandidateHealth { get; private set; }// Код здоров'я
        public int ID_FamilyStatus { get; private set; }// Код сімейного стану
        public int ID_BusinessTripOpportunity { get; private set; }// Код можливості відряджень
        public List<Language> Languages { get; private set; }// Мови
        public List<Education> Educations { get; private set; }// Освіти

        // Конструктори
        public Questionnaire()
        { }
        public Questionnaire(string nationality, string city, int childrenAmount,
            int experience, bool driverLicense, int readiness, string additionalInfo,
            Health candidateHealth, int id_FamilyStatus, int id_BusinessTripOpportunity,
            List<Language> languages, List<Education> educations)
        {
            Nationality = nationality;
            City = city;
            ChildrenAmount = childrenAmount;
            Experience = experience;
            DriverLicense = driverLicense;
            Readiness = readiness;
            AdditionalInfo = additionalInfo;
            CandidateHealth = candidateHealth;
            ID_FamilyStatus = id_FamilyStatus;
            ID_BusinessTripOpportunity = id_BusinessTripOpportunity;
            Languages = languages;
            Educations = educations;
        }
        public Questionnaire(Questionnaire q)
        {// Створюємо копію анкети
            Nationality = q.Nationality;
            City = q.City;
            ChildrenAmount = q.ChildrenAmount;
            Experience = q.Experience;
            DriverLicense = q.DriverLicense;
            Readiness = q.Readiness;
            AdditionalInfo = q.AdditionalInfo;
            CandidateHealth = new Health(q.CandidateHealth);
            ID_FamilyStatus = q.ID_FamilyStatus;
            ID_BusinessTripOpportunity = q.ID_BusinessTripOpportunity;
            Languages = new List<Language>();
            foreach (var language in q.Languages)
                Languages.Add(new Language(language));
            Educations = new List<Education>();
            foreach (var education in q.Educations)
                Educations.Add(new Education(education));
        }
    }
}