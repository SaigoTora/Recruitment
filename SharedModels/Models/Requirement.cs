using Newtonsoft.Json;
using SharedModels.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedModels.Models
{
	[Table("Requirement")]
	[Serializable]
	public partial class Requirement : EntityBase
	{
		[Column("city")]
		[StringLength(64)]
		[JsonProperty]
		public string City { get; private set; }
		[Column("age_min")]
		[JsonProperty]
		public byte AgeMin { get; private set; }
		[Column("age_max")]
		[JsonProperty]
		public byte AgeMax { get; private set; }
		[Column("exp_min")]
		[JsonProperty]
		public int ExpMin { get; private set; }
		[Column("diploma")]
		[JsonProperty]
		public bool Diploma { get; private set; }
		[Column("no_chronic_diseases")]
		[JsonProperty]
		public bool NoChronicDiseases { get; private set; }
		[Column("driver_license")]
		[JsonProperty]
		public bool DriverLicense { get; private set; }
		[Column("no_smoker")]
		[JsonProperty]
		public bool NoSmoker { get; private set; }
		[Column("no_drink_alcohol")]
		[JsonProperty]
		public bool NoDrinkAlcohol { get; private set; }
		[Column("business_trip_opportunity")]
		[JsonProperty]
		public bool BusinessTripOpportunity { get; private set; }
		[Column("student")]
		[JsonProperty]
		public bool? Student { get; private set; }
		[JsonProperty]
		public virtual ICollection<EducationDegreeRequirement> EducationDegreeRequirements
		{ get; private set; } = new HashSet<EducationDegreeRequirement>();
		[JsonIgnore]
		public virtual ICollection<Vacancy> Vacancies { get; private set; }
			= new HashSet<Vacancy>();

		public Requirement() { }
		public Requirement(string city, byte ageMin, byte ageMax, int expMin,
			bool diploma, bool noChronicDiseases, bool driverLicense, bool noSmoker,
			bool noDrinkAlcohol, bool businessTripOpportunity, bool? student)
		{
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
		}

		public void Change(string city, byte ageMin, byte ageMax, int expMin,
			bool diploma, bool noChronicDiseases, bool driverLicense, bool noSmoker,
			bool noDrinkAlcohol, bool businessTripOpportunity, bool? student,
			ICollection<EducationDegreeRequirement> educationDegreeRequirements)
		{
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
			EducationDegreeRequirements = educationDegreeRequirements;
		}

		public void ChangeCity(string city) => City = city;

		public override string ToString()
		{
			string res = string.Empty;
			int number = 1;

			if (!string.IsNullOrWhiteSpace(City))
				res += $"{number++}. Місце проживання: {City}.\n";
			if (AgeMin == AgeMax)
				res += $"{number++}. Вік: {AgeMin} р.\n";
			else
				res += $"{number++}. Вік: від {AgeMin} до {AgeMax}.\n";
			if (ExpMin != 0)
				res += $"{number++}. Мінімальний досвід роботи: {ExpMin} міс.\n";
			if (Diploma)
				res += $"{number++}. Наявність диплому.\n";
			if (NoChronicDiseases)
				res += $"{number++}. Відсутність хронічних захворювань.\n";
			if (DriverLicense)
				res += $"{number++}. Наявність посвідчення водія.\n";
			if (NoSmoker)
				res += $"{number++}. Кандидат НЕ повинен бути курцем.\n";
			if (NoDrinkAlcohol)
				res += $"{number++}. Кандидат НЕ повинен вживати алкогольні напої.\n";
			if (BusinessTripOpportunity)
				res += $"{number++}. Можливість відряджень.\n";

			if (Student != null && Student.Value)
				res += $"{number++}. Кандидат повинен бути студентом.\n";
			if (Student != null && !Student.Value)
				res += $"{number++}. Кандидат НЕ повинен студентом.\n";

			if (number == 2)
				res = res.Remove(0, 3);
			return res.TrimEnd('\n');
		}
	}
}