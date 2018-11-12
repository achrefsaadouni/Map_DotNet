using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class JobRequestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobRequest
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Map-JavaEE-web/MAP/jobrequest").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<JobRequestModels>>().Result;
               
            }
            else { ViewBag.result = "erreur"; }

            return View();





        }

        // GET: JobRequest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JobRequest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobRequest/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: JobRequest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobRequest/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: JobRequest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobRequest/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
