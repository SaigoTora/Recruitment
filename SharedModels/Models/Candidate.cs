namespace SharedModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Candidate")]
    public partial class Candidate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Candidate()
        {
            Application = new HashSet<Application>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(16)]
        public string login { get; set; }

        [Required]
        [StringLength(16)]
        public string password { get; set; }

        [Required]
        [StringLength(64)]
        public string surname { get; set; }

        [Required]
        [StringLength(64)]
        public string name { get; set; }

        [StringLength(64)]
        public string father_name { get; set; }

        [Required]
        [StringLength(13)]
        public string phone { get; set; }

        [Column(TypeName = "date")]
        public DateTime birthday { get; set; }

        [Required]
        [StringLength(64)]
        public string email { get; set; }

        public int id_questionnaire { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Application> Application { get; set; }

        public virtual Questionnaire Questionnaire { get; set; }
    }
}
