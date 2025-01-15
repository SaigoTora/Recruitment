namespace SharedModels.Models
{
	using SharedModels.Models.Base;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Employee")]
	public partial class Employee : EntityBase
	{
		[Required]
		[StringLength(64)]
		public string Surname { get; private set; }
		[Required]
		[StringLength(64)]
		public string Name { get; private set; }
		[StringLength(64)]
		public string FatherName { get; private set; }
		[Required]
		[StringLength(64)]
		public string PositionName { get; private set; }
		[Required]
		[StringLength(64)]
		public string City { get; private set; }
		[Required]
		[StringLength(16)]
		public string Phone { get; private set; }
		[Column(TypeName = "date")]
		public DateTime Birthday { get; private set; }
		[Required]
		[StringLength(64)]
		public string Email { get; private set; }
		[Column(TypeName = "money")]
		public decimal Salary { get; private set; }
		[Column(TypeName = "date")]
		public DateTime DateEmployment { get; private set; }
		public int? IdInterview { get; private set; }
		public virtual Interview Interview { get; private set; }

		public Employee(int id, string surname, string name, string fatherName, string position,
			string city, string phone, DateTime birthday, string email, decimal salary,
			DateTime dateEmployment)
		{
			Id = id;
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