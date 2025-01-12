namespace SharedModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EducationDegree_Point
    {
        public int id { get; set; }

        public int points { get; set; }

        public int id_point { get; set; }

        public int id_education_degree { get; set; }

        public virtual Education_Degree Education_Degree { get; set; }

        public virtual Point Point { get; set; }
    }
}
