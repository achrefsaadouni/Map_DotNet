using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SprojectViewModels
    {
        public string projectName { get; set; }

        public List<projectskill> projectSkills { get; set; }
        public string Address { get; set; }


    }
}