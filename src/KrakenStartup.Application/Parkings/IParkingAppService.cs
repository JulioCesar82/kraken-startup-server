using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace KrakenStartup.Parkings
{
    public interface IParkingAppService : IApplicationService
    {
        Task<ListResultDto<SearchParkingOutput>> GetParkingListByPerimeter(SearchParkingInput input);
    }
}