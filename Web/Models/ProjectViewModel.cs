using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Domain;
using Newtonsoft.Json;

namespace Web.Models
{
    public class ProjectViewModel
    {

        public int id { get; set; }


        public string address { get; set; }
        [DataType(DataType.Date)]
        public DateTime? endDate { get; set; }

        public int levioNumberResource { get; set; }

        public string picture { get; set; }

        public string projectName { get; set; }

        public string projectType { get; set; }
        [DataType(DataType.Date)]
        public DateTime? startDate { get; set; }

        public int totalNumberResource { get; set; }
       // [JsonIgnore]
        public virtual person clientId { get; set; }

        //[JsonIgnore]
        //public int? clientId { get; set; }

    }
}