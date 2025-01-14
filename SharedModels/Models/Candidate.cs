namespace SharedModels.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Candidate")]
	public partial class Candidate : ICloneable
	{
		public int Id { get; private set; }
		[Required]
		[StringLength(16)]
		public string Login { get; private set; }
		[Required]
		[StringLength(16)]
		public string Password { get; private set; }
		[Required]
		[StringLength(64)]
		public string Surname { get; private set; }
		[Required]
		[StringLength(64)]
		public string Name { get; private set; }
		[StringLength(64)]
		public string FatherName { get; private set; }
		[Required]
		[StringLength(13)]
		public string Phone { get; private set; }
		[Column(TypeName = "date")]
		public DateTime Birthday { get; private set; }
		[Required]
		[StringLength(64)]
		public string Email { get; private set; }
		public int IdQuestionnaire { get; private set; }
		public virtual Questionnaire Questionnaire { get; set; }
		public virtual ICollection<Application> Application { get; private set; }
			= new HashSet<Application>();

		public Candidate() { }
		public Candidate(string surname, string name, string fatherName, string phone,
			DateTime birthday, string email)
		{
			Surname = surname;
			Name = name;
			FatherName = fatherName;
			Phone = phone;
			Birthday = birthday;
			Email = email;
		}
		public Candidate(string surname, string name, string fatherName, string phone,
			DateTime birthday, string email, Questionnaire questionnaire)
			: this(surname, name, fatherName, phone, birthday, email)
			=> Questionnaire = questionnaire;

		public object Clone()
		{
			var newCandidate = new Candidate(Surname, Name, FatherName, Phone, Birthday, Email)
			{
				Id = this.Id,
				Login = this.Login,
				Password = this.Password,
				IdQuestionnaire = this.IdQuestionnaire,
				Questionnaire = (Questionnaire)this.Questionnaire.Clone(),
				Application = this.Application
			};

			return newCandidate;
		}
	}
}