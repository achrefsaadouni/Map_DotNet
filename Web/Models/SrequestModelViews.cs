using Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SrequestModelViews
    {
        public int id { get; set; }
        public string requestedProfil { get; set; }
        public int experienceYear  { get; set; }
        public SprojectViewModels project { get; set;}
        public DateTime startDateMondate { get; set; }
        public DateTime endDateMondate { get; set; }
        public ClientViewModel Client { get; set; }
        public DateTime depositDate { get; set; }
        public Boolean traiter { get; set; }
        public SResourceViewModels suggessedResource { get; set; }
    }
}