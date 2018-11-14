using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Map_DotNet.Data.Infrastructure;
using Service.Interfaces;
using ServicePattern;

namespace Service.Services
{
    public class ClientService : Service<person>, IClientService
    {
        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbFactory);

        public ClientService() : base(uow)
        {

        }
    }
}
