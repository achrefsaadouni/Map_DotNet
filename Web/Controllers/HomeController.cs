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
            if (Session.Count == 0)
                return RedirectToAction("Login", "Home");
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

        public ActionResult Logout()
        {
            Session.Contents.RemoveAll();
            return RedirectToAction("Login", "Home");
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
            var response = client.Execute<ConnectedUser>(request);
            if(response.StatusCode == HttpStatusCode.OK)
            {
                Session["token"] = response.Data.token;
                Session["id"] = response.Data.id;
                Session["firstName"] = response.Data.firstName;
                Session["lastName"] = response.Data.lastName;
                Session["role"] = response.Data.role;
                Session["email"] = response.Data.email;
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