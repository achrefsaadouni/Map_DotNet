using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Web.Models;
using System.Net.Http.Headers;
using System.Net;
using RestSharp;
using Domain;
using RestSharp.Deserializers;

namespace Web.Controllers
{
    public class MandateController : Controller
    {
        
        private const string BASE_URI = "http://localhost:18080/Map-JavaEE-web/MAP/";
        // GET: Mandate
        public ActionResult Index()
        {
          
            var client = new RestClient(BASE_URI);
            var request = new RestRequest("mandate");
            request.Method = Method.GET;
            request.AddHeader("Authorization", "Bearer " + Session["token"]);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = client.Execute<List<MandateViewModels>>(request);
            if (response.StatusCode == HttpStatusCode.OK)
                return View(response.Data);
            else
                return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public string AddMandate() {
            var client = new RestClient(BASE_URI);
            var request = new RestRequest(Method.POST);
            client.AddHandler("application/json", new JsonDeserializer());
            request.RequestFormat = DataFormat.Json;
            request.Resource = "mandate";
            var obj = new
            {
                requestId = HttpContext.Request.Form.Get("requestId"),
                resourceId = HttpContext.Request.Form.Get("resourceId")

            };
            request.AddJsonBody(obj);
            request.AddHeader("Authorization", "Bearer " + Session["token"]);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return "Add Mandate With success";
            }
            else
            {
                return "Error";
            }

        }

        public ActionResult MyMandate(int id)
        {
            var client = new RestClient(BASE_URI);
            var request = new RestRequest("mandate?ressourceId="+id);
            request.Method = Method.GET;
            request.AddHeader("Authorization", "Bearer " + Session["token"]);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = client.Execute<MandateViewModels>(request);
            if (response.StatusCode == HttpStatusCode.OK)
                return View(response.Data);
            else
            {
                return RedirectToAction("Login", "Home");

            }
                
        }

        public ActionResult ClientMandates(int id)
        {
            var client = new RestClient(BASE_URI);
            var request = new RestRequest("mandate?clientId="+id);
            request.Method = Method.GET;
            request.AddHeader("Authorization", "Bearer " + Session["token"]);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = client.Execute<List<MandateViewModels>>(request);
            if (response.StatusCode == HttpStatusCode.OK)
                return View(response.Data);
            else
                return RedirectToAction("Login", "Home");
        }
        public ActionResult ProjectMandates(int id)
        {
            var client = new RestClient(BASE_URI);
            var request = new RestRequest("mandate?projetId=" + id);
            request.Method = Method.GET;
            request.AddHeader("Authorization", "Bearer " + Session["token"]);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = client.Execute<List<MandateViewModels>>(request);
            if (response.StatusCode == HttpStatusCode.OK)
                return View(response.Data);
            else
                return RedirectToAction("Login", "Home");
        }

        public ActionResult Archived()
        {

            var client = new RestClient(BASE_URI);
            var request = new RestRequest("mandate?archive=show");
            request.Method = Method.GET;
            request.AddHeader("Authorization", "Bearer " + Session["token"]);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = client.Execute<List<MandateViewModels>>(request);
            if (response.StatusCode == HttpStatusCode.OK)
                return View(response.Data);
            else if (response.StatusCode == HttpStatusCode.NoContent)
                return RedirectToAction("Index", "Home");
            else
                return RedirectToAction("Login", "Home");
        }

    }
}