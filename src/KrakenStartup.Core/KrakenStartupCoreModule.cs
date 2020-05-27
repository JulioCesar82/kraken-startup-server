using Abp.Modules;
using Abp.Reflection.Extensions;
using KrakenStartup.Localization;

namespace KrakenStartup
{
    public class KrakenStartupCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            KrakenStartupLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(KrakenStartupCoreModule).GetAssembly());
        }
    }
}