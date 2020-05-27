using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using KrakenStartup.Configuration;
using KrakenStartup.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace KrakenStartup.Web.Startup
{
    [DependsOn(
        typeof(KrakenStartupApplicationModule), 
        typeof(KrakenStartupEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class KrakenStartupWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public KrakenStartupWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(KrakenStartupConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<KrakenStartupNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(KrakenStartupApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(KrakenStartupWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(KrakenStartupWebModule).Assembly);
        }
    }
}