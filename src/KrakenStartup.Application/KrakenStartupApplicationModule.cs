using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace KrakenStartup
{
    [DependsOn(
        typeof(KrakenStartupCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class KrakenStartupApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(KrakenStartupApplicationModule).GetAssembly());
        }
    }
}