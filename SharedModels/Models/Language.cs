namespace SharedModels.Models
{
	using SharedModels.Models.Base;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Language")]
	public partial class Language : EntityBase, ICloneable
	{
		[Required]
		[StringLength(64)]
		public string Name { get; private set; }
		public int Level { get; private set; }
		public int IdQuestionnaire { get; private set; }
		public virtual Questionnaire Questionnaire { get; private set; }

		public Language(string name, int level)
		{
			Name = name;
			Level = level;
		}

		public object Clone()
		{
			Language newLanguage = new Language(Name, Level)
			{
				Id = this.Id,
				IdQuestionnaire = this.IdQuestionnaire,
				Questionnaire = this.Questionnaire
			};

			return newLanguage;
		}
	}
}