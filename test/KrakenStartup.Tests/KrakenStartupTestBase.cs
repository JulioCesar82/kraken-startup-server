using System;
using System.Threading.Tasks;
using Abp.TestBase;
using KrakenStartup.EntityFrameworkCore;
using KrakenStartup.Tests.TestDatas;

namespace KrakenStartup.Tests
{
    public class KrakenStartupTestBase : AbpIntegratedTestBase<KrakenStartupTestModule>
    {
        public KrakenStartupTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<KrakenStartupDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<KrakenStartupDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<KrakenStartupDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<KrakenStartupDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<KrakenStartupDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<KrakenStartupDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<KrakenStartupDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<KrakenStartupDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
