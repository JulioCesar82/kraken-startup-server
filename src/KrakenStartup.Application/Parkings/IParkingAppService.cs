using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace KrakenStartup.Parkings
{
    public interface IParkingAppService : IApplicationService
    {
        ListResultDto<ParkingDto> GetParkingListByPerimeter(ParkingCoordinatesInput coordinatesInput);
    }
}