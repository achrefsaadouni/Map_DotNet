using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class MandateViewModels
    {
 
        public DateTime dateDebut { get; set; }

        public DateTime dateFin { get; set; }

        public int projetId { get; set; }

        public int ressourceId { get; set; }

        public bool archived { get; set; }

        public double montant { get; set; }

        public int gps_id { get; set; }

        public virtual person resource { get; set; }

        public virtual person Gps { get; set; }

        public virtual project project { get; set; }
    }
}