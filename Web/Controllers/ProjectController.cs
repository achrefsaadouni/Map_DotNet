using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Domain;
using Service.Interfaces;
using Service.Services;
using Web.Models;
using Data;

namespace Web.Controllers
{
    public class ProjectController : Controller
    {
        private Context db = new Context();

        private IClientService clientService = new ClientService();
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Map-JavaEE-web/MAP/projects").Result;
            
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<ProjectViewModel>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View(ViewBag.result);
        }


        public ActionResult Details(int id)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Map-JavaEE-web/MAP/projects?projectId=" + id).Result;
            ViewBag.result = response.Content.ReadAsAsync<ProjectViewModel>().Result;

            return View(ViewBag.result);
        }


        public ActionResult Create()
        {
            initDropList();
            FillEnumDropDownList();
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(ProjectViewModel projectViewModel,FormCollection form)
        {
            initDropList();
            projectViewModel.totalNumberResource = 0;
            projectViewModel.levioNumberResource = 0;
            string clientId = Request.Form["CLIENT"].ToString();
            string projectType = Request.Form["TypeProject"].ToString();
            projectViewModel.projectType = projectType;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.PostAsJsonAsync<ProjectViewModel>("Map-JavaEE-web/MAP/projects?idClient=" + Int32.Parse(clientId), projectViewModel)
               .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            initDropList();
            FillEnumDropDownList();
            ProjectViewModel projectViewModel = null;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080/");
            var responseTask = Client.GetAsync("Map-JavaEE-web/MAP/projects?projectId=" + id.ToString());
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ProjectViewModel>();
                readTask.Wait();
                projectViewModel = readTask.Result;
            }
            ViewBag.CLIENT = new SelectList(db.people, "id", "nameSociety", projectViewModel.clientId.id);
            return View(projectViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProjectViewModel projectViewModel)
        {
            using (var client = new HttpClient())
            {
                String clientId = Request.Form["CLIENT"].ToString();
                string projectType = Request.Form["TypeProject"].ToString();
                projectViewModel.projectType = projectType;
                person person = clientService.GetById(Int32.Parse(clientId));
                projectViewModel.clientId = person;
                client.BaseAddress = new Uri("http://127.0.0.1:18080/");
                var putTask = client.PutAsJsonAsync<ProjectViewModel>("Map-JavaEE-web/MAP/projects", projectViewModel);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    
                    return RedirectToAction("Index");
                }
            }
            FillEnumDropDownList();
            ViewBag.CLIENT = new SelectList(db.people, "id", "nameSociety", projectViewModel.clientId.id);
            return View(projectViewModel);
        }

        public ActionResult Archive(int id)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Map-JavaEE-web/MAP/projects?projectId=" + id).Result;
            ViewBag.result = response.Content.ReadAsAsync<ProjectViewModel>().Result;
            return View(ViewBag.result);
        }

        [HttpPost]
        public ActionResult Archive(int id, FormCollection collection)
        {

            ProjectViewModel projectViewModel = null;
            HttpClient Client2 = new HttpClient();
            Client2.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client2.GetAsync("Map-JavaEE-web/MAP/projects?projectId=" + id).Result;
            ViewBag.result = response.Content.ReadAsAsync<ProjectViewModel>().Result;
            projectViewModel = ViewBag.result;


            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.PostAsJsonAsync<ProjectViewModel>("Map-JavaEE-web/MAP/projects/ArchiveProject" , projectViewModel)
                .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");

        }

        public void FillEnumDropDownList()
        {
            var list = new List<SelectListItem>

            {
                new SelectListItem{ Text="New project", Value = "newProject" },
                new SelectListItem{ Text="Project in progress", Value = "projectInProgress" },
                new SelectListItem{ Text="Completed project", Value = "completedProject"},
            };
            ViewBag.TypeProject = list;
        }

        public void initDropList()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Map-JavaEE-web/MAP/clients").Result;
            ViewBag.CLIENT = response.Content.ReadAsAsync<IEnumerable<ClientViewModel>>().Result;
        }
    }
}
