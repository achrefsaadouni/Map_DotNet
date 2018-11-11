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
            request.AddHeader("Authorization", "Bearer " + "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJ2aW5nYXJkZUBvdXRsb29rLmZyIiwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDoxODA4MC9NYXAtSmF2YUVFLXdlYi9NQVAvYXV0aGVudGljYXRpb24iLCJpYXQiOjE1NDE5NTM0OTAsImV4cCI6MTU0MTk1NDM5MH0.PhkGAPRnFiLjP3Ua_VwB0G20aVqq_VniabIZULw_9EM-HSLlcPT2jRDum_57yy3oPrVif9Skqw34FmjwKiB-4w");
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = client.Execute<List<MandateViewModels>>(request);
            return View(response.Data);

        }
    }
}