using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using KrakenStartup.AddressDocumentations;
using Microsoft.EntityFrameworkCore;
using Castle.Core.Logging;
using KrakenStartup.ThirdParty.HereMap;

namespace KrakenStartup.Parkings
{
    public class ParkingAppService : AsyncCrudAppService<Parking, ParkingDto>, IParkingAppService
    {
        private readonly IRepository<Parking> _parkingRepository;
        private readonly IObjectMapper _objectMapper;
        public ILogger Logger { get; set; }

        public ParkingAppService(IRepository<Parking> parkingRepository, IObjectMapper objectMapper) 
            : base(parkingRepository)
        {
            _parkingRepository = parkingRepository;
            _objectMapper = objectMapper;
            Logger = NullLogger.Instance;

            LocalizationSourceName = "Parking";
        }

        public async Task<ListResultDto<SearchParkingOutput>> GetParkingListByPerimeter(SearchParkingInput input)
        {
            Logger.Info("GetParkingListByPerimeter");

            var entity = _parkingRepository.GetAll()
                .Include(x => x.AddressDocumentation);

            //Get entities
            var parkingEntityList = await entity
                .Where(x => WherePredicate(
                    x.AddressDocumentation, 
                    input.Latitude, 
                    input.Longitude,
                    input.MaxDistance))
                .Take(input.MaxResultCount)
                .OrderBy(x => GetDistance(
                    x.AddressDocumentation,
                    input.Latitude,
                    input.Longitude))
                .ToListAsync();

            if (parkingEntityList.Count == 0)
            {
                return new ListResultDto<SearchParkingOutput>();
            }

            var addressLocalizationList = parkingEntityList.Select(x => new HereAddressLocalization {
                    Latitude = x.AddressDocumentation.Latitude,
                    Longitude = x.AddressDocumentation.Longitude
                })
                .ToList();

            var addressDistanceList = await HereMapService.GetDistanceByHereApi(input.Latitude, input.Longitude, addressLocalizationList);

            //Convert to DTOs
            var parkingDtoList = _objectMapper.Map<List<SearchParkingOutput>>(parkingEntityList);

            for (int i = 0; i < parkingDtoList.Count; i++)
            {
                var addressDetails = addressDistanceList.First(x => x.StartIndex == i);
                parkingDtoList[i].Distance = addressDetails.Summary.Distance;
                parkingDtoList[i].TravelTime = addressDetails.Summary.TravelTime;
                parkingDtoList[i].CostFactor = addressDetails.Summary.CostFactor;
            }

            return new ListResultDto<SearchParkingOutput>(parkingDtoList);
        }

        private static bool WherePredicate(AddressDocumentation o, double latitude, double longitude, double maxDistance)
        {
            var distance = GetDistance(o, latitude, longitude);

            return
                distance <= maxDistance;
        }

        private static double GetDistance(AddressDocumentation o, double latitude, double longitude)
        {
            // KM or ML
            // Kilometers 6378.137
            // Miles 3963.191
            var radius = 6378.137;

            var distance = radius * Math.Acos(Math.Cos(ConvertToRadians(latitude)) *
                                              Math.Cos(ConvertToRadians(o.Latitude)) *
                                              Math.Cos(ConvertToRadians(o.Longitude) - ConvertToRadians(longitude)) +
                                              Math.Sin(ConvertToRadians(latitude) *
                                                       Math.Sin(ConvertToRadians(o.Latitude))));
            return distance;
        }

        public static double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }
    }
}
