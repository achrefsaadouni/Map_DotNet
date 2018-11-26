using Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
namespace Web.Models
{
    public class SResourceViewModels
    {
        public int id { get; set; }
        public string seniority { get; set; }
        public string workProfil { get; set; }
        public float salary { get; set; }
        public string picture { get; set; }
        public float moyenneSkill { get; set; }
        public string jobType { get; set; }
        public string cv { get; set; }
        public string businessSector { get; set; }
        public string availability { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int archived { get; set; }
        public List<resourceskill> resourceSkills { get; set; }
        public SResourceViewModels(person p)
        {
            id = p.id;
            seniority = p.seniority;
            workProfil = p.workProfil;
            salary = (float)p.salary;
            picture = p.picture;
            moyenneSkill = (float)p.moyenneSkill;
            jobType = p.jobType;
            cv = p.cv;
            businessSector = p.businessSector;
            availability = p.availability;
            firstName = p.firstName;
            lastName = p.lastName;
            email = p.email;
            archived = p.archived;
            resourceSkills = new List<resourceskill>(p.resourceskills);
    }
        public SResourceViewModels()
        {
            resourceSkills = new List<resourceskill>();
        }
    }
}