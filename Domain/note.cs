namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.note")]
    public partial class note
    {
        public int noteId { get; set; }

        public float noteResource { get; set; }

        public int? id_Client { get; set; }

        public int? id_Resource { get; set; }

        public virtual person person { get; set; }

        public virtual person person1 { get; set; }
    }
}
