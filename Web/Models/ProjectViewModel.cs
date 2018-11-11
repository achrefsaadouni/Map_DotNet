using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Domain;

namespace Web.Models
{
    public class ProjectViewModel
    {

        public int id { get; set; }

        public string address { get; set; }

        public DateTime? endDate { get; set; }

        public int levioNumberResource { get; set; }

        public string picture { get; set; }

        public string projectName { get; set; }

        public string projectType { get; set; }

        public DateTime? startDate { get; set; }

        public int totalNumberResource { get; set; }

        public int? clientId { get; set; }

        public int? organizationalChart_id { get; set; }

        public virtual ICollection<Mandate> mandates { get; set; }

        public virtual organizationalchart organizationalchart { get; set; }

        public virtual ICollection<person> people { get; set; }

        public virtual person person { get; set; }

        public virtual ICollection<projectskill> projectskills { get; set; }

        public virtual ICollection<request> requests { get; set; }
    }
}