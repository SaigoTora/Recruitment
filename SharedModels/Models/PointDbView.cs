namespace SharedModels.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("View_Point")]
	public partial class PointDbView
	{
		[Key]
		[Column(Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; private set; }
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int PointId { get; private set; }
		[Key]
		[Column(Order = 2)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int QuestionnaireId { get; private set; }
		[Key]
		[Column(Order = 3, TypeName = "date")]
		public DateTime Birthday { get; private set; }
		[Key]
		[Column(Order = 4)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Experience { get; private set; }
		public int? EducationCount { get; private set; }
		[StringLength(256)]
		public string ChronicDiseases { get; private set; }
		[Key]
		[Column(Order = 5)]
		public bool HasDriverLicense { get; private set; }
		[Key]
		[Column(Order = 6)]
		public bool Smoker { get; private set; }
		[Key]
		[Column(Order = 7)]
		public bool DrinkAlcohol { get; private set; }
		[Key]
		[Column(Order = 8)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int IdBusinessTripOpportunity { get; private set; }
		[Key]
		[Column(Order = 9)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int AgeUnder18 { get; private set; }
		[Key]
		[Column(Order = 10)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Age18_30 { get; private set; }
		[Key]
		[Column(Order = 11)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Age30_50 { get; private set; }
		[Key]
		[Column(Order = 12)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int AgeOver50 { get; private set; }
		[Key]
		[Column(Order = 13)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ExpNone { get; private set; }
		[Key]
		[Column(Order = 14)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ExpUnderYear { get; private set; }
		[Key]
		[Column(Order = 15)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Exp1_3 { get; private set; }
		[Key]
		[Column(Order = 16)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ExpOver3 { get; private set; }
		[Key]
		[Column(Order = 17)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Diploma { get; private set; }
		[Key]
		[Column(Order = 18)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int NoChronicDiseases { get; private set; }
		[Key]
		[Column(Order = 19)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int DriverLicense { get; private set; }
		[Key]
		[Column(Order = 20)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int NoSmoker { get; private set; }
		[Key]
		[Column(Order = 21)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int NoDrinkAlcohol { get; private set; }
		[Key]
		[Column(Order = 22)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int BusinessTripOpportunity { get; private set; }
	}
}