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

            return View(ViewBag.result);





        }

        // GET: JobRequest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: JobRequest/Create
        public ActionResult Create()
        {
          
            return View();
        }

        // POST: JobRequest/Create
        [HttpPost]
        public ActionResult Create(JobRequestModels JobRequestModels)
        {
            try
            {
                HttpClient Client = new HttpClient();
                Client.BaseAddress = new Uri("http://127.0.0.1:18080/");
                Client.PostAsJsonAsync<JobRequestModels>("Map-JavaEE-web/MAP/jobrequest", JobRequestModels)
                  .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: JobRequest/Edit/5
        public ActionResult Edit(int id)
        {
            JobRequestModels jobrequest = null;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080/");
            var responseTask = Client.GetAsync("Map-JavaEE-web/MAP/jobrequest/ShowMyReq/" + id.ToString());
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<JobRequestModels>();
                readTask.Wait();

                jobrequest = readTask.Result;
            }
            return View(jobrequest);
        }

        // POST: JobRequest/Edit/5
        [HttpPost]
        public ActionResult Edit(JobRequestModels JobRequestModels)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://127.0.0.1:18080/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<JobRequestModels>("Map-JavaEE-web/MAP/jobrequest/update", JobRequestModels);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(JobRequestModels);
        
    }

        // GET: JobRequest/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: JobRequest/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                 HttpClient Client = new HttpClient();
                Client.BaseAddress = new Uri("http://127.0.0.1:18080/");
                //HTTP DELETE
                var deleteTask = Client.DeleteAsync("Map-JavaEE-web/MAP/jobrequest/delete/" + id.ToString());
                deleteTask.Wait();
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
