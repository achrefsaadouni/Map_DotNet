using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MandateId
    {
        public DateTime dateDebut { get; set; }

        public DateTime dateFin { get; set; }

        public int projetId { get; set; }

        public int ressourceId { get; set; }
    }
}
