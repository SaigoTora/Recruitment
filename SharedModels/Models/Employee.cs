namespace SharedModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int id { get; set; }

        [Required]
        [StringLength(64)]
        public string surname { get; set; }

        [Required]
        [StringLength(64)]
        public string name { get; set; }

        [StringLength(64)]
        public string father_name { get; set; }

        [Required]
        [StringLength(64)]
        public string position_name { get; set; }

        [Required]
        [StringLength(64)]
        public string city { get; set; }

        [Required]
        [StringLength(16)]
        public string phone { get; set; }

        [Column(TypeName = "date")]
        public DateTime birthday { get; set; }

        [Required]
        [StringLength(64)]
        public string email { get; set; }

        [Column(TypeName = "money")]
        public decimal salary { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_employment { get; set; }

        public int? id_interview { get; set; }

        public virtual Interview Interview { get; set; }
    }
}
