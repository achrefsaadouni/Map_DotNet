using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Domain;

namespace Web.Models
{
    public class ProjectSkillViewModel
    {


        public int idProject { get; set; }

        public int idSkill { get; set; }

        public int percentage { get; set; }

        public virtual project project { get; set; }

        public virtual skill skill { get; set; }

        public ProjectSkillViewModel(int idProject, int idSkill, int percentage)
        {
            this.idProject = idProject;
            this.idSkill = idSkill;
            this.percentage = percentage;
        }
    }
}