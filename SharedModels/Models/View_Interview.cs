namespace SharedModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

	[Table("View_Interview")]
	public partial class View_Interview
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string position_name { get; set; }

        public string position_description { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "datetime2")]
        public DateTime date_event { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(32)]
        public string status { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_application { get; set; }
    }
}
