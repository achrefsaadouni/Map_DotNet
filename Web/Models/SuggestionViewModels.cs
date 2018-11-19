using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SuggestionViewModels
    {
        public SrequestModelViews request { get; set; }
        public List<SResourceViewModels> resources { get; set;}
    }
}