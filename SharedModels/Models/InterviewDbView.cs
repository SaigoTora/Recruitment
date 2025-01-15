namespace SharedModels.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

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
		public int IdApplication { get; private set; }

		public InterviewDbView() { }
		public InterviewDbView(string positionName, string positionDescription,
			string status, DateTime dateEvent)
		{
			PositionName = positionName;
			PositionDescription = positionDescription;
			Status = status;
			DateEvent = dateEvent;
		}
		public InterviewDbView(int id, string positionName, string positionDescription,
			string status, DateTime dateEvent, int idApplication)
			: this(positionName, positionDescription, status, dateEvent)
		{
			Id = id;
			IdApplication = idApplication;
		}

		public void ChangeDateEvent(DateTime dateTime)
			=> DateEvent = dateTime;
	}
}