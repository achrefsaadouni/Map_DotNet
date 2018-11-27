using Domain;
using Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class DayOffViewModel
    {

        public int id { get; set; }

       
        public DateTime endDate { get; set; }

      
        public string reason { get; set; }

      
        public DateTime startDate { get; set; }

        public string stateType { get; set; }
        public string typeDayOff { get; set; }
     



    }
}