using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SprojectViewModels
    {
        public int idProject { get; set; }
        public string projectName { get; set; }

        public List<projectskill> projectSkills { get; set; }

        public string Address { get; set; }

        public SClientViewModels Client { get; set; }

        public int LevioNbResource { get; set; }
        public SprojectViewModels(project p)
        {
            idProject = p.id;
            this.projectName = p.projectName;
            this.projectSkills = new List<projectskill>(p.projectskills);
            this.Address = p.address;
            Client = new SClientViewModels(p.person);
            this.LevioNbResource = p.levioNumberResource;
        }
        public SprojectViewModels()
        {
            projectSkills = new List<projectskill>();
        }
    }
}