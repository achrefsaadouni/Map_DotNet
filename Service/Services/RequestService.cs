using Domain;
using Map_DotNet.Data.Infrastructure;
using Service.Interfaces;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
        public class RequestService : Service<request> , IRequestService
    {
        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbFactory);
        public RequestService() : base(uow)
        {
                
        }
    }
}
