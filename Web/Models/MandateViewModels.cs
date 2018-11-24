using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class MandateViewModels
    {
        public MandateId mandateId { get; set; }
        public bool archived { get; set; }

        public double montant { get; set; }

        public int gps_id { get; set; }

        public  person ressource { get; set; }

        public  person gps { get; set; }

        public  project projet { get; set; }
    }

}