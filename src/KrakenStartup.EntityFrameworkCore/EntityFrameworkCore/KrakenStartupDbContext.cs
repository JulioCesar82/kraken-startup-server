using Abp.EntityFrameworkCore;
using KrakenStartup.AddressDocumentations;
using KrakenStartup.CarDocumentations;
using KrakenStartup.CreditCards;
using KrakenStartup.DriverDocumentations;
using KrakenStartup.Identifications;
using KrakenStartup.Parkings;
using KrakenStartup.ParkingSchedules;
using KrakenStartup.ParkingTransactions;
using KrakenStartup.RentParkings;
using KrakenStartup.UsersCreditCards;
using KrakenStartup.UsersProfile;
using KrakenStartup.UsersVouchers;
using KrakenStartup.UsersWallets;
using KrakenStartup.Vouchers;
using Microsoft.EntityFrameworkCore;

namespace KrakenStartup.EntityFrameworkCore
{
    public class KrakenStartupDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...
        public DbSet<AddressDocumentation> AddressDocumentationModel { get; set; }
        public DbSet<CarDocumentation> CarDocumentationModel { get; set; }
        public DbSet<CreditCard> CreditCardModel { get; set; }
        public DbSet<DriverDocumentation> DriverDocumentationModel { get; set; }
        public DbSet<Identification> IdentificationModel { get; set; }
        public DbSet<Parking> ParkingModel { get; set; }
        public DbSet<ParkingSchedule> ParkingScheduleModel { get; set; }
        public DbSet<ParkingTransaction> ParkingTransactionModel { get; set; }
        public DbSet<RentParking> RentParkingModel { get; set; }
        public DbSet<UserCreditCard> UserCreditCardModel { get; set; }
        public DbSet<UserProfile> UserProfileModel { get; set; }
        public DbSet<UserVoucher> UserVoucherModel { get; set; }
        public DbSet<UserWallet> UserWalletModel { get; set; }
        public DbSet<Voucher> VoucherModel { get; set; }
     
        public KrakenStartupDbContext(DbContextOptions<KrakenStartupDbContext> options) 
            : base(options)
        {

        }
    }
}
