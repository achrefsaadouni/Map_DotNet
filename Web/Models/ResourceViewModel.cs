using Domain;
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
        public string seniority { get; set; }
        [DisplayName("Work profile")]
        public string workProfil { get; set; }
        public float salary { get; set; }
        public string picture { get; set; }
        [DisplayName("Average skills")]
        public float moyenneSkill { get; set; }
        [DisplayName("Job Type")]
        public string jobType { get; set; }
        public string cv { get; set; }
        [DisplayName("Business Sector")]
        public string businessSector { get; set; }
        public string availability { get; set; }
        [DisplayName("First Name")]
        public string firstName { get; set; }
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        public string email { get; set; }
        public int archived { get; set; }
        public string password { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dayoff> dayoffs { get; set; }
        public int nombreConge { get; set; }
        public int nombreAlerte { get; set; }

        public Role roleT { get; set; }
        //public HttpPostedFileBase ImageFile { get; set; }
    }
}