using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ILogger = Castle.Core.Logging.ILogger;

namespace KrakenStartup.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static ILogger Logger { get; set; }

        public static void Configure(
            DbContextOptionsBuilder<KrakenStartupDbContext> dbContextOptions,
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for KrakenStartupDbContext */

            dbContextOptions
                .UseLoggerFactory(GetDbLoggerFactory())
                .EnableSensitiveDataLogging()
                .UseSqlServer(connectionString);
        }

        private static LoggerFactory GetDbLoggerFactory()
        {
            return new LoggerFactory(new[] { new MyLoggerProvider(Logger) });
        }
    }
}
