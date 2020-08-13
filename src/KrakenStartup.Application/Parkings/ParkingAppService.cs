using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;

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
        }

        public ListResultDto<ParkingDto> GetParkingListByPerimeter(ParkingCoordinatesInput coordinatesInput)
        {
            //Get entities
            var parkingEntityList = _parkingRepository.GetAllList();

            // TODO: Aplicar filtro por distancia

            //Convert to DTOs
            var parkingDtoList = _objectMapper.Map<List<ParkingDto>>(parkingEntityList);

            return new ListResultDto<ParkingDto>(parkingDtoList);
        }
    }
}
