namespace SharedModels.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Candidate")]
	public partial class Candidate
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

		public Candidate()
			=> Application = new HashSet<Application>();
		public Candidate(string surname, string name, string fatherName, string phone,
			DateTime birthday, string email)
			: this()
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
		public Candidate(Candidate candidate) : this(candidate.Surname, candidate.Name,
			candidate.FatherName, candidate.Phone, candidate.Birthday, candidate.Email)
			=> Questionnaire = new Questionnaire(candidate.Questionnaire);
	}
}