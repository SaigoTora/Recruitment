using Base;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedModels.Models
{
	[Table("Education")]
	[Serializable]
	public partial class Education : EntityBase, ICloneable, IEquatable<Education>
	{
		[Column("name_institution")]
		[Required]
		[StringLength(128)]
		[JsonProperty]
		public string NameInstitution { get; private set; }
		[Column("specialty")]
		[Required]
		[StringLength(64)]
		[JsonProperty]
		public string Specialty { get; private set; }
		[Column("year_admission")]
		[JsonProperty]
		public int YearAdmission { get; private set; }
		[Column(name: "date_end", TypeName = "date")]
		[JsonProperty]
		public DateTime DateEnd { get; private set; }
		[Column("id_questionnaire")]
		[JsonProperty]
		public int QuestionnaireId { get; private set; }
		[Column("id_education_degree")]
		[JsonProperty]
		public int EducationDegreeId { get; private set; }
		[Column("id_education_form")]
		[JsonProperty]
		public int EducationFormId { get; private set; }
		[JsonProperty]
		public virtual EducationDegree EducationDegree { get; private set; }
		[JsonProperty]
		public virtual EducationForm EducationForm { get; private set; }
		[JsonIgnore]
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

		public void Change(string nameInstitution, string specialty, int yearAdmission,
			DateTime dateEnd, int educationDegreeId, int educationFormId)
		{
			NameInstitution = nameInstitution;
			Specialty = specialty;
			YearAdmission = yearAdmission;
			DateEnd = dateEnd;
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

		public bool Equals(Education other)
		{
			if (other == null)
				return false;

			if (NameInstitution != other.NameInstitution || Specialty != other.Specialty
				|| YearAdmission != other.YearAdmission || DateEnd != other.DateEnd
				|| EducationDegreeId != other.EducationDegreeId
				|| EducationFormId != other.EducationFormId)
				return false;

			return true;
		}
	}
}