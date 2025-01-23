using Base;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedModels.Models
{
	[Table("Employee")]
	[Serializable]
	public partial class Employee : EntityBase
	{
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
		[Column("position_name")]
		[Required]
		[StringLength(64)]
		[JsonProperty]
		public string PositionName { get; private set; }
		[Column("city")]
		[Required]
		[StringLength(64)]
		[JsonProperty]
		public string City { get; private set; }
		[Column("phone")]
		[Required]
		[StringLength(16)]
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
		[Column(name: "salary", TypeName = "money")]
		[JsonProperty]
		public decimal Salary { get; private set; }
		[Column(name: "date_employment", TypeName = "date")]
		[JsonProperty]
		public DateTime DateEmployment { get; private set; }
		[Column("id_interview")]
		[JsonProperty]
		public int? InterviewId { get; private set; }
		[JsonProperty]
		public virtual Interview Interview { get; private set; }
		[JsonIgnore]
		public string GetFullName => $"{Surname.ToUpper()} {Name} {FatherName}";

		private Employee() { }
		public Employee(string surname, string name, string fatherName, string position,
			string city, string phone, DateTime birthday, string email, decimal salary,
			DateTime dateEmployment)
		{
			Surname = surname;
			Name = name;
			FatherName = fatherName;
			Phone = phone;
			Birthday = birthday;
			Email = email;
			PositionName = position;
			City = city;
			Salary = salary;
			DateEmployment = dateEmployment;
		}

		public void ChangeSalary(decimal newSalary) => Salary = newSalary;
		public void ChangePosition(string newPosition) => PositionName = newPosition;
	}
}