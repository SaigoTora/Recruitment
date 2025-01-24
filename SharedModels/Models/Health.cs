using Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedModels.Models
{
	[Table("Health")]
	[Serializable]
	public partial class Health : EntityBase, ICloneable, IEquatable<Health>
	{
		[Column("chronic_diseases")]
		[StringLength(256)]
		[JsonProperty]
		public string ChronicDiseases { get; private set; }
		[Column("smoker")]
		[JsonProperty]
		public bool Smoker { get; private set; }
		[Column("drink_alcohol")]
		[JsonProperty]
		public bool DrinkAlcohol { get; private set; }
		[JsonIgnore]
		public virtual ICollection<Questionnaire> Questionnaires { get; private set; }
			= new HashSet<Questionnaire>();

		private Health() { }
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
				Questionnaires = this.Questionnaires
			};

			return newHealth;
		}

		public bool Equals(Health other)
		{
			if (other == null)
				return false;

			if (ChronicDiseases != other.ChronicDiseases || Smoker != other.Smoker
				|| DrinkAlcohol != other.DrinkAlcohol)
				return false;

			return true;
		}
	}
}