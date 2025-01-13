using System.ComponentModel.DataAnnotations.Schema;

namespace SharedModels.Models
{
	[Table("EducationDegree_Point")]
	public partial class EducationDegreePoint
	{
		public int Id { get; private set; }
		public int Points { get; private set; }
		public int IdPoint { get; private set; }
		public int IdEducationDegree { get; private set; }
		public virtual Education_Degree Education_Degree { get; private set; }
		public virtual Point Point { get; private set; }

		public EducationDegreePoint(int idDegree, int point)
		{
			IdEducationDegree = idDegree;
			Points = point;
		}
	}
}