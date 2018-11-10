namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.organizationalchart")]
    public partial class organizationalchart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public organizationalchart()
        {
            projects = new HashSet<project>();
            people = new HashSet<person>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string accountManager { get; set; }

        [StringLength(255)]
        public string clientName { get; set; }

        [StringLength(255)]
        public string directionalLevel { get; set; }

        [StringLength(255)]
        public string nameAssignmentManagerClient { get; set; }

        [StringLength(255)]
        public string programName { get; set; }

        [StringLength(255)]
        public string projectName { get; set; }

        [StringLength(255)]
        public string projectResponsible { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project> projects { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<person> people { get; set; }
    }
}
