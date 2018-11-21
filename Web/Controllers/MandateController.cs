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
using Service;
using RestSharp.Deserializers;
using Newtonsoft.Json;
using System.IO;
using Service.Services;
using Service.Interfaces;

namespace Web.Controllers
{
    public class MandateController : Controller
    {

        private const string BASE_URI = "http://localhost:18080/Map-JavaEE-web/MAP/";
        private IMandateService ms = new MandateService();
        private IRequestService rm = new RequestService();
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

        public ActionResult AllRequest()
        {
            var client = new RestClient(BASE_URI);
            var request = new RestRequest("mandate/request");
            request.Method = Method.GET;
            request.AddHeader("Authorization", "Bearer " + Session["token"]);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = client.Execute<List<SrequestModelViews>>(request);
            if (response.StatusCode == HttpStatusCode.OK)
                return View(response.Data);
            else
                return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public string AddMandate()
        {
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
            var request = new RestRequest("mandate?ressourceId=" + id);
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
            var request = new RestRequest("mandate?clientId=" + id);
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
        public ActionResult HandleRequest(int id)
        {
            var client = new RestClient(BASE_URI);
            var request = new RestRequest(Method.POST);
            client.AddHandler("application/json", new JsonDeserializer());
            request.RequestFormat = DataFormat.Json;
            request.Resource = "mandate/suggestion";
            var obj = new
            {
                requestId = id
            };
            request.AddJsonBody(obj);
            request.AddHeader("Authorization", "Bearer " + Session["token"]);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = client.Execute<SuggestionViewModels>(request);
            if (response.StatusCode == HttpStatusCode.OK && response.Data != null)
            {

                ViewData["content"] = trie(response.Data);
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpPost]
        public string addSuggestion()
        {
            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            SuggestionViewModels input = null;
            try
            {
                input = JsonConvert.DeserializeObject<SuggestionViewModels>(json);
            }

            catch (Exception ex)
            {
                return "error";
            }
            person p = new person();
            p.id = input.resources[0].id;
            request r = new request();
            r.id = input.request.id;
            ms.addSuggestion(r, p);
            return "success";
        }
        public ActionResult MyRequest()
        {
            var client = new RestClient(BASE_URI);
            string s = "mandate/request?id="+Session["id"];
            var request = new RestRequest(s);
            request.Method = Method.GET;
            request.AddHeader("Authorization", "Bearer " + Session["token"]);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = client.Execute<List<SrequestModelViews>>(request);
            if (response.StatusCode == HttpStatusCode.OK)
                return View(response.Data);
            else
                return RedirectToAction("Login", "Home");
        }


        public new ActionResult ValidateRequest(int id)
        {
            request r = ms.getRequestSortedByProjectSkills(id);
            SrequestModelViews model = new SrequestModelViews();
            SprojectViewModels p = new SprojectViewModels();
            SResourceViewModels ress = new SResourceViewModels();
            model.id = r.id;
            p.projectName = r.project.projectName;
            p.projectSkills.AddRange(r.project.projectskills);
            model.project = p;
            model.requestedProfil = r.requestedProfil;
            model.experienceYear = r.experienceYear;
            model.traiter = r.traiter;
            model.startDateMondate = r.startDateMondate;
            model.endDateMondate = r.endDateMondate;
            model.depositDate = r.depositDate;


            ress.firstName = r.suggesedResource.firstName;
            ress.lastName = r.suggesedResource.lastName;
            ress.id = r.suggesedResource.id;
            ress.resourceSkills = new List<resourceskill>();
            ress.resourceSkills.AddRange(r.suggesedResource.resourceskills);
            ress.seniority = r.suggesedResource.seniority;
            ress.workProfil = r.suggesedResource.workProfil;
            ress.jobType = r.suggesedResource.jobType;

            model.suggessedResource = ress;
            ViewData["content"] = model;
            if (Session["token"] != null)
            {
                return View(model);
            }
            return RedirectToAction("Login", "Home");
            
        }


        public SuggestionViewModels trie(SuggestionViewModels s)
        {
            SuggestionViewModels cont = s;
            var r1 = from name in s.request.project.projectSkills
                     orderby name.percentage descending
                     select name;
            cont.request.project.projectSkills = new List<projectskill>();
            cont.request.project.projectSkills.AddRange(r1);
                cont.resources.ForEach(e =>
                {
                    var x = e.resourceSkills.OrderByDescending(w => w.rateSkill).ToList();
                    e.resourceSkills.Clear();
                    e.resourceSkills.AddRange(x);
                });

            return cont;
        }
    }

        
}