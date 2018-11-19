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
    }
}
