using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Enumeration;
using Domain;
namespace Web.Models
{
    public class JobRequestModels
    {
        public int id { get; set; }

        
        public string Cv { get; set; }

        public DateTime? rdvdate { get; set; }

      
        public DateTime? sentdate { get; set; }

        
        public string speciality { get; set; }

      
        public string stateType { get; set; }

        //public int? candidate_id { get; set; }

     //  public virtual person person { get; set; }

    }

}