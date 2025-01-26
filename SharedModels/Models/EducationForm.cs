using Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedModels.Models
{
	[Table("Education_Form")]
	[Serializable]
	public partial class EducationForm : EntityBase
	{
		[Column("form")]
		[Required]
		[StringLength(32)]
		[JsonProperty]
		public string Form { get; private set; }
		[JsonIgnore]
		public virtual ICollection<Education> Educations { get; private set; }
			= new HashSet<Education>();

		public EducationForm() { }
		public EducationForm(string form)
			=> Form = form;
	}
}