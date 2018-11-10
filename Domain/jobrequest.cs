namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.jobrequest")]
    public partial class jobrequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string Cv { get; set; }

        [Column(TypeName = "date")]
        public DateTime? rdvdate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? sentdate { get; set; }

        [StringLength(255)]
        public string speciality { get; set; }

        [StringLength(255)]
        public string stateType { get; set; }

        public int? candidate_id { get; set; }

        public virtual person person { get; set; }
    }
}
