using Base;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedModels.Models
{
	[Table("Language")]
	[Serializable]
	public partial class Language : EntityBase, ICloneable, IEquatable<Language>
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
		[JsonProperty]
		public int QuestionnaireId { get; private set; }
		[JsonIgnore]
		public virtual Questionnaire Questionnaire { get; private set; }

		private Language() { }
		public Language(string name, int level, int questionnaireId)
		{
			Name = name;
			Level = level;
			QuestionnaireId = questionnaireId;
		}

		public void Change(string name, int level)
		{
			Name = name;
			Level = level;
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

		public bool Equals(Language other)
		{
			if (other == null)
				return false;

			if (Name != other.Name || Level != other.Level)
				return false;

			return true;
		}
	}
}