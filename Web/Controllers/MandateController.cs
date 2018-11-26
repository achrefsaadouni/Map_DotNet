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
        private const string APP_URI = "http://localhost:8993";
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
            List<MandateViewModels> liste = new List<MandateViewModels>();
            var response = client.Execute<List<MandateViewModels>>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                liste.AddRange(response.Data);
                return View(liste);
            }
               
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
            List<SrequestModelViews> liste = new List<SrequestModelViews>();
            var response = client.Execute<List<SrequestModelViews>>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                liste.AddRange(response.Data);
                return View(liste);
            }
                
            else
                return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public bool AddMandate()
        {
            var client = new RestClient(BASE_URI);
            var request = new RestRequest(Method.POST);
            client.AddHandler("application/json", new JsonDeserializer());
            request.RequestFormat = DataFormat.Json;
            request.Resource = "mandate";
            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            SrequestModelViews input = null;
            try
            {
                input = JsonConvert.DeserializeObject<SrequestModelViews>(json);
                var obj = new
                {
                    requestId = input.id,
                    resourceId = input.suggessedResource.id

                };
                request.AddJsonBody(obj);
                request.AddHeader("Authorization", "Bearer " + Session["token"]);
                request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
                var response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception ex)
            {
                return false;
            }
     

        }

        public ActionResult MyMandate()
        {
            List<MandateViewModels> liste = new List<MandateViewModels>();
            if(Session.Count == 0)
                return RedirectToAction("Login", "Home");
            if (Session["role"].Equals("Resource") && Session["token"] != null)
            {
                if (ms.getByResource((int)Session["id"]).Capacity == 0)
                    return View(liste);
                else
                {
                    foreach (var i in ms.getByResource((int)Session["id"]))
                    {
                        MandateViewModels m = new MandateViewModels();
                        SResourceViewModels ress = new SResourceViewModels(i.person);
                        SprojectViewModels pro = new SprojectViewModels(i.project);
                        SResourceViewModels gps;
                        if (i.person1 != null)
                            gps = new SResourceViewModels(i.person1);
                        else
                            gps = new SResourceViewModels();
                        m.projet = pro;
                        m.ressource = ress;
                        m.gps = gps;
                        m.montant = (double)i.montant;
                        MandateId mi = new MandateId();
                        mi.dateDebut = i.dateDebut;
                        mi.dateFin = i.dateFin;
                        mi.projetId = i.projetId;
                        mi.ressourceId = i.ressourceId;
                        m.mandateId = mi;
                        liste.Add(m);

                    }
                    return View(liste);
                }
            }
            else if(Session["role"].Equals("Client") && Session["token"] != null)
            {
                if (ms.getByClient((int)Session["id"]).Capacity == 0)
                    return View(liste);
                else
                {
                    foreach (var i in ms.getByClient((int)Session["id"]))
                    {
                        MandateViewModels m = new MandateViewModels();
                        SResourceViewModels ress = new SResourceViewModels(i.person);
                        SprojectViewModels pro = new SprojectViewModels(i.project);
                        SResourceViewModels gps;
                        if (i.person1 != null)
                         gps = new SResourceViewModels(i.person1);
                        else
                         gps = new SResourceViewModels();
                        m.projet = pro;
                        m.ressource = ress;
                        m.gps = gps;
                        m.montant = (double)i.montant;
                        MandateId mi = new MandateId();
                        mi.dateDebut = i.dateDebut;
                        mi.dateFin = i.dateFin;
                        mi.projetId = i.projetId;
                        mi.ressourceId = i.ressourceId;
                        m.mandateId = mi;
                        liste.Add(m);

                    }
                    return View(liste);
                }
            }
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
            List<MandateViewModels> liste = new List<MandateViewModels>();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                liste.AddRange(response.Data);
                return View(liste);
            } 
            else if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return View(liste);
            }
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

        public void cancelSuggestion(int id)
        {
        if (Session["role"].Equals("Client") && Session["token"] != null)
            {
                ms.cancelSuggesion(id);
            }

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
            List<SrequestModelViews> liste = new List<SrequestModelViews>();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                liste.AddRange(response.Data);
                return View(liste);
            }

            else
                return RedirectToAction("Login", "Home");
        }


        public new ActionResult ValidateRequest(int id)
        {
            if (Session.Count == 0)
                return RedirectToAction("Login", "Home");
            request r = ms.getRequestSortedByProjectSkills(id);
            SrequestModelViews model = new SrequestModelViews();
            SprojectViewModels p = new SprojectViewModels(r.project);
            SResourceViewModels ress = new SResourceViewModels(r.suggesedResource);
            model.id = r.id;
            model.requestedProfil = r.requestedProfil;
            model.experienceYear = r.experienceYear;
            model.traiter = r.traiter;
            model.startDateMondate = r.startDateMondate;
            model.endDateMondate = r.endDateMondate;
            model.depositDate = r.depositDate;
            model.traiter = r.traiter;
            model.project = p;
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

        public void SummonResource(int id , String date)
        {

            var client = new RestClient(BASE_URI);
            var request = new RestRequest(Method.POST);
            client.AddHandler("application/json", new JsonDeserializer());
            request.RequestFormat = DataFormat.Json;
            request.Resource = "mandate/Summon";
            var obj = new
            {
                requestId = id,
                date = date,
                link = "",
                email = ms.getResourceMail(id)

            };
            request.AddJsonBody(obj);
            request.AddHeader("Authorization", "Bearer " + Session["token"]);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ms.traitRequest(id);
            }
        }


        public ActionResult AllGPS()
        {
            if (Session.Count == 0)
                return RedirectToAction("Login", "Home");
            if (Session["token"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
        
            List<SResourceViewModels> liste = new List<SResourceViewModels>();
            foreach(person i in ms.getGps())
            {
                SResourceViewModels r = new SResourceViewModels(i);
                liste.Add(r);

            }

            return View(liste);
        }
        public void  currentMandate(string dateDebut,string dateFin,int projectId , int resourceId)
        {
            Session["dateDebut"] = dateDebut;
            Session["dateFin"] = dateFin;
            Session["projectId"] = projectId;
            Session["resourceId"] = resourceId;
        }
        public ActionResult AddGPS(int id)
        {
            if (Session.Count == 0)
                return RedirectToAction("Login", "Home");
            if (Session["token"] != null)
            {
                DateTime dateFin = DateTime.ParseExact((string)Session["dateFin"], "dd/MM/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
                DateTime dateDebut = DateTime.ParseExact((string)Session["dateDebut"], "dd/MM/yyyy",
                                           System.Globalization.CultureInfo.InvariantCulture);
                ms.addGps(id, (int)Session["projectId"], (int)Session["resourceId"], dateFin, dateDebut);
            }
            return RedirectToAction("Index", "Mandate");
            
        }
        

        public ActionResult DeleteGps(int id, string dateDebut, string dateFin, int projectId, int resourceId)
        {
            if (Session.Count == 0)
                return RedirectToAction("Login", "Home");
            if (Session["token"] != null)
            {
                DateTime dFin = DateTime.ParseExact(dateFin, "dd/MM/yyyy",
                                     System.Globalization.CultureInfo.InvariantCulture);
                DateTime dDebut = DateTime.ParseExact(dateDebut, "dd/MM/yyyy",
                                           System.Globalization.CultureInfo.InvariantCulture);
                ms.removeGps(id, projectId, resourceId, dFin, dDebut);
            }
            return RedirectToAction("Index", "Mandate");
           
          
        }


        public ActionResult resourceMandate()
        {
            var client = new RestClient(BASE_URI);
            var request = new RestRequest("mandate?ressourceId=" + Session["role"]);
            request.Method = Method.GET;
            request.AddHeader("Authorization", "Bearer " + Session["token"]);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            List<MandateViewModels> liste = new List<MandateViewModels>();
            var response = client.Execute<List<MandateViewModels>>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                liste.AddRange(response.Data);
                return View(liste);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        public ActionResult map()
        {
            if (Session.Count == 0)
                return RedirectToAction("Login", "Home");
            if (Session["token"] != null && Session["role"].Equals("Admin"))
            {
                List<SprojectViewModels> projet = new List<SprojectViewModels>();
                foreach (var item in ms.listeprojectwithMondate())
                {
                    SprojectViewModels p = new SprojectViewModels(item);
                    projet.Add(p);
                }
                return View(projet);
            }
            else
                return RedirectToAction("Login", "Home");
        }


        public JsonResult MapContent()
        {
            var client = new RestClient(BASE_URI);
            var request = new RestRequest("mandate");
            request.Method = Method.GET;
            request.AddHeader("Authorization", "Bearer " + Session["token"]);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            List<MandateViewModels> mandates = new List<MandateViewModels>();
            var response = client.Execute<List<MandateViewModels>>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                mandates.AddRange(response.Data);

            }
            var man = from name in mandates
                      orderby name.mandateId.projetId
                      select name;
            List<mapContentViewModels> liste = new List<mapContentViewModels>();
            int i = 0;
            foreach (var item in man)
            {
      
                if (liste.Count == 0)
                {
                    mapContentViewModels k = new mapContentViewModels();
                    k.projet = item.projet;
                    k.resources.Add(item.ressource);
                    liste.Add(k);
                    i++;
                }
                else
                {
                    if (liste.ElementAt(i-1).projet.idProject == item.mandateId.projetId)
                    {
                        liste.ElementAt(i-1).resources.Add(item.ressource);
                    }
                    else
                    {
                        mapContentViewModels k = new mapContentViewModels();
                        k.projet = item.projet;
                        k.resources.Add(item.ressource);
                        liste.Add(k);
                        i++;
                    }
                }
            }
            return   new JsonResult { Data = liste, JsonRequestBehavior = JsonRequestBehavior.AllowGet }; ;

        }
            
    }

        
}