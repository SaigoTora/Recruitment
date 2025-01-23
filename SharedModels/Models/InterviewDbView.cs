using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedModels.Models
{
	[Table("View_Interview")]
	public partial class InterviewDbView
	{
		[Key]
		[Column(name: "id", Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; private set; }
		[Key]
		[Column(name: "position_name", Order = 1)]
		[StringLength(64)]
		public string PositionName { get; private set; }
		[Column("position_description")]
		public string PositionDescription { get; private set; }
		[Key]
		[Column(name: "date_event", Order = 2, TypeName = "datetime2")]
		public DateTime DateEvent { get; private set; }
		[Key]
		[Column(name: "status", Order = 3)]
		[StringLength(32)]
		public string Status { get; private set; }
		[Key]
		[Column(name: "id_application", Order = 4)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ApplicationId { get; private set; }
	}
}