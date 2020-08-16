using Microsoft.EntityFrameworkCore;

namespace KrakenStartup.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<KrakenStartupDbContext> dbContextOptions,
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for KrakenStartupDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
