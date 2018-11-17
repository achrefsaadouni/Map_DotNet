using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private const string BASE_URI = "http://localhost:18080/Map-JavaEE-web/MAP/";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(UserViewModels user)
        {
            var client = new RestClient(BASE_URI);
            var request = new RestRequest(Method.POST);
            client.AddHandler("application/json", new JsonDeserializer());
            request.RequestFormat = DataFormat.Json;
            request.Resource = "authentication";
            var obj = new
            {
                login = user.login,
                password = user.password

            };
            request.AddJsonBody(obj);
            client.AddDefaultHeader("accept", "*/*");
            var response = client.Execute(request);
            if(response.StatusCode == HttpStatusCode.OK)
            {
                Session["token"] = response.Content;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Content = "Bad Credentials";
                return View();
            }
        }
    }
}