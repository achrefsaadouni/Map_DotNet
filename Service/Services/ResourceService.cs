using Domain;
using Map_DotNet.Data.Infrastructure;
using Service.Services;
using Service.Interfaces;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.services;
using Data;

namespace Service.Services
{
    public class ResourceService :Service<person> , IResourceService
    {

        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbFactory);
        public ResourceService():base(uow)
        {

        }
        IDayOffService dayOffService = new DayOffService();
        Context context = new Context();

        public List<person> getResourceArchive()
        {
            var liste = (
            from a in context.people
           
            where a.archived == 1
            
            select a).ToList();
            return liste;
        }
    }
}
