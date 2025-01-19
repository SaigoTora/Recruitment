namespace SharedModels.Models
{
	using SharedModels.Models.Base;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Education")]
	public partial class Education : EntityBase, ICloneable
	{
		[Column("name_institution")]
		[Required]
		[StringLength(128)]
		public string NameInstitution { get; private set; }
		[Column("specialty")]
		[Required]
		[StringLength(64)]
		public string Specialty { get; private set; }
		[Column("year_admission")]
		public int YearAdmission { get; private set; }
		[Column(name: "date_end", TypeName = "date")]
		public DateTime DateEnd { get; private set; }
		[Column("id_questionnaire")]
		public int QuestionnaireId { get; private set; }
		[Column("id_education_degree")]
		public int EducationDegreeId { get; private set; }
		[Column("id_education_form")]
		public int EducationFormId { get; private set; }
		public virtual EducationDegree EducationDegree { get; private set; }
		public virtual EducationForm EducationForm { get; private set; }
		public virtual Questionnaire Questionnaire { get; private set; }

		public Education() { }
		public Education(string nameInstitution, string specialty, int yearAdmission,
			DateTime dateEnd, int questionnaireId, int educationDegreeId, int educationFormId)
		{
			NameInstitution = nameInstitution;
			Specialty = specialty;
			YearAdmission = yearAdmission;
			DateEnd = dateEnd;
			QuestionnaireId = questionnaireId;
			EducationDegreeId = educationDegreeId;
			EducationFormId = educationFormId;
		}

		public object Clone()
		{
			var newEducation = new Education(NameInstitution, Specialty, YearAdmission, DateEnd,
				QuestionnaireId, EducationDegreeId, EducationFormId)
			{
				Id = this.Id,
				EducationDegree = this.EducationDegree,
				EducationForm = this.EducationForm,
				Questionnaire = this.Questionnaire
			};

			return newEducation;
		}
	}
}