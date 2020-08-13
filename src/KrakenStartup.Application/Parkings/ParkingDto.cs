using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace KrakenStartup.Parkings
{
    public class SearchParkingInput : ILimitedResultRequest
    {
        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Range(1, 50)]
        public double MaxDistance { get; set; }

        [Required]
        [Range(1, 20)]
        public int MaxResultCount { get; set; }
    }

    [AutoMapTo(typeof(Parking))]
    public class ParkingDto : EntityDto
    {
        public string NickName { get; set; }

        public string Description { get; set; }

        public decimal AmountMoney { get; set; }

        public int AddressDocumentId { get; set; }
    }
}
