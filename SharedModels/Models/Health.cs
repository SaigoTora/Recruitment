namespace SharedModels.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Health")]
	public partial class Health : ICloneable
	{
		public int Id { get; private set; }
		[StringLength(256)]
		public string ChronicDiseases { get; private set; }
		public bool Smoker { get; private set; }
		public bool DrinkAlcohol { get; private set; }
		public virtual ICollection<Questionnaire> Questionnaire { get; private set; }

		public Health()
			=> Questionnaire = new HashSet<Questionnaire>();
		public Health(string chronicDiseases, bool smoker, bool drinkAlcohol)
			: this()
		{
			ChronicDiseases = chronicDiseases;
			Smoker = smoker;
			DrinkAlcohol = drinkAlcohol;
		}

		public object Clone()
		{
			Health newHealth = new Health(ChronicDiseases, Smoker, DrinkAlcohol)
			{
				Id = this.Id,
				Questionnaire = this.Questionnaire
			};

			return newHealth;
		}
	}
}