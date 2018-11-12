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
        public int Id { get; set; }
        public StateType statetype { get; set; }

        public DateTime rdvdate { get; set; }

        private DateTime sentdate { get; set; }

        private String speciality { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
    }

}