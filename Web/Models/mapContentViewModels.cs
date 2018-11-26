using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class mapContentViewModels
    {
        public SprojectViewModels projet { get; set; }
        public List<SResourceViewModels> resources { get; set; }
        public mapContentViewModels()
        {
            resources = new List<SResourceViewModels>();
        }
    }
}