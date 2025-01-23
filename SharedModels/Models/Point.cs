using Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedModels.Models
{
	[Table("Point")]
	[Serializable]
	public partial class Point : EntityBase
	{
		[Column("age_under_18")]
		[JsonProperty]
		public int AgeUnder18 { get; private set; }
		[Column("age_18_30")]
		[JsonProperty]
		public int Age18_30 { get; private set; }
		[Column("age_30_50")]
		[JsonProperty]
		public int Age30_50 { get; private set; }
		[Column("age_over_50")]
		[JsonProperty]
		public int AgeOver50 { get; private set; }
		[Column("exp_none")]
		[JsonProperty]
		public int ExpNone { get; private set; }
		[Column("exp_under_year")]
		[JsonProperty]
		public int ExpUnderYear { get; private set; }
		[Column("exp_1_3")]
		[JsonProperty]
		public int Exp1_3 { get; private set; }
		[Column("exp_over_3")]
		[JsonProperty]
		public int ExpOver3 { get; private set; }
		[Column("diploma")]
		[JsonProperty]
		public int Diploma { get; private set; }
		[Column("no_chronic_diseases")]
		[JsonProperty]
		public int NoChronicDiseases { get; private set; }
		[Column("driver_license")]
		[JsonProperty]
		public int DriverLicense { get; private set; }
		[Column("no_smoker")]
		[JsonProperty]
		public int NoSmoker { get; private set; }
		[Column("no_drink_alcohol")]
		[JsonProperty]
		public int NoDrinkAlcohol { get; private set; }
		[Column("business_trip_opportunity")]
		[JsonProperty]
		public int BusinessTripOpportunity { get; private set; }
		[JsonProperty]
		public virtual ICollection<EducationDegreePoint> Degrees
		{ get; private set; }
		[JsonIgnore]
		public virtual ICollection<Vacancy> Vacancies { get; private set; }
			= new HashSet<Vacancy>();

		public Point() { }
		public Point(int ageUnder18, int age18_30, int age30_50, int ageOver50, int expNone,
			int expUnderYear, int exp1_3, int expOver3, int diploma, int noChronicDiseases,
			int driverLicense, int noSmoker, int noDrinkAlcohol, int businessTripOpportunity)
		{
			AgeUnder18 = ageUnder18;
			Age18_30 = age18_30;
			Age30_50 = age30_50;
			AgeOver50 = ageOver50;
			ExpNone = expNone;
			ExpUnderYear = expUnderYear;
			Exp1_3 = exp1_3;
			ExpOver3 = expOver3;
			Diploma = diploma;
			NoChronicDiseases = noChronicDiseases;
			DriverLicense = driverLicense;
			NoSmoker = noSmoker;
			NoDrinkAlcohol = noDrinkAlcohol;
			BusinessTripOpportunity = businessTripOpportunity;
		}

		public void Change(int ageUnder18, int age18_30, int age30_50, int ageOver50,
			int expNone, int expUnderYear, int exp1_3, int expOver3, int diploma,
			int noChronicDiseases, int driverLicense, int noSmoker, int noDrinkAlcohol,
			int businessTripOpportunity, ICollection<EducationDegreePoint> degrees)
		{
			AgeUnder18 = ageUnder18;
			Age18_30 = age18_30;
			Age30_50 = age30_50;
			AgeOver50 = ageOver50;
			ExpNone = expNone;
			ExpUnderYear = expUnderYear;
			Exp1_3 = exp1_3;
			ExpOver3 = expOver3;
			Diploma = diploma;
			NoChronicDiseases = noChronicDiseases;
			DriverLicense = driverLicense;
			NoSmoker = noSmoker;
			NoDrinkAlcohol = noDrinkAlcohol;
			BusinessTripOpportunity = businessTripOpportunity;

			Degrees = new HashSet<EducationDegreePoint>();
			foreach (var degree in degrees)
				Degrees.Add(degree);
		}
	}
}