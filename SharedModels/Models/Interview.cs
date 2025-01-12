namespace SharedModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Interview")]
    public partial class Interview
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Interview()
        {
            Employee = new HashSet<Employee>();
        }

        public int id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime date_event { get; set; }

        public int id_application { get; set; }

        public int id_interview_status { get; set; }

        public virtual Application Application { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employee { get; set; }

        public virtual Interview_Status Interview_Status { get; set; }
    }
}
