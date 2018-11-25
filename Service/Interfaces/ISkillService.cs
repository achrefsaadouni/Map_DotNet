using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using ServicePattern;

namespace Service.Interfaces
{
    public interface ISkillService : IService<skill>
    {
    }
}
