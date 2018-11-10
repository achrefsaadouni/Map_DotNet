namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.archivedprojects")]
    public partial class archivedproject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        public int client { get; set; }

        [Column(TypeName = "date")]
        public DateTime? endDate { get; set; }

        public int levioNumberResource { get; set; }

        [StringLength(255)]
        public string picture { get; set; }

        [StringLength(255)]
        public string projectName { get; set; }

        [StringLength(255)]
        public string projectType { get; set; }

        [Column(TypeName = "date")]
        public DateTime? startDate { get; set; }

        public int totalNumberResource { get; set; }
    }
}
