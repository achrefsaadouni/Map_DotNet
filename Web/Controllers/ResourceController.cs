using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Web.Models;


namespace Web.Controllers
{
    public class ResourceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Resource
        public ActionResult listeResource()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Map-JavaEE-web/MAP/Resources/liste").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<ResourceViewModel>>().Result;
            }
            else { ViewBag.result = "erreur"; }
            return View("listeResource");
        }

        
        // GET: Resource/Create
        public ActionResult AddResource()
        {
            return View("AddResource");
        }


        [HttpPost]
         public ActionResult AddResource(ResourceViewModel resource , HttpPostedFileBase file)
         {
           
             string fileName = Path.GetFileNameWithoutExtension(file.FileName);
             string extension = Path.GetExtension(file.FileName);
             fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
             resource.picture = "~/Image/" + fileName;
            resource.roleT = Domain.Enumeration.Role.Resource;
             fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
             file.SaveAs(fileName);
             HttpClient client = new HttpClient();
             client.BaseAddress = new Uri("http://127.0.0.1:18080");
             client.PostAsJsonAsync<ResourceViewModel>("Map-JavaEE-web/MAP/Resources/add",resource);
              return RedirectToAction("listeResource");
            }

        // GET: Resource/Deateil
        public ActionResult DetailResource(int id)
        {
            ResourceViewModel resource = new ResourceViewModel();
            //string idResource = Convert.ToString(id);

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Map-JavaEE-web/MAP/Resources/resourceById?resourceId="+id).Result;
            if (response.IsSuccessStatusCode)
            {
                resource = response.Content.ReadAsAsync<ResourceViewModel>().Result;
                
            }
            else { ViewBag.result = "erreur"; }
            return View(resource);
        }



        // GET: Resource/Archiver
        public ActionResult Archiver(int? id)
        {
            ResourceViewModel resource = new ResourceViewModel();
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Map-JavaEE-web/MAP/Resources/resourceById?resourceId="+id).Result;
            if (response.IsSuccessStatusCode)
            {
                resource = response.Content.ReadAsAsync<ResourceViewModel>().Result;

            }
            else { ViewBag.result = "erreur"; }
            return View(resource);
        }

        
        [HttpPost]
        public ActionResult Archiver(ResourceViewModel rvm)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/plain"));
       
            HttpResponseMessage response = Client.PutAsJsonAsync<ResourceViewModel>("Map-JavaEE-web/MAP/Resources/archive?resourceId="+rvm.id, rvm).Result;

            return RedirectToAction("listeResource");
        }




        // GET: Resource/UpdateResource
        public ActionResult UpdateResource(int id)
        {
            ResourceViewModel resource = new ResourceViewModel();
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Map-JavaEE-web/MAP/Resources/resourceById?resourceId=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                resource = response.Content.ReadAsAsync<ResourceViewModel>().Result;

            }
            else { ViewBag.result = "erreur"; }
            return View(resource);
        }

        // POST: ResourceViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateResource([Bind(Include = "id,seniority,workProfil,salary,picture,moyenneSkill,jobType,cv,businessSector,availability,firstName,lastName,email,archived")] ResourceViewModel resourceViewModel)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080");
            HttpResponseMessage response = client.PutAsJsonAsync<ResourceViewModel>("Map-JavaEE-web/MAP/Resources/update", resourceViewModel).Result;
            return RedirectToAction("listeResource");
        }

    }
}
