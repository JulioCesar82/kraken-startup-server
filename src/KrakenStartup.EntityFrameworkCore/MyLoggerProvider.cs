using Microsoft.Extensions.Logging;

namespace KrakenStartup
{
    public class MyLoggerProvider : ILoggerProvider
    {
        private readonly Castle.Core.Logging.ILogger _logger;

        public MyLoggerProvider(Castle.Core.Logging.ILogger logger)
        {
            _logger = logger;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new MyLogger(_logger);
        }
        public void Dispose()
        {
        }
    }
}
