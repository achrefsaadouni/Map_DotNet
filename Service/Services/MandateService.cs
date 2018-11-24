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
        private IProjectService pros = new ProjectService();
        public MandateService():base(uow)
        {

        }
        public void addSuggestion(request  r , person p)
        {
            request req = rs.GetById(r.id);
            req.suggessedResource_id = p.id;
            person pp = ps.GetById(p.id);
            pp.availability = "availableSoon";
            rs.Update(req);
            ps.Update(pp);
            rs.Commit();
            ps.Commit();
        }
        public request getRequestSortedByProjectSkills(int id)
        {
            request r = rs.GetById(id);
            var r1 = from name in r.project.projectskills
                     orderby name.percentage descending
                     select name;
            r.project.projectskills = new List<projectskill>();
            foreach(var i in r1)
            {
                r.project.projectskills.Add(i);
            }
            return r;
        }

        public void cancelSuggesion(int id)
        {
            request s = rs.GetById(id);
            person p = ps.GetById((int)s.suggessedResource_id);
            s.suggessedResource_id = null;
            p.availability = "available";
            s.traiter = false;
            ps.Update(p);
            rs.Update(s);
            ps.Commit();
            rs.Commit();
           
        }
        public List<Mandate> getByClient(int id)
        {
            List<Mandate> result = new List<Mandate>();
            result.AddRange(this.GetMany(e => e.project.clientId == id));
            return result;
        }
        public List<Mandate> getByResource(int id)
        {
            List<Mandate> result = new List<Mandate>();
            result.AddRange(this.GetMany(e => e.person.id == id));
            return result;
        }
        public string getResourceMail(int id)
        {
            return rs.GetById(id).suggesedResource.email;
        }

        public void traitRequest(int id)
        {
            request r = rs.GetById(id);
            r.traiter = true;
            rs.Update(r);
            rs.Commit();
        }
        public List<person> getGps()
        {
            List<person> liste = new List<person>();
            liste.AddRange(ps.GetMany(e => e.availability.Equals("available") && e.roleT.Equals("Resource") ));
            return liste;
        }
        public void addGps(int id, int projectId, int resourceId, DateTime dateFin, DateTime dateDebut)
        {
            Mandate m = this.GetMany(e => e.dateDebut == dateDebut && e.dateFin == dateFin && e.projetId == projectId && e.ressourceId == resourceId).ElementAt(0);
            person p = ps.GetById(id);
            p.availability = "unavailable";
            m.gps_id = id;
            this.Update(m);
            this.Commit();
            ps.Update(p);
            ps.Commit();
        }

        public  void removeGps(int id, int projectId, int resourceId, DateTime dateFin, DateTime dateDebut)
        {
            Mandate m = this.GetMany(e => e.dateDebut == dateDebut && e.dateFin == dateFin && e.projetId == projectId && e.ressourceId == resourceId).ElementAt(0);
            m.gps_id = null;
            person p = ps.GetById(id);
            p.availability = "available";
            this.Update(m);
            this.Commit();
            ps.Update(p);
            ps.Commit();
        }
    }
    
}
