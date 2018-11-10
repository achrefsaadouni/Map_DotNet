namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.request")]
    public partial class request
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? depositDate { get; set; }

        public TimeSpan? depositTime { get; set; }

        [StringLength(255)]
        public string educationScolarity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? endDateMondate { get; set; }

        public int experienceYear { get; set; }

        [StringLength(255)]
        public string manager { get; set; }

        [StringLength(255)]
        public string requestedProfil { get; set; }

        [Column(TypeName = "date")]
        public DateTime? startDateMondate { get; set; }

        public int? administrator_id { get; set; }

        public int? client_id { get; set; }

        public int? project_id { get; set; }

        public int? suggessedResource_id { get; set; }

        public virtual person person { get; set; }

        public virtual person person1 { get; set; }

        public virtual person person2 { get; set; }

        public virtual project project { get; set; }
    }
}
