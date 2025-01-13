namespace SharedModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Questionnaire")]
    public partial class Questionnaire
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Questionnaire()
        {
            Candidate = new HashSet<Candidate>();
            Education = new HashSet<Education>();
            Language = new HashSet<Language>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(64)]
        public string nationality { get; set; }

        [Required]
        [StringLength(64)]
        public string city { get; set; }

        public int children_amount { get; set; }

        public int experience { get; set; }

        public bool driver_license { get; set; }

        public int readiness { get; set; }

        public string additional_info { get; set; }

        public int id_health { get; set; }

        public int id_family_status { get; set; }

        public int id_business_trip_opportunity { get; set; }

        public virtual BusinessTripOpportunity Business_Trip_Opportunity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Candidate> Candidate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education> Education { get; set; }

        public virtual FamilyStatus Family_Status { get; set; }

        public virtual Health Health { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Language> Language { get; set; }
    }
}
