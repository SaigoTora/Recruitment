namespace SharedModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

	[Table("View_Requirement")]
	public partial class View_Requirement
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int requirement_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int questionnaire_id { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(64)]
        public string city_candidate { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "date")]
        public DateTime birthday { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int experience { get; set; }

        public int? education_count { get; set; }

        [StringLength(256)]
        public string chronic_diseases { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool has_driver_license { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool smoker { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool drink_alcohol { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_business_trip_opportunity { get; set; }

        [StringLength(64)]
        public string city { get; set; }

        [Key]
        [Column(Order = 10)]
        public byte age_min { get; set; }

        [Key]
        [Column(Order = 11)]
        public byte age_max { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int exp_min { get; set; }

        [Key]
        [Column(Order = 13)]
        public bool diploma { get; set; }

        [Key]
        [Column(Order = 14)]
        public bool no_chronic_diseases { get; set; }

        [Key]
        [Column(Order = 15)]
        public bool driver_license { get; set; }

        [Key]
        [Column(Order = 16)]
        public bool no_smoker { get; set; }

        [Key]
        [Column(Order = 17)]
        public bool no_drink_alcohol { get; set; }

        [Key]
        [Column(Order = 18)]
        public bool business_trip_opportunity { get; set; }

        public bool? student { get; set; }
    }
}
