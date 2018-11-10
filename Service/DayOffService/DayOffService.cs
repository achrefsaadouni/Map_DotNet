using Domain;
using Map_DotNet.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DayOffService
{
   public class DayOffService :Service<dayoff> , IDayOffService
    {

        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbFactory);


        public DayOffService():base(uow)
        {

        }
    }
}
