using System.Collections.Generic;
using RecruitmentLibrary.ApplicationInfo;

namespace ServerDB.DataModels
{
    internal class FullRequirement : Requirement
    {// Клас з повною інформацією про вимоги
        internal List<int> IdDegrees { get; private set; }// Коди потрібних ступенів освіт

        // Конструктори
        internal FullRequirement() { }

        internal void Change(string city, byte ageMin, byte ageMax, int expMin,
            bool diploma, bool noChronicDiseases, bool driverLicense, bool noSmoker,
            bool noDrinkAlcohol, bool businessTripOpportunity, bool? student, List<int> idDegrees)
        {// Метод, який змінює дані
            City = city;
            AgeMin = ageMin;
            AgeMax = ageMax;
            ExpMin = expMin;
            Diploma = diploma;
            NoChronicDiseases = noChronicDiseases;
            DriverLicense = driverLicense;
            NoSmoker = noSmoker;
            NoDrinkAlcohol = noDrinkAlcohol;
            BusinessTripOpportunity = businessTripOpportunity;
            Student = student;
            IdDegrees = idDegrees;
        }
    }
}