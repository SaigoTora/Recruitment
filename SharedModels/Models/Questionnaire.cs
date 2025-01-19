namespace SharedModels.Models
{
	using Base;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Questionnaire")]
	public partial class Questionnaire : EntityBase, ICloneable
	{
		[Column("nationality")]
		[Required]
		[StringLength(64)]
		public string Nationality { get; private set; }
		[Column("city")]
		[Required]
		[StringLength(64)]
		public string City { get; private set; }
		[Column("children_amount")]
		public int ChildrenAmount { get; private set; }
		[Column("experience")]
		public int Experience { get; private set; }
		[Column("driver_license")]
		public bool DriverLicense { get; private set; }
		[Column("readiness")]
		public int Readiness { get; private set; }
		[Column("additional_info")]
		public string AdditionalInfo { get; private set; }
		[Column("id_health")]
		public int HealthId { get; private set; }
		[Column("id_family_status")]
		public int FamilyStatusId { get; private set; }
		[Column("id_business_trip_opportunity")]
		public int BusinessTripOpportunityId { get; private set; }
		public virtual Health Health { get; private set; }
		public virtual FamilyStatus FamilyStatus { get; private set; }
		public virtual BusinessTripOpportunity BusinessTripOpportunity { get; private set; }
		public virtual ICollection<Language> Languages { get; private set; }
			= new HashSet<Language>();
		public virtual ICollection<Education> Educations { get; private set; }
			= new HashSet<Education>();
		public virtual ICollection<Candidate> Candidates { get; private set; }
			= new HashSet<Candidate>();

		public Questionnaire() { }
		private Questionnaire(string nationality, string city, int childrenAmount,
			int experience, bool driverLicense, int readiness, string additionalInfo,
			int familyStatusId, int businessTripOpportunityId)
		{
			Nationality = nationality;
			City = city;
			ChildrenAmount = childrenAmount;
			Experience = experience;
			DriverLicense = driverLicense;
			Readiness = readiness;
			AdditionalInfo = additionalInfo;
			FamilyStatusId = familyStatusId;
			BusinessTripOpportunityId = businessTripOpportunityId;
		}
		public Questionnaire(string nationality, string city, int childrenAmount,
			int experience, bool driverLicense, int readiness, string additionalInfo,
			int healthId, int familyStatusId, int businessTripOpportunityId)
			: this(nationality, city, childrenAmount, experience, driverLicense,
				  readiness, additionalInfo, familyStatusId, businessTripOpportunityId)
		{
			HealthId = healthId;
		}
		public Questionnaire(string nationality, string city, int childrenAmount,
			int experience, bool driverLicense, int readiness, string additionalInfo,
			Health health, int familyStatusId, int businessTripOpportunityId,
			List<Language> languages, List<Education> educations)
			: this(nationality, city, childrenAmount, experience, driverLicense,
				  readiness, additionalInfo, familyStatusId, businessTripOpportunityId)
		{
			Health = health;
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
				DriverLicense, Readiness, AdditionalInfo, health, FamilyStatusId,
				BusinessTripOpportunityId, languages, educations)
			{
				Id = this.Id,
				HealthId = this.HealthId,
				FamilyStatus = this.FamilyStatus,
				BusinessTripOpportunity = this.BusinessTripOpportunity,
				Candidates = this.Candidates
			};

			return newQuestionnaire;
		}
	}
}