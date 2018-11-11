namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.mandate")]
    public partial class Mandate
    {
        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime dateDebut { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime dateFin { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int projetId { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ressourceId { get; set; }

        [Column(TypeName = "bit")]
        public bool archived { get; set; }

        public double montant { get; set; }

        public int gps_id { get; set; }

        public virtual person resource { get; set; }

        public virtual person Gps { get; set; }

        public virtual project project { get; set; }
    }
}
