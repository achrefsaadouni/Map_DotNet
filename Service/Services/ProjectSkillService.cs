using System.Linq;
using Data;
using Domain;
using Map_DotNet.Data.Infrastructure;
using ServicePattern;
using Service.Interfaces;

namespace Service.Services
{
    public class ProjectSkillService : Service<projectskill>, IProjectSkillService
    {
        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbFactory);
        private Context db = new Context();
        public ProjectSkillService():base(uow)
        {}
        public dynamic getProjectSkills(int id)
        {
                
            return null;
        }
    }
}
