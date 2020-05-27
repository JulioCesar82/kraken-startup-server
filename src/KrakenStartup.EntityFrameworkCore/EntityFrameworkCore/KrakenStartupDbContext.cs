using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KrakenStartup.EntityFrameworkCore
{
    public class KrakenStartupDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public KrakenStartupDbContext(DbContextOptions<KrakenStartupDbContext> options) 
            : base(options)
        {

        }
    }
}
