using Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedModels.Models
{
	[Table("EducationDegree_Point")]
	public partial class EducationDegreePoint : EntityBase
	{
		[Column("points")]
		public int Points { get; private set; }
		[Column("id_point")]
		public int PointId { get; private set; }
		[Column("id_education_degree")]
		public int EducationDegreeId { get; private set; }
		public virtual EducationDegree EducationDegree { get; private set; }
		public virtual Point Point { get; private set; }

		public EducationDegreePoint() { }
		public EducationDegreePoint(int points, int pointId, int educationDegreeId)
		{
			Points = points;
			PointId = pointId;
			EducationDegreeId = educationDegreeId;
		}
	}
}