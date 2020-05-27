using Abp.AspNetCore.Mvc.Controllers;

namespace KrakenStartup.Web.Controllers
{
    public abstract class KrakenStartupControllerBase: AbpController
    {
        protected KrakenStartupControllerBase()
        {
            LocalizationSourceName = KrakenStartupConsts.LocalizationSourceName;
        }
    }
}