namespace SharedModels.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("View_Interview")]
	public partial class ViewInterview
	{
		[Key]
		[Column(Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; private set; }
		[Key]
		[Column(Order = 1)]
		[StringLength(64)]
		public string PositionName { get; private set; }
		public string PositionDescription { get; private set; }
		[Key]
		[Column(Order = 2, TypeName = "datetime2")]
		public DateTime DateEvent { get; private set; }
		[Key]
		[Column(Order = 3)]
		[StringLength(32)]
		public string Status { get; private set; }
		[Key]
		[Column(Order = 4)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int IdApplication { get; private set; }

		public ViewInterview(string positionName, string positionDescription,
			string status, DateTime dateEvent)
		{
			PositionName = positionName;
			PositionDescription = positionDescription;
			Status = status;
			DateEvent = dateEvent;
		}
		public ViewInterview(int id, string positionName, string positionDescription,
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