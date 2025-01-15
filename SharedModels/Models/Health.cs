namespace SharedModels.Models
{
	using SharedModels.Models.Base;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Health")]
	public partial class Health : EntityBase, ICloneable
	{
		[Column("chronic_diseases")]
		[StringLength(256)]
		public string ChronicDiseases { get; private set; }
		[Column("smoker")]
		public bool Smoker { get; private set; }
		[Column("drink_alcohol")]
		public bool DrinkAlcohol { get; private set; }
		public virtual ICollection<Questionnaire> Questionnaire { get; private set; }
			= new HashSet<Questionnaire>();

		public Health() { }
		public Health(string chronicDiseases, bool smoker, bool drinkAlcohol)
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