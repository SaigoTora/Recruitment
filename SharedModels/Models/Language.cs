namespace SharedModels.Models
{
	using SharedModels.Models.Base;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Language")]
	public partial class Language : EntityBase, ICloneable
	{
		[Column("name")]
		[Required]
		[StringLength(64)]
		public string Name { get; private set; }
		[Column("level")]
		public int Level { get; private set; }
		[Column("id_questionnaire")]
		public int QuestionnaireId { get; private set; }
		public virtual Questionnaire Questionnaire { get; private set; }

		public Language() { }
		public Language(string name, int level, int questionnaireId)
		{
			Name = name;
			Level = level;
			QuestionnaireId = questionnaireId;
		}

		public object Clone()
		{
			Language newLanguage = new Language(Name, Level, QuestionnaireId)
			{
				Id = this.Id,
				Questionnaire = this.Questionnaire
			};

			return newLanguage;
		}
	}
}