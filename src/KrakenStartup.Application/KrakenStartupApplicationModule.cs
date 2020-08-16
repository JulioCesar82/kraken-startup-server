using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using KrakenStartup.AddressDocumentations;
using KrakenStartup.Parkings;
using KrakenStartup.UsersWallets;

namespace KrakenStartup
{
    [DependsOn(
        typeof(KrakenStartupCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class KrakenStartupApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<ParkingDto, Parking>();
                config.CreateMap<Parking, ParkingDto>();

                config.CreateMap<AddressDocumentationDto, AddressDocumentation>();
                config.CreateMap<AddressDocumentation, AddressDocumentationDto>();

                config.CreateMap<UserWalletDto, UserWallet>();
                config.CreateMap<UserWallet, UserWalletDto>();
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(KrakenStartupApplicationModule).GetAssembly());
        }
    }
}