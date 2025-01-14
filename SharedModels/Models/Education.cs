namespace SharedModels.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Education")]
	public partial class Education : ICloneable
	{
		public int Id { get; private set; }
		[Required]
		[StringLength(128)]
		public string NameInstitution { get; private set; }
		[Required]
		[StringLength(64)]
		public string Specialty { get; private set; }
		public int YearAdmission { get; private set; }
		[Column(TypeName = "date")]
		public DateTime DateEnd { get; private set; }
		public int IdQuestionnaire { get; private set; }
		public int IdEducationDegree { get; private set; }
		public int IdEducationForm { get; private set; }
		public virtual EducationDegree EducationDegree { get; private set; }
		public virtual EducationForm EducationForm { get; private set; }
		public virtual Questionnaire Questionnaire { get; private set; }

		public Education(string nameInstitution, string specialty, int yearAdmission,
			DateTime dateEnd, int idEducationDegree, int idEducationForm)
		{
			NameInstitution = nameInstitution;
			Specialty = specialty;
			YearAdmission = yearAdmission;
			DateEnd = dateEnd;
			IdEducationDegree = idEducationDegree;
			IdEducationForm = idEducationForm;
		}

		public object Clone()
		{
			var newEducation = new Education(NameInstitution, Specialty, YearAdmission, DateEnd,
				IdEducationDegree, IdEducationForm)
			{
				Id = this.Id,
				IdQuestionnaire = this.IdQuestionnaire,
				EducationDegree = this.EducationDegree,
				EducationForm = this.EducationForm,
				Questionnaire = this.Questionnaire
			};

			return newEducation;
		}
	}
}