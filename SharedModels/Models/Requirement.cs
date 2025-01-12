namespace SharedModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Requirement")]
    public partial class Requirement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Requirement()
        {
            EducationDegree_Requirement = new HashSet<EducationDegree_Requirement>();
            Vacancy = new HashSet<Vacancy>();
        }

        public int id { get; set; }

        [StringLength(64)]
        public string city { get; set; }

        public byte age_min { get; set; }

        public byte age_max { get; set; }

        public int exp_min { get; set; }

        public bool diploma { get; set; }

        public bool no_chronic_diseases { get; set; }

        public bool driver_license { get; set; }

        public bool no_smoker { get; set; }

        public bool no_drink_alcohol { get; set; }

        public bool business_trip_opportunity { get; set; }

        public bool? student { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationDegree_Requirement> EducationDegree_Requirement { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vacancy> Vacancy { get; set; }
    }
}
