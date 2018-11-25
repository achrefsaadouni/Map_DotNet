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
        public ActionResult GeneralInformation()
        {
            //ClientByCategory
            System.Net.Http.HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Map-JavaEE-web/MAP/StatAdmin/CountClientByCategory").Result;
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

            //ClientByType
            System.Net.Http.HttpClient Client1 = new HttpClient();
            Client1.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client1.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response1 = Client1.GetAsync("Map-JavaEE-web/MAP/StatAdmin/CountClientByType").Result;
            if (response1.IsSuccessStatusCode)
            {
                var result1 = response1.Content.ReadAsStringAsync().Result;
                var s1 = Newtonsoft.Json.JsonConvert.DeserializeObject(result1);

                ViewBag.result2 = result1.ToString().Replace("&quot;", " ");
                //ViewBag.result = response.Content;

            }
            else
            {
                ViewBag.result2 = "erreur";
            }
            //roleByaddress
            System.Net.Http.HttpClient Client2 = new HttpClient();

            Client2.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client2.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response2 = Client2.GetAsync("Map-JavaEE-web/MAP/StatAdmin/CountPersonByRegion/client").Result;
            if (response2.IsSuccessStatusCode)
            {
                var result2 = response2.Content.ReadAsStringAsync().Result;
                var s2 = Newtonsoft.Json.JsonConvert.DeserializeObject(result2);

                ViewBag.result3 = result2.ToString().Replace("&quot;", " ");
                //ViewBag.result = response.Content;

            }
            else
            {
                ViewBag.result3 = "erreur";
            }
            //Nb Project ended
            System.Net.Http.HttpClient Client3 = new HttpClient();

            Client3.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client3.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response3 = Client3.GetAsync("Map-JavaEE-web/MAP/StatAdmin/CountNbProjectEnded").Result;
            if (response3.IsSuccessStatusCode)
            {
                var result3 = response3.Content.ReadAsStringAsync().Result;
                var s3 = Newtonsoft.Json.JsonConvert.DeserializeObject(result3);

                ViewBag.result4 = result3.ToString().Replace("&quot;", " ");
                //ViewBag.result = response.Content;

            }
            else
            {
                ViewBag.result4 = "erreur";
            }
            HttpResponseMessage response4 = Client3.GetAsync("Map-JavaEE-web/MAP/StatAdmin/CountNbProjectNotEnded").Result;
            if (response4.IsSuccessStatusCode)
            {
                var result4 = response4.Content.ReadAsStringAsync().Result;
                var s4 = Newtonsoft.Json.JsonConvert.DeserializeObject(result4);

                ViewBag.result5 = result4.ToString().Replace("&quot;", " ");
                //ViewBag.result = response.Content;

            }
            else
            {
                ViewBag.result5 = "erreur";
            }
            return View();
        }
        public ActionResult Rh()
        {
            return View();
        }

        public ActionResult Client()
        {
            return View();
        }
        public ActionResult Project()
        {
            return View();
        }

    }
}