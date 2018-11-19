using Domain;
using Map_DotNet.Data.Infrastructure;
using Service.Interfaces;
using Service.Services;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MandateService : Service<Mandate>, IMandateService
    {
        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbFactory);
        private IRequestService rs = new RequestService();
        private IPersonService ps = new PersonService();
        public MandateService():base(uow)
        {

        }
        public void addSuggestion(request  r , person p)
        {
      
            request req = rs.GetById(r.id);
            req.suggessedResource_id = p.id;
            req.traiter = true;
            rs.Update(req);
            rs.Commit();
        }
    }
}
