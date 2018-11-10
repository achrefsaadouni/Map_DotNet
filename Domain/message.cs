namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.message")]
    public partial class message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string content { get; set; }

        public DateTime? dateMessage { get; set; }

        [Column("object")]
        [StringLength(255)]
        public string _object { get; set; }

        [StringLength(255)]
        public string receiver { get; set; }

        [StringLength(255)]
        public string sender { get; set; }

        public int? typeMessage { get; set; }

        public int? inBox_id { get; set; }

        public int? person_id { get; set; }

        public virtual inbox inbox { get; set; }

        public virtual person person { get; set; }
    }
}
