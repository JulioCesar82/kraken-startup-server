using System.Threading.Tasks;
using KrakenStartup.Web.Controllers;
using Shouldly;
using Xunit;

namespace KrakenStartup.Web.Tests.Controllers
{
    public class HomeController_Tests: KrakenStartupWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
