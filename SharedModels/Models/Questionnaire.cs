namespace SharedModels.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Questionnaire")]
	public partial class Questionnaire
	{
		public int Id { get; private set; }
		[Required]
		[StringLength(64)]
		public string Nationality { get; private set; }
		[Required]
		[StringLength(64)]
		public string City { get; private set; }
		public int ChildrenAmount { get; private set; }
		public int Experience { get; private set; }
		public bool DriverLicense { get; private set; }
		public int Readiness { get; private set; }
		public string AdditionalInfo { get; private set; }
		public int IdHealth { get; private set; }
		public int IdFamilyStatus { get; private set; }
		public int IdBusinessTripOpportunity { get; private set; }
		public virtual Health Health { get; private set; }
		public virtual FamilyStatus FamilyStatus { get; private set; }
		public virtual BusinessTripOpportunity BusinessTripOpportunity { get; private set; }
		public virtual ICollection<Language> Languages { get; private set; }
		public virtual ICollection<Education> Educations { get; private set; }
		public virtual ICollection<Candidate> Candidate { get; private set; }

		public Questionnaire()
		{
			Candidate = new HashSet<Candidate>();
			Educations = new HashSet<Education>();
			Languages = new HashSet<Language>();
		}
		public Questionnaire(string nationality, string city, int childrenAmount,
			int experience, bool driverLicense, int readiness, string additionalInfo,
			Health health, int idFamilyStatus, int idBusinessTripOpportunity,
			List<Language> languages, List<Education> educations)
			: this()
		{
			Nationality = nationality;
			City = city;
			ChildrenAmount = childrenAmount;
			Experience = experience;
			DriverLicense = driverLicense;
			Readiness = readiness;
			AdditionalInfo = additionalInfo;
			Health = health;
			IdFamilyStatus = idFamilyStatus;
			IdBusinessTripOpportunity = idBusinessTripOpportunity;
			Languages = languages;
			Educations = educations;
		}
		public Questionnaire(Questionnaire q)
		{
			Nationality = q.Nationality;
			City = q.City;
			ChildrenAmount = q.ChildrenAmount;
			Experience = q.Experience;
			DriverLicense = q.DriverLicense;
			Readiness = q.Readiness;
			AdditionalInfo = q.AdditionalInfo;
			Health = new Health(q.Health);
			IdFamilyStatus = q.IdFamilyStatus;
			IdBusinessTripOpportunity = q.IdBusinessTripOpportunity;

			Languages = new List<Language>();
			foreach (var language in q.Languages)
				Languages.Add(new Language(language));
			Educations = new List<Education>();
			foreach (var education in q.Educations)
				Educations.Add(new Education(education));
		}
	}
}