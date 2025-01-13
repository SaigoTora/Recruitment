namespace SharedModels.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("View_Questionnaire")]
	public partial class QuestionnaireDbView
	{
		[Key]
		[Column(Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; private set; }
		[Key]
		[Column(Order = 1)]
		[StringLength(64)]
		public string Nationality { get; private set; }
		[Key]
		[Column(Order = 2)]
		[StringLength(64)]
		public string City { get; private set; }
		[Key]
		[Column(Order = 3)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ChildrenAmount { get; private set; }
		[Key]
		[Column(Order = 4)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Experience { get; private set; }
		[Key]
		[Column(Order = 5)]
		public bool DriverLicense { get; private set; }
		[Key]
		[Column(Order = 6)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Readiness { get; private set; }
		public string AdditionalInfo { get; private set; }
		[StringLength(256)]
		public string ChronicDiseases { get; private set; }
		[Key]
		[Column(Order = 7)]
		public bool Smoker { get; private set; }
		[Key]
		[Column(Order = 8)]
		public bool DrinkAlcohol { get; private set; }
		[Key]
		[Column(Order = 9)]
		[StringLength(32)]
		public string Status { get; private set; }
		[Key]
		[Column(Order = 10)]
		[StringLength(32)]
		public string Opportunity { get; private set; }
		public int? EducationCount { get; private set; }
		public int? LanguageCount { get; private set; }
	}
}