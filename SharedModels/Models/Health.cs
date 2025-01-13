namespace SharedModels.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Health")]
	public partial class Health
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
		public Health(Health health)
			: this()
		{
			ChronicDiseases = health.ChronicDiseases;
			Smoker = health.Smoker;
			DrinkAlcohol = health.DrinkAlcohol;
		}
	}
}