namespace SharedModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

	[Table("View_Vacancy")]
	public partial class View_Vacancy
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
        [Column(Order = 2, TypeName = "money")]
        public decimal salary { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "datetime2")]
        public DateTime date_publication { get; set; }

        public int? application_count { get; set; }

        public string info { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool relevance { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_point { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_requirement { get; set; }
    }
}
