namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.skill")]
    public partial class skill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public skill()
        {
            projectskills = new HashSet<projectskill>();
            resourceskills = new HashSet<resourceskill>();
        }

        [Key]
        public int IdSkill { get; set; }

        [StringLength(255)]
        public string NameSkill { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projectskill> projectskills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resourceskill> resourceskills { get; set; }
        public skill(int idSkill, string nameSkill)
        {
            IdSkill = idSkill;
            NameSkill = nameSkill;
        }
    }
}
