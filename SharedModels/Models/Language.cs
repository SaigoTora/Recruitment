namespace SharedModels.Models
{
	using Base;
	using Newtonsoft.Json;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Language")]
	[Serializable]
	public partial class Language : EntityBase, ICloneable
	{
		[Column("name")]
		[Required]
		[StringLength(64)]
		[JsonProperty]
		public string Name { get; private set; }
		[Column("level")]
		[JsonProperty]
		public int Level { get; private set; }
		[Column("id_questionnaire")]
		public int QuestionnaireId { get; private set; }
		[JsonIgnore]
		public virtual Questionnaire Questionnaire { get; private set; }

		public Language() { }
		public Language(string name, int level, int questionnaireId)
		{
			Name = name;
			Level = level;
			QuestionnaireId = questionnaireId;
		}
		public Language(int id, string name, int level, int questionnaireId)
			: this(name, level, questionnaireId)
		{
			Id = id;
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
		public void Change(string name, int level)
		{
			Name = name;
			Level = level;
		}
	}
}