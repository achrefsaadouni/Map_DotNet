using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Domain;
using Web.Models;

namespace Web.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {

            List<ProjectViewModel> listProjectViewModels = new List<ProjectViewModel>();

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Map-JavaEE-web/MAP/projects").Result;
            ;
            if (response.IsSuccessStatusCode)
            {
                var listProject = response.Content.ReadAsAsync<IEnumerable<project>>().Result;
                //ViewBag.result = response.Content.ReadAsAsync<IEnumerable<ProjectViewModel>>().Result;
                foreach (var project in listProject)
                {
                    ProjectViewModel projectViewModel = new ProjectViewModel();
                    projectViewModel.endDate = project.endDate;
                    projectViewModel.levioNumberResource = project.levioNumberResource;
                    projectViewModel.picture = project.picture;
                    projectViewModel.projectName = project.projectName;
                    projectViewModel.projectType = project.projectType;
                    projectViewModel.startDate = project.startDate;
                    projectViewModel.totalNumberResource = project.totalNumberResource;
                    projectViewModel.clientId = project.clientId;
                    projectViewModel.address = project.address;
                    listProjectViewModels.Add(projectViewModel);

                }
            }
            else
            {
                ViewBag.result = "error";
            }
            return View(listProjectViewModels);
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
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

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Project/Edit/5
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

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Project/Delete/5
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
