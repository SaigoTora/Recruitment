namespace SharedModels.Models
{
	using SharedModels.Models.Base;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Candidate")]
	public partial class Candidate : EntityBase, ICloneable
	{
		[Column("login")]
		[Required]
		[StringLength(16)]
		public string Login { get; private set; }
		[Column("password")]
		[Required]
		[StringLength(16)]
		public string Password { get; private set; }
		[Column("surname")]
		[Required]
		[StringLength(64)]
		public string Surname { get; private set; }
		[Column("name")]
		[Required]
		[StringLength(64)]
		public string Name { get; private set; }
		[Column("father_name")]
		[StringLength(64)]
		public string FatherName { get; private set; }
		[Column("phone")]
		[Required]
		[StringLength(13)]
		public string Phone { get; private set; }
		[Column(name: "birthday", TypeName = "date")]
		public DateTime Birthday { get; private set; }
		[Column("email")]
		[Required]
		[StringLength(64)]
		public string Email { get; private set; }
		[Column("id_questionnaire")]
		public int QuestionnaireId { get; private set; }
		public virtual Questionnaire Questionnaire { get; set; }
		public virtual ICollection<Application> Applications { get; private set; }
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
		public Candidate(string surname, string name, string fatherName, string login,
			string password, string phone, DateTime birthday, string email, int questionnaireId)
			: this(surname, name, fatherName, phone, birthday, email)
		{
			Login = login;
			Password = password;
			QuestionnaireId = questionnaireId;
		}
		public Candidate(string surname, string name, string fatherName, string phone,
			DateTime birthday, string email, Questionnaire questionnaire)
			: this(surname, name, fatherName, phone, birthday, email)
			=> Questionnaire = questionnaire;

		public object Clone()
		{
			var newCandidate = new Candidate(Surname, Name, FatherName, Login, Password, Phone,
				Birthday, Email, QuestionnaireId)
			{
				Id = this.Id,
				Questionnaire = (Questionnaire)this.Questionnaire.Clone(),
				Applications = this.Applications
			};

			return newCandidate;
		}
	}
}