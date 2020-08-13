using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace KrakenStartup.Parkings
{
    public class ParkingCoordinatesInput
    {
        [Required]
        [StringLength(3)]
        public string Lat { get; set; }

        [Required]
        [StringLength(3)]
        public string Long { get; set; }

        [Required]
        [Range(1, 20)]
        public int Limit { get; set; }
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
