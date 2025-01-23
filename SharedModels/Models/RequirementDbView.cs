using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedModels.Models
{
	[Table("View_Requirement")]
	public partial class RequirementDbView
	{
		[Key]
		[Column(name: "id", Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; private set; }
		[Key]
		[Column(name: "requirement_id", Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int RequirementId { get; private set; }
		[Key]
		[Column(name: "questionnaire_id", Order = 2)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int QuestionnaireId { get; private set; }
		[Key]
		[Column(name: "city_candidate", Order = 3)]
		[StringLength(64)]
		public string CityCandidate { get; private set; }
		[Key]
		[Column(name: "birthday", Order = 4, TypeName = "date")]
		public DateTime Birthday { get; private set; }
		[Key]
		[Column(name: "experience", Order = 5)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Experience { get; private set; }
		[Column("education_count")]
		public int? EducationCount { get; private set; }
		[Column("chronic_diseases")]
		[StringLength(256)]
		public string ChronicDiseases { get; private set; }
		[Key]
		[Column(name: "has_driver_license", Order = 6)]
		public bool HasDriverLicense { get; private set; }
		[Key]
		[Column(name: "smoker", Order = 7)]
		public bool Smoker { get; private set; }
		[Key]
		[Column(name: "drink_alcohol", Order = 8)]
		public bool DrinkAlcohol { get; private set; }
		[Key]
		[Column(name: "id_business_trip_opportunity", Order = 9)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int BusinessTripOpportunityId { get; private set; }
		[Column("city")]
		[StringLength(64)]
		public string City { get; private set; }
		[Key]
		[Column(name: "age_min", Order = 10)]
		public byte AgeMin { get; private set; }
		[Key]
		[Column(name: "age_max", Order = 11)]
		public byte AgeMax { get; private set; }
		[Key]
		[Column(name: "exp_min", Order = 12)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ExpMin { get; private set; }
		[Key]
		[Column(name: "diploma", Order = 13)]
		public bool Diploma { get; private set; }
		[Key]
		[Column(name: "no_chronic_diseases", Order = 14)]
		public bool NoChronicDiseases { get; private set; }
		[Key]
		[Column(name: "driver_license", Order = 15)]
		public bool DriverLicense { get; private set; }
		[Key]
		[Column(name: "no_smoker", Order = 16)]
		public bool NoSmoker { get; private set; }
		[Key]
		[Column(name: "no_drink_alcohol", Order = 17)]
		public bool NoDrinkAlcohol { get; private set; }
		[Key]
		[Column(name: "business_trip_opportunity", Order = 18)]
		public bool BusinessTripOpportunity { get; private set; }
		[Column("student")]
		public bool? Student { get; private set; }
	}
}