namespace SharedModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vacancy")]
    public partial class Vacancy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vacancy()
        {
            Application = new HashSet<Application>();
        }

        public int id { get; set; }

        [Column(TypeName = "money")]
        public decimal salary { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime date_publication { get; set; }

        public string info { get; set; }

        public bool relevance { get; set; }

        public int id_point { get; set; }

        public int id_requirement { get; set; }

        public int id_position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Application> Application { get; set; }

        public virtual Point Point { get; set; }

        public virtual Position Position { get; set; }

        public virtual Requirement Requirement { get; set; }
    }
}
