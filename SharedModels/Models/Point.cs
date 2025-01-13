namespace SharedModels.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Point")]
	public partial class Point
	{
		public int Id { get; private set; }
		public int AgeUnder18 { get; private set; }
		public int Age18_30 { get; private set; }
		public int Age30_50 { get; private set; }
		public int AgeOver50 { get; private set; }
		public int ExpNone { get; private set; }
		public int ExpUnderYear { get; private set; }
		public int Exp1_3 { get; private set; }
		public int ExpOver3 { get; private set; }
		public int Diploma { get; private set; }
		public int NoChronicDiseases { get; private set; }
		public int DriverLicense { get; private set; }
		public int NoSmoker { get; private set; }
		public int NoDrinkAlcohol { get; private set; }
		public int BusinessTripOpportunity { get; private set; }

		public virtual ICollection<EducationDegreePoint> Degrees
		{ get; private set; }
		public virtual ICollection<Vacancy> Vacancy { get; private set; }

		public Point()
			=> Vacancy = new HashSet<Vacancy>();

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