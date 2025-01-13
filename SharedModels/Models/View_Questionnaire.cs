namespace SharedModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

	[Table("View_Questionnaire")]
	public partial class View_Questionnaire
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string nationality { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(64)]
        public string city { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int children_amount { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int experience { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool driver_license { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int readiness { get; set; }

        public string additional_info { get; set; }

        [StringLength(256)]
        public string chronic_diseases { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool smoker { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool drink_alcohol { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(32)]
        public string status { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(32)]
        public string opportunity { get; set; }

        public int? education_count { get; set; }

        public int? language_count { get; set; }
    }
}
