using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SClientViewModels
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string clientType { get; set; }

        public string clientCategory { get; set; }
        public string  nameSociety { get; set; }
        public string  logo { get; set; }
        public string address { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }

        public SClientViewModels(person p)
        {
            id = p.id;
            firstName = p.firstName;
            lastName = p.lastName;
            email = p.email;
            clientType = p.clientType;

            clientCategory = p.clientCategory;
            nameSociety = p.nameSociety;
            logo = p.logo;
            address = p.address;
            longitude = (double)p.longitude;
            latitude = (double)p.latitude;
    }
        public SClientViewModels()
        {

        }
}
}