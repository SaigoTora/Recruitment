namespace SharedModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Application
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "datetime2")]
        public DateTime date_submission { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int scores { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(32)]
        public string status { get; set; }

        public string additional_info { get; set; }

        public string reason_rejection { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(64)]
        public string position_name { get; set; }

        public string position_description { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_candidate { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_vacancy { get; set; }
    }
}
