using Domain;
using Domain.Enumeration;
using Service.Interfaces;
using Service.services;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class DayOffController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        IDayOffService dayOffService = new DayOffService();
        IResourceService personService = new ResourceService();
        List<DayOffViewModel> listeDayOffViewModel = new List<DayOffViewModel>();
        public static int resourceId { get; set; }



        // GET: DayOff
        public ActionResult Index()
        {
            return View(db.DayOffViewModels.ToList());
        }

        public ActionResult Lister()
        {
            
           
            return View("Lister");
        }
        public JsonResult GetDaysOff(int id)
        {
            id = 3;
            List<dayoff> listeDayOff = dayOffService.ListerDayOff(id);
           
            foreach (var i in listeDayOff)
            {
                DayOffViewModel dayOffViewModel = new DayOffViewModel();
                dayOffViewModel.id = i.id;
                dayOffViewModel.reason = i.reason;
                dayOffViewModel.startDate = i.startDate;
                dayOffViewModel.endDate = i.endDate;
                dayOffViewModel.stateType = i.stateType;
                dayOffViewModel.typeDayOff = i.typeDayOff;
                listeDayOffViewModel.Add(dayOffViewModel);
            }
            return new JsonResult { Data = listeDayOffViewModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetDaysOffOnHold(int id)
        {
            List<dayoff> listeDayOff = dayOffService.ListerDayOffHoldOn(id);

            foreach (var i in listeDayOff)
            {
                DayOffViewModel dayOffViewModel = new DayOffViewModel();
                dayOffViewModel.id = i.id;
                dayOffViewModel.reason = i.reason;
                dayOffViewModel.startDate = i.startDate;
                dayOffViewModel.endDate = i.endDate;
                dayOffViewModel.stateType = i.stateType;
                dayOffViewModel.typeDayOff = i.typeDayOff;
                listeDayOffViewModel.Add(dayOffViewModel);
            }
            return new JsonResult { Data = listeDayOffViewModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        [HttpPost]
        public JsonResult DeleteDayOff(int dayOffId)
        {var status = false;
            dayoff day = dayOffService.getDayOffById(3, dayOffId);
            status = dayOffService.deleteDayOff(day);
                
            return new JsonResult { Data = new { status = status } };
        }
        [HttpPost]
        public ActionResult AddDayOff(DayOffViewModel dayOff)
        {
            person p = personService.GetById(3);

            if (dayOff.startDate.CompareTo(dayOff.endDate) > 0)
            {
                return View("AddDayOff");

            }
            else { 
            if (dayOff.stateType.Equals("refused") || dayOff.stateType.Equals("onHold"))
            {
                HttpClient client4 = new HttpClient();
                client4.BaseAddress = new Uri("http://127.0.0.1:18080");
                client4.PostAsJsonAsync<DayOffViewModel>("Map-JavaEE-web/MAP/DayOff/affecter?resourceId=" + 3, dayOff);
            }
            else if (dayOff.stateType.Equals("accepted")) {

             if(p.nombreConge >= 30 && p.nombreAlerte > 3)
                {
                HttpClient client0 = new HttpClient();
                client0.BaseAddress = new Uri("http://127.0.0.1:18080");
                client0.PostAsJsonAsync<DayOffViewModel>("Map-JavaEE-web/MAP/DayOff/affecter?resourceId=" + 3, dayOff);
              
                p.salary = p.salary - 10;
                p.nombreConge = 0;
                p.nombreAlerte = 0;
                personService.Update(p);
                personService.Commit();
                return View("AddDayOff");

                }



               if(p.nombreConge >= 30 && p.nombreAlerte <3)
            {
                p.nombreAlerte = p.nombreAlerte + 1;
                p.nombreConge = 0;
                personService.Update(p);
                personService.Commit();
                HttpClient client1 = new HttpClient();
                client1.BaseAddress = new Uri("http://127.0.0.1:18080");
                client1.PostAsJsonAsync<DayOffViewModel>("Map-JavaEE-web/MAP/DayOff/affecter?resourceId=" + 3, dayOff);
            }

            else {
                TimeSpan Diff = dayOff.endDate - dayOff.startDate;
                p.nombreConge = p.nombreConge + (int)Diff.TotalDays;
                personService.Update(p);
                personService.Commit();
           
            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri("http://127.0.0.1:18080");
            client2.PostAsJsonAsync<DayOffViewModel>("Map-JavaEE-web/MAP/DayOff/affecter?resourceId="+3,dayOff);
            }
                }
            }
            return RedirectToRoute("ListeResource");

        }

        public ActionResult AddDayOff()
        {
            return View();
        }


        public ActionResult listeDayOff()
        {
            return View("AffectDayOff");
        }

        public ActionResult AffectDayOff()
        {
            return View("AffectDayOff");
        }


        
        
    }
}
