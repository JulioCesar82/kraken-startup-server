using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Json;
using Abp.Reflection.Extensions;

namespace KrakenStartup.Localization
{
    public static class KrakenStartupLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flags um"));
            localizationConfiguration.Languages.Add(new LanguageInfo("pt-BR", "Português", "famfamfam-flags br", isDefault: true));

            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(KrakenStartupConsts.LocalizationSourceName,
                    new JsonEmbeddedFileLocalizationDictionaryProvider(
                        typeof(KrakenStartupLocalizationConfigurer).GetAssembly(),
                        "KrakenStartup.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}