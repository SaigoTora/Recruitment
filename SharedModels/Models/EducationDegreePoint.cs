using Base;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedModels.Models
{
	[Table("EducationDegree_Point")]
	[Serializable]
	public partial class EducationDegreePoint : EntityBase
	{
		[Column("points")]
		[JsonProperty]
		public int Points { get; private set; }
		[Column("id_point")]
		[JsonProperty]
		public int PointId { get; private set; }
		[Column("id_education_degree")]
		[JsonProperty]
		public int EducationDegreeId { get; private set; }
		[JsonProperty]
		public virtual EducationDegree EducationDegree { get; private set; }
		[JsonIgnore]
		public virtual Point Point { get; private set; }

		private EducationDegreePoint() { }
		public EducationDegreePoint(int points, int pointId, int educationDegreeId)
		{
			Points = points;
			PointId = pointId;
			EducationDegreeId = educationDegreeId;
		}
	}
}