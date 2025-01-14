namespace SharedModels.Models
{
	using SharedModels.Models.Base;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Questionnaire")]
	public partial class Questionnaire : EntityBase, ICloneable
	{
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
			= new HashSet<Language>();
		public virtual ICollection<Education> Educations { get; private set; }
			= new HashSet<Education>();
		public virtual ICollection<Candidate> Candidate { get; private set; }
			= new HashSet<Candidate>();

		public Questionnaire() { }
		public Questionnaire(string nationality, string city, int childrenAmount,
			int experience, bool driverLicense, int readiness, string additionalInfo,
			Health health, int idFamilyStatus, int idBusinessTripOpportunity,
			List<Language> languages, List<Education> educations)
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

		public object Clone()
		{
			Health health = (Health)Health?.Clone();
			var languages = new List<Language>();
			foreach (var language in Languages)
				languages.Add((Language)language?.Clone());
			var educations = new List<Education>();
			foreach (var education in Educations)
				educations.Add((Education)education?.Clone());

			var newQuestionnaire = new Questionnaire(Nationality, City, ChildrenAmount, Experience,
				DriverLicense, Readiness, AdditionalInfo, health, IdFamilyStatus,
				IdBusinessTripOpportunity, languages, educations)
			{
				Id = this.Id,
				IdHealth = this.IdHealth,
				FamilyStatus = this.FamilyStatus,
				BusinessTripOpportunity = this.BusinessTripOpportunity,
				Candidate = this.Candidate
			};

			return newQuestionnaire;
		}
	}
}