using Data;
using Domain;
using Domain.Enumeration;
using Map_DotNet.Data.Infrastructure;
using Service.Interfaces;

using Service.Services;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.services
{
    public class DayOffService : Service<dayoff>, IDayOffService
    {

        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbFactory);
       // IResourceService resourceS = new ResourceService();
        Context context = new Context();

        public DayOffService() : base(uow)
        {

        }

        public List<dayoff> ListerDayOff(int resourceId)
        {
            var result = (
            from a in context.people
            from b in a.dayoffs
            join c in context.dayoffs on b.id equals c.id

            where a.id == resourceId

            where( b.stateType.Equals(StateType.accepted.ToString() ))
            
           

            select c ).ToList();


            return result;

        }

        public List<dayoff> ListerDayOffHoldOn(int resourceId)
        {
            var result = (
            from a in context.people
            from b in a.dayoffs
            join c in context.dayoffs on b.id equals c.id

            where a.id == resourceId

            where (b.stateType.Equals(StateType.onHold.ToString()))



            select c).ToList();


            return result;

        }



        public dayoff getDayOffById(int resourceId , int dayoffId)
        {
            var result = (
            from a in context.people
            from b in a.dayoffs
            join c in context.dayoffs on b.id equals c.id

            where a.id == resourceId
            where c.id == dayoffId
            
            select c).FirstOrDefault();


            return result;

        }

        public Boolean deleteDayOff(dayoff d)
        {
            d.stateType = StateType.refused.ToString();
            context.SaveChanges();
            return true;
        }


        public Boolean AccepterDayOff(dayoff d)
        {
            d.stateType = StateType.accepted.ToString();
            context.SaveChanges();
            return true;
        }
    }
}
