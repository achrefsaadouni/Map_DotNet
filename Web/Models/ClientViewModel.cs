using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ClientViewModel
    {
        public int id { get; set; }
        public int archived { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string candidateState { get; set; }
        public string address { get; set; }
        public string clientCategory { get; set; }
        public string clientType { get; set; }
        public string logo { get; set; }
        public string nameSociety { get; set; }
        public string picture { get; set; }
        public string roleT { get; set; }


    }
}