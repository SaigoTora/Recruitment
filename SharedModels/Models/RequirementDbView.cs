namespace SharedModels.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("View_Requirement")]
	public partial class RequirementDbView
	{
		[Key]
		[Column(Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; private set; }
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int RequirementId { get; private set; }
		[Key]
		[Column(Order = 2)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int QuestionnaireId { get; private set; }
		[Key]
		[Column(Order = 3)]
		[StringLength(64)]
		public string CityCandidate { get; private set; }
		[Key]
		[Column(Order = 4, TypeName = "date")]
		public DateTime Birthday { get; private set; }
		[Key]
		[Column(Order = 5)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Experience { get; private set; }
		public int? EducationCount { get; private set; }
		[StringLength(256)]
		public string ChronicDiseases { get; private set; }
		[Key]
		[Column(Order = 6)]
		public bool HasDriverLicense { get; private set; }
		[Key]
		[Column(Order = 7)]
		public bool Smoker { get; private set; }
		[Key]
		[Column(Order = 8)]
		public bool DrinkAlcohol { get; private set; }
		[Key]
		[Column(Order = 9)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int IdBusinessTripOpportunity { get; private set; }
		[StringLength(64)]
		public string City { get; private set; }
		[Key]
		[Column(Order = 10)]
		public byte AgeMin { get; private set; }
		[Key]
		[Column(Order = 11)]
		public byte AgeMax { get; private set; }
		[Key]
		[Column(Order = 12)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ExpMin { get; private set; }
		[Key]
		[Column(Order = 13)]
		public bool Diploma { get; private set; }
		[Key]
		[Column(Order = 14)]
		public bool NoChronicDiseases { get; private set; }
		[Key]
		[Column(Order = 15)]
		public bool DriverLicense { get; private set; }
		[Key]
		[Column(Order = 16)]
		public bool NoSmoker { get; private set; }
		[Key]
		[Column(Order = 17)]
		public bool NoDrinkAlcohol { get; private set; }
		[Key]
		[Column(Order = 18)]
		public bool BusinessTripOpportunity { get; private set; }
		public bool? Student { get; private set; }
	}
}