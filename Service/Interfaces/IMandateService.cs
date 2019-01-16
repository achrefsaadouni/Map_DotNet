using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IMandateService : IService<Mandate>
    {
        void addSuggestion(request r , person s);

        request getRequestSortedByProjectSkills(int id);

        void cancelSuggesion(int id);

        List<Mandate> getByClient(int id);

        List<Mandate> getByResource(int id);

        string getResourceMail(int id);

        void traitRequest(int id);
        List<person> getGps();

        void addGps(int id, int projectId, int resourceId, DateTime dateFin, DateTime dateDebut);
        void removeGps(int id, int projectId, int resourceId, DateTime dateFin, DateTime dateDebut);
        List<project> listeprojectwithMondate();
        void updateProject(int requestId);
        void calculFrais(int projectId, int resourceId, DateTime dateFin, DateTime dateDebut);
    }


}
