namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.contract")]
    public partial class contract
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int archived { get; set; }

        [Column(TypeName = "date")]
        public DateTime? endDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? startDate { get; set; }

        public int? client_id { get; set; }

        public virtual person person { get; set; }
    }
}
