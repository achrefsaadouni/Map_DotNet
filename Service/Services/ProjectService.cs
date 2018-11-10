using Domain;
using Map_DotNet.Data.Infrastructure;
using ServicePattern;
using Service.Interfaces;

namespace Service.Services
{
    public class ProjectService : Service<project>, IProjectService
    {
        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbFactory);
        public ProjectService():base(uow)
        {

        }
    }
}
