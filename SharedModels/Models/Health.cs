namespace SharedModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Health")]
    public partial class Health
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Health()
        {
            Questionnaire = new HashSet<Questionnaire>();
        }

        public int id { get; set; }

        [StringLength(256)]
        public string chronic_diseases { get; set; }

        public bool smoker { get; set; }

        public bool drink_alcohol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Questionnaire> Questionnaire { get; set; }
    }
}
