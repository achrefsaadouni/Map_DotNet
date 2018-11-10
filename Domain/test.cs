namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.test")]
    public partial class test
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string Employment_Letter { get; set; }

        [StringLength(255)]
        public string TestFile { get; set; }

        [StringLength(255)]
        public string TestResponseFile { get; set; }

        [StringLength(255)]
        public string TestType { get; set; }

        [StringLength(255)]
        public string result { get; set; }

        [Column(TypeName = "date")]
        public DateTime? testDeadLine { get; set; }

        public DateTime? testUploadTime { get; set; }

        public int? candidate_id { get; set; }

        public virtual person person { get; set; }
    }
}
