using KrakenStartup.Configuration;
using KrakenStartup.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace KrakenStartup.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class KrakenStartupDbContextFactory : IDesignTimeDbContextFactory<KrakenStartupDbContext>
    {
        public KrakenStartupDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<KrakenStartupDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(KrakenStartupConsts.ConnectionStringName)
            );

            return new KrakenStartupDbContext(builder.Options);
        }
    }
}