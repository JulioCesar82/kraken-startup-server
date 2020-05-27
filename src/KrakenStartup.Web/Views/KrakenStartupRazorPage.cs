using Abp.AspNetCore.Mvc.Views;

namespace KrakenStartup.Web.Views
{
    public abstract class KrakenStartupRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected KrakenStartupRazorPage()
        {
            LocalizationSourceName = KrakenStartupConsts.LocalizationSourceName;
        }
    }
}
