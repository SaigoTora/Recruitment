using Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedModels.Models
{
	[Table("Candidate")]
	[Serializable]
	public partial class Candidate : EntityBase, ICloneable, IEquatable<Candidate>
	{
		[Column("login")]
		[Required]
		[StringLength(16)]
		[JsonProperty]
		public string Login { get; private set; }
		[Column("password")]
		[Required]
		[StringLength(16)]
		[JsonProperty]
		public string Password { get; private set; }
		[Column("surname")]
		[Required]
		[StringLength(64)]
		[JsonProperty]
		public string Surname { get; private set; }
		[Column("name")]
		[Required]
		[StringLength(64)]
		[JsonProperty]
		public string Name { get; private set; }
		[Column("father_name")]
		[StringLength(64)]
		[JsonProperty]
		public string FatherName { get; private set; }
		[Column("phone")]
		[Required]
		[StringLength(13)]
		[JsonProperty]
		public string Phone { get; private set; }
		[Column(name: "birthday", TypeName = "date")]
		[JsonProperty]
		public DateTime Birthday { get; private set; }
		[Column("email")]
		[Required]
		[StringLength(64)]
		[JsonProperty]
		public string Email { get; private set; }
		[Column("id_questionnaire")]
		[JsonProperty]
		public int QuestionnaireId { get; private set; }
		[JsonProperty]
		public virtual Questionnaire Questionnaire { get; set; }
		[JsonIgnore]
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
		public Candidate(int id, string surname, string name, string fatherName, string login,
			string password, string phone, DateTime birthday, string email,
			Questionnaire questionnaire)
			: this(surname, name, fatherName, phone, birthday, email)
		{
			Id = id;
			Login = login;
			Password = password;
			Questionnaire = questionnaire;
		}

		public void ChangeLoginPassword(string login, string password)
		{
			Login = login;
			Password = password;
		}
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

		public bool Equals(Candidate other)
		{
			if (other == null)
				return false;

			if (Login != other.Login || Password != other.Password || Surname != other.Surname
				|| Name != other.Name || FatherName != other.FatherName || Phone != other.Phone
				|| Birthday != other.Birthday || Email != other.Email
				|| (Questionnaire != null && !Questionnaire.Equals(other.Questionnaire)))
				return false;

			return true;
		}
	}
}