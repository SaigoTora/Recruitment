namespace SharedModels.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("View_Education")]
	public partial class EducationDbView
	{
		[Key]
		[Column(name: "id", Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; private set; }
		[Key]
		[Column(name: "name_institution", Order = 1)]
		public string NameInstitution { get; private set; }
		[Key]
		[Column(name: "specialty", Order = 2)]
		[StringLength(64)]
		public string Specialty { get; private set; }
		[Key]
		[Column(name: "year_admission", Order = 3)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int YearAdmission { get; private set; }
		[Key]
		[Column(name: "date_end", Order = 4, TypeName = "date")]
		public DateTime DateEnd { get; private set; }
		[Key]
		[Column(name: "degree", Order = 5)]
		[StringLength(32)]
		public string Degree { get; private set; }
		[Key]
		[Column(name: "form", Order = 6)]
		[StringLength(32)]
		public string Form { get; private set; }
		[Key]
		[Column(name: "id_questionnaire", Order = 7)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int IdQuestionnaire { get; private set; }
	}
}