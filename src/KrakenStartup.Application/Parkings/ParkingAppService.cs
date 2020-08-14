using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using KrakenStartup.AddressDocumentations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

        public async Task<ListResultDto<SearchParkingOutput>> GetParkingListByPerimeter(SearchParkingInput input)
        {
            var entity = _parkingRepository
                .GetAll()
                .Include(x => x.AddressDocumentation);

            //Get entities
            var parkingEntityList = entity
                .Where(x => GetDistance(
                    x.AddressDocumentation, 
                    input.Latitude, 
                    input.Longitude) < input.MaxDistance)
                .Take(input.MaxResultCount)
                .OrderBy(x => GetDistance(
                    x.AddressDocumentation,
                    input.Latitude,
                    input.Longitude))
                .ToListAsync();

            // TODO: Chamar API da HERE passando todos os enderecos e o ponto de destino (input)
            var test = await GetDistanceByHereApi(input.Latitude, input.Longitude);

            //Convert to DTOs
            var parkingDtoList = _objectMapper.Map<List<SearchParkingOutput>>(parkingEntityList);

            return new ListResultDto<SearchParkingOutput>(parkingDtoList);
        }

        private async Task<List<MatrixEntry>> GetDistanceByHereApi(double latitude, double longitude)
        {
            const string hereApiKey = "Gwecv9sAyqQimIdyQoM7AM8kGU21hk02I_hA5-_KKnU";

            using (var client = new HttpClient())
            {
                var url = new Uri($"https://matrix.route.ls.hereapi.com/routing/7.2/calculatematrix.json?" +
                    "apiKey={hereApiKey}" +
                    "&mode=fastest" +
                    "&destination0={latitude},{longitude}" +
                    "&start0=-23.469437,-46.533096" +
                    "&start1=-23.469709,-46.532565");

                var response = await client.GetAsync(url);

                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }

                var routingResponse = JsonConvert.DeserializeObject<HereRoutingResponse>(json);

                return routingResponse.response.matrixEntry;
            }
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
