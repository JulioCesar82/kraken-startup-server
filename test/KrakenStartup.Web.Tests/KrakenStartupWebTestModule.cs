using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using KrakenStartup.Web.Startup;
namespace KrakenStartup.Web.Tests
{
    [DependsOn(
        typeof(KrakenStartupWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class KrakenStartupWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(KrakenStartupWebTestModule).GetAssembly());
        }
    }
}