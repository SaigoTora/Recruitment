namespace SharedModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Education")]
    public partial class Education
    {
        public int id { get; set; }

        [Required]
        [StringLength(128)]
        public string name_institution { get; set; }

        [Required]
        [StringLength(64)]
        public string specialty { get; set; }

        public int year_admission { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_end { get; set; }

        public int id_questionnaire { get; set; }

        public int id_education_degree { get; set; }

        public int id_education_form { get; set; }

        public virtual EducationDegree Education_Degree { get; set; }

        public virtual Education_Form Education_Form { get; set; }

        public virtual Questionnaire Questionnaire { get; set; }
    }
}
