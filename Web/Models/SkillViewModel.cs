using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SkillViewModel
    {
        public SkillViewModel(int idSkill , string nameSkill)
        {
            IdSkill = idSkill;
            NameSkill = nameSkill;
        }

        public SkillViewModel()
        {
            
        }
        public int IdSkill { get; set; }
        public string NameSkill { get; set; }
    }
}