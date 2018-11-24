using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class StatAdminController : Controller
    {
        // GET: StatAdmin
        public ActionResult Index()
        {
            System.Net.Http.HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Map-JavaEE-web/MAP/StatCandidate/CountCadidateResultByTypeTest").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var s = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                
                ViewBag.result1 = result.ToString().Replace("&quot;", " ");
                //ViewBag.result = response.Content;
               
            }
            else
            {
                ViewBag.result1 = "erreur";
            }
            //return View("listeResource");
            ViewBag.result2 = "dhouha mata";
            return View();
        }
    }
}