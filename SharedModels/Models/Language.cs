namespace SharedModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Language")]
    public partial class Language
    {
        public int id { get; set; }

        [Required]
        [StringLength(64)]
        public string name { get; set; }

        public int level { get; set; }

        public int id_questionnaire { get; set; }

        public virtual Questionnaire Questionnaire { get; set; }
    }
}
