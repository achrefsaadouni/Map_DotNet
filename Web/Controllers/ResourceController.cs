using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
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
            return View();
        }

        
        // GET: Resource/Create
        public ActionResult AddResource()
        {
            return View();
        }

     
        [HttpPost]
        public ActionResult AddResource(ResourceViewModel resource)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080");
            client.PostAsJsonAsync<ResourceViewModel>("Map-JavaEE-web/MAP/Resources/add",resource);
            return RedirectToAction("listeResource");
        }

    }
}
