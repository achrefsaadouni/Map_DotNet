using Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
namespace Web.Models
{
    public class SResourceViewModels
    {
        public int id { get; set; }
        public string seniority { get; set; }
        public string workProfil { get; set; }
        public float salary { get; set; }
        public string picture { get; set; }
        public float moyenneSkill { get; set; }
        public string jobType { get; set; }
        public string cv { get; set; }
        public string businessSector { get; set; }
        public AvailibilityType availability { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int archived { get; set; }
        public List<resourceskill> resourceSkills { get; set; }
    }
}