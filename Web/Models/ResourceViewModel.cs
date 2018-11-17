using Domain.Enumeration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ResourceViewModel
    {


        public int id { get; set; }
        public SeniorityType seniority { get; set; }
        [DisplayName("Work profile")]
        public WorkType workProfil { get; set; }
        public float salary { get; set; }
        public string picture { get; set; }
        [DisplayName("Average skills")]
        public float moyenneSkill { get; set; }
        [DisplayName("Job Type")]
        public JobType jobType { get; set; }
        public string cv { get; set; }
        [DisplayName("Business Sector")]
        public string businessSector { get; set; }
        public AvailibilityType availability { get; set; }
        [DisplayName("First Name")]
        public string firstName { get; set; }
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        public string email { get; set; }
        public int archived { get; set; }
        public string password { get; set; }
        
        public Role roleT { get; set; }
        //public HttpPostedFileBase ImageFile { get; set; }
    }
}