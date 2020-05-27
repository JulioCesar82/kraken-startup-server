using KrakenStartup.EntityFrameworkCore;

namespace KrakenStartup.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly KrakenStartupDbContext _context;

        public TestDataBuilder(KrakenStartupDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}