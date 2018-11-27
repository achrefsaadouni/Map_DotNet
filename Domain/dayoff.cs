namespace Domain
{
    using Enumeration;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("map.dayoff")]
    public partial class dayoff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dayoff()
        {
            people = new HashSet<person>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime endDate { get; set; }

        [StringLength(255)]
        public string reason { get; set; }

        [Column(TypeName = "date")]
        public DateTime startDate { get; set; }

        public string stateType { get; set; }

        

        public string typeDayOff { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<person> people { get; set; }
    }
}
