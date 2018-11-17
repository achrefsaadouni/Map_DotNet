using System;
using System.ComponentModel.DataAnnotations;
using Domain;
using Domain.Enumeration;

namespace Web.Models
{
    public class ProjectViewModel
    {

        public int id { get; set; }

        public string address { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? endDate { get; set; }

        public int levioNumberResource { get; set; }

        public string picture { get; set; }

        public string projectName { get; set; }

        public string projectType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? startDate { get; set; }

        public int totalNumberResource { get; set; }
       // [JsonIgnore]
        public virtual person clientId { get; set; }

        //[JsonIgnore]
        //public int? clientId { get; set; }

    }
}