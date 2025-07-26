using System.Collections.Concurrent;
using Abp.Extensions;
using Microsoft.Extensions.Configuration;

namespace KrakenStartup.Configuration
{
    /// <summary>
    /// Provides access to application configuration settings.
    /// </summary>
    public static class AppConfigurations
    {
        private static readonly ConcurrentDictionary<string, IConfigurationRoot> ConfigurationCache;

        static AppConfigurations()
        {
            ConfigurationCache = new ConcurrentDictionary<string, IConfigurationRoot>();
        }

        /// <summary>
        /// Gets the application configuration for a specified path and environment.
        /// </summary>
        /// <param name="path">The base path to the configuration files.</param>
        /// <param name="environmentName">The name of the environment (e.g., "Development", "Production").</param>
        /// <returns>The application configuration root.</returns>
        public static IConfigurationRoot Get(string path, string environmentName = null)
        {
            var cacheKey = path + "#" + environmentName;
            return ConfigurationCache.GetOrAdd(
                cacheKey,
                _ => BuildConfiguration(path, environmentName)
            );
        }

        /// <summary>
        /// Builds the application configuration from JSON files and environment variables.
        /// </summary>
        /// <param name="path">The base path to the configuration files.</param>
        /// <param name="environmentName">The name of the environment.</param>
        /// <returns>The built configuration root.</returns>
        private static IConfigurationRoot BuildConfiguration(string path, string environmentName = null)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            if (!environmentName.IsNullOrWhiteSpace())
            {
                builder = builder.AddJsonFile($"appsettings.{environmentName}.json", optional: true);
            }
            
            builder = builder.AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
