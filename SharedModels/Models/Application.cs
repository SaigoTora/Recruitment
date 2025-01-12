namespace SharedModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Application")]
    public partial class Application
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Application()
        {
            Interview = new HashSet<Interview>();
        }

        public int id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime date_submission { get; set; }

        public int scores { get; set; }

        public string additional_info { get; set; }

        public string reason_rejection { get; set; }

        public int id_application_status { get; set; }

        public int id_candidate { get; set; }

        public int id_vacancy { get; set; }

        public virtual Application_Status Application_Status { get; set; }

        public virtual Candidate Candidate { get; set; }

        public virtual Vacancy Vacancy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Interview> Interview { get; set; }
    }
}
