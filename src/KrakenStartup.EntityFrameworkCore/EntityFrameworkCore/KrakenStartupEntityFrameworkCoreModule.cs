using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace KrakenStartup.EntityFrameworkCore
{
    [DependsOn(
        typeof(KrakenStartupCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class KrakenStartupEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(KrakenStartupEntityFrameworkCoreModule).GetAssembly());
        }
    }
}