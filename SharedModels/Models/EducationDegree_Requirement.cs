namespace SharedModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EducationDegree_Requirement
    {
        public int id { get; set; }

        public int id_requirement { get; set; }

        public int id_education_degree { get; set; }

        public virtual Education_Degree Education_Degree { get; set; }

        public virtual Requirement Requirement { get; set; }
    }
}
