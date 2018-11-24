namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.candidatefolder")]
    public partial class candidatefolder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string Motivation_Letter { get; set; }

        [StringLength(255)]
        public string Passport { get; set; }

        [StringLength(255)]
        public string Section_3 { get; set; }

        [StringLength(255)]
        public string medical_folder { get; set; }

        public int? Candidate_id { get; set; }

        public virtual person person { get; set; }
    }
}
