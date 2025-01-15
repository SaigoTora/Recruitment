namespace SharedModels.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("View_Point")]
	public partial class PointDbView
	{
		[Key]
		[Column(name: "id", Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; private set; }
		[Key]
		[Column(name: "point_id", Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int PointId { get; private set; }
		[Key]
		[Column(name: "questionnaire_id", Order = 2)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int QuestionnaireId { get; private set; }
		[Key]
		[Column(name: "birthday", Order = 3, TypeName = "date")]
		public DateTime Birthday { get; private set; }
		[Key]
		[Column(name: "experience", Order = 4)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Experience { get; private set; }
		[Column("education_count")]
		public int? EducationCount { get; private set; }
		[Column("chronic_diseases")]
		[StringLength(256)]
		public string ChronicDiseases { get; private set; }
		[Key]
		[Column(name: "has_driver_license", Order = 5)]
		public bool HasDriverLicense { get; private set; }
		[Key]
		[Column(name: "smoker", Order = 6)]
		public bool Smoker { get; private set; }
		[Key]
		[Column(name: "drink_alcohol", Order = 7)]
		public bool DrinkAlcohol { get; private set; }
		[Key]
		[Column(name: "id_business_trip_opportunity", Order = 8)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int IdBusinessTripOpportunity { get; private set; }
		[Key]
		[Column(name: "age_under_18", Order = 9)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int AgeUnder18 { get; private set; }
		[Key]
		[Column(name: "age_18_30", Order = 10)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Age18_30 { get; private set; }
		[Key]
		[Column(name: "age_30_50", Order = 11)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Age30_50 { get; private set; }
		[Key]
		[Column(name: "age_over_50", Order = 12)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int AgeOver50 { get; private set; }
		[Key]
		[Column(name: "exp_none", Order = 13)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ExpNone { get; private set; }
		[Key]
		[Column(name: "exp_under_year", Order = 14)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ExpUnderYear { get; private set; }
		[Key]
		[Column(name: "exp_1_3", Order = 15)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Exp1_3 { get; private set; }
		[Key]
		[Column(name: "exp_over_3", Order = 16)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ExpOver3 { get; private set; }
		[Key]
		[Column(name: "diploma", Order = 17)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Diploma { get; private set; }
		[Key]
		[Column(name: "no_chronic_diseases", Order = 18)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int NoChronicDiseases { get; private set; }
		[Key]
		[Column(name: "driver_license", Order = 19)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int DriverLicense { get; private set; }
		[Key]
		[Column(name: "no_smoker", Order = 20)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int NoSmoker { get; private set; }
		[Key]
		[Column(name: "no_drink_alcohol", Order = 21)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int NoDrinkAlcohol { get; private set; }
		[Key]
		[Column(name: "business_trip_opportunity", Order = 22)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int BusinessTripOpportunity { get; private set; }
	}
}