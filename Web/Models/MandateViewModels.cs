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

        public SResourceViewModels ressource { get; set; }

        public SResourceViewModels gps { get; set; }

        public SprojectViewModels projet { get; set; }

       

    }


}