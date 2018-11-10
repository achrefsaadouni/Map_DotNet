namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.resourceskill")]
    public partial class resourceskill
    {
        [Key]
        public int IdResourceSkill { get; set; }

        public float rateSkill { get; set; }

        public int? id { get; set; }

        public int? IdSkill { get; set; }

        public virtual person person { get; set; }

        public virtual skill skill { get; set; }
    }
}
