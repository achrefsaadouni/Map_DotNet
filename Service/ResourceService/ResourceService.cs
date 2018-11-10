using Domain;
using Map_DotNet.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ResourceService
{
    public class ResourceService :Service<person> , IResourceService
    {

        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbFactory);
        public ResourceService():base(uow)
        {

        }
    }
}
