using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using KrakenStartup.AddressDocumentations;
using Microsoft.EntityFrameworkCore;

namespace KrakenStartup.Parkings
{
    public class ParkingAppService : AsyncCrudAppService<Parking, ParkingDto>, IParkingAppService
    {
        private readonly IRepository<Parking> _parkingRepository;
        private readonly IObjectMapper _objectMapper;

        public ParkingAppService(IRepository<Parking> parkingRepository, IObjectMapper objectMapper) 
            : base(parkingRepository)
        {
            _parkingRepository = parkingRepository;
            _objectMapper = objectMapper;

            LocalizationSourceName = "Parking";
        }

        public ListResultDto<ParkingDto> GetParkingListByPerimeter(SearchParkingInput input)
        {
            var entity = _parkingRepository
                .GetAll()
                .Include(x => x.AddressDocumentation);

            //Get entities
            var parkingEntityList = entity
                .Where(x => GetDistance(
                    x.AddressDocumentation, 
                    input.Latitude, 
                    input.Longitude) > input.MaxDistance)
                .ToListAsync();

            // TODO: Chamar API da HERE passando todos os enderecos e o ponto de destino (input)


            //Convert to DTOs
            var parkingDtoList = _objectMapper.Map<List<ParkingDto>>(parkingEntityList);

            return new ListResultDto<ParkingDto>(parkingDtoList);
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
