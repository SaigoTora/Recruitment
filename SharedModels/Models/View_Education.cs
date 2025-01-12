namespace SharedModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Education
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        public string name_institution { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(64)]
        public string specialty { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int year_admission { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "date")]
        public DateTime date_end { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(32)]
        public string degree { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(32)]
        public string form { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_questionnaire { get; set; }
    }
}
