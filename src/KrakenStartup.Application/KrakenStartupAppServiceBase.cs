using Abp.Application.Services;

namespace KrakenStartup
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class KrakenStartupAppServiceBase : ApplicationService
    {
        protected KrakenStartupAppServiceBase()
        {
            LocalizationSourceName = KrakenStartupConsts.LocalizationSourceName;
        }
    }
}