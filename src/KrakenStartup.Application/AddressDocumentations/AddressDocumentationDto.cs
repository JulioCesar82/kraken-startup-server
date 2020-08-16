using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace KrakenStartup.AddressDocumentations
{
    [AutoMapTo(typeof(AddressDocumentation))]
    public class AddressDocumentationDto : EntityDto
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
