namespace SharedModels.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("View_Education")]
	public partial class EducationDbView
	{
		[Key]
		[Column(Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; private set; }
		[Key]
		[Column(Order = 1)]
		public string NameInstitution { get; private set; }
		[Key]
		[Column(Order = 2)]
		[StringLength(64)]
		public string Specialty { get; private set; }
		[Key]
		[Column(Order = 3)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int YearAdmission { get; private set; }
		[Key]
		[Column(Order = 4, TypeName = "date")]
		public DateTime DateEnd { get; private set; }
		[Key]
		[Column(Order = 5)]
		[StringLength(32)]
		public string Degree { get; private set; }
		[Key]
		[Column(Order = 6)]
		[StringLength(32)]
		public string Form { get; private set; }
		[Key]
		[Column(Order = 7)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int IdQuestionnaire { get; private set; }
	}
}