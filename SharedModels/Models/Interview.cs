namespace SharedModels.Models
{
	using SharedModels.Models.Base;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Interview")]
	public partial class Interview : EntityBase
	{
		[Column(TypeName = "datetime2")]
		public DateTime DateEvent { get; private set; }
		public int IdApplication { get; private set; }
		public int IdInterviewStatus { get; private set; }
		public virtual Application Application { get; private set; }
		public virtual InterviewStatus InterviewStatus { get; private set; }
		public virtual ICollection<Employee> Employee { get; private set; }
			= new HashSet<Employee>();
	}
}