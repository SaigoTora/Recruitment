namespace SharedModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Point")]
    public partial class Point
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Point()
        {
            EducationDegree_Point = new HashSet<EducationDegree_Point>();
            Vacancy = new HashSet<Vacancy>();
        }

        public int id { get; set; }

        public int age_under_18 { get; set; }

        public int age_18_30 { get; set; }

        public int age_30_50 { get; set; }

        public int age_over_50 { get; set; }

        public int exp_none { get; set; }

        public int exp_under_year { get; set; }

        public int exp_1_3 { get; set; }

        public int exp_over_3 { get; set; }

        public int diploma { get; set; }

        public int no_chronic_diseases { get; set; }

        public int driver_license { get; set; }

        public int no_smoker { get; set; }

        public int no_drink_alcohol { get; set; }

        public int business_trip_opportunity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationDegree_Point> EducationDegree_Point { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vacancy> Vacancy { get; set; }
    }
}
