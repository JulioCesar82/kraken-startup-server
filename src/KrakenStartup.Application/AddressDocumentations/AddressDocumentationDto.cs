using System;
using System.Collections.Generic;
using System.Text;

namespace KrakenStartup.AddressDocumentations
{
    public class AddressDocumentationDto
    {
        public string NickName { get; set; }

        public AddressDocumentationType Type { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string StreetName { get; set; }

        public string AddressNumber { get; set; }

        public string Complement { get; set; }

        public string CountryName { get; set; }

        public string CityName { get; set; }

        public string NeighborhoodName { get; set; }
    }
}
