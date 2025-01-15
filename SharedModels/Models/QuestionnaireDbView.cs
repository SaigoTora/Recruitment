namespace SharedModels.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("View_Questionnaire")]
	public partial class QuestionnaireDbView
	{
		[Key]
		[Column(name: "id", Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; private set; }
		[Key]
		[Column(name: "nationality", Order = 1)]
		[StringLength(64)]
		public string Nationality { get; private set; }
		[Key]
		[Column(name: "city", Order = 2)]
		[StringLength(64)]
		public string City { get; private set; }
		[Key]
		[Column(name: "children_amount", Order = 3)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ChildrenAmount { get; private set; }
		[Key]
		[Column(name: "experience", Order = 4)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Experience { get; private set; }
		[Key]
		[Column(name: "driver_license", Order = 5)]
		public bool DriverLicense { get; private set; }
		[Key]
		[Column(name: "readiness", Order = 6)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Readiness { get; private set; }
		[Column("additional_info")]
		public string AdditionalInfo { get; private set; }
		[Column("chronic_diseases")]
		[StringLength(256)]
		public string ChronicDiseases { get; private set; }
		[Key]
		[Column(name: "smoker", Order = 7)]
		public bool Smoker { get; private set; }
		[Key]
		[Column(name: "drink_alcohol", Order = 8)]
		public bool DrinkAlcohol { get; private set; }
		[Key]
		[Column(name: "status", Order = 9)]
		[StringLength(32)]
		public string Status { get; private set; }
		[Key]
		[Column(name: "opportunity", Order = 10)]
		[StringLength(32)]
		public string Opportunity { get; private set; }
		[Column("education_count")]
		public int? EducationCount { get; private set; }
		[Column("language_count")]
		public int? LanguageCount { get; private set; }
	}
}