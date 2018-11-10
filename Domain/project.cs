namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.project")]
    public partial class project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public project()
        {
            mandates = new HashSet<Mandate>();
            people = new HashSet<person>();
            projectskills = new HashSet<projectskill>();
            requests = new HashSet<request>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? endDate { get; set; }

        public int levioNumberResource { get; set; }

        [StringLength(255)]
        public string picture { get; set; }

        [StringLength(255)]
        public string projectName { get; set; }

        [StringLength(255)]
        public string projectType { get; set; }

        [Column(TypeName = "date")]
        public DateTime? startDate { get; set; }

        public int totalNumberResource { get; set; }

        public int? clientId { get; set; }

        public int? organizationalChart_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mandate> mandates { get; set; }

        public virtual organizationalchart organizationalchart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<person> people { get; set; }

        public virtual person person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projectskill> projectskills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<request> requests { get; set; }
    }
}
