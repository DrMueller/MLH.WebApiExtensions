using Microsoft.Extensions.Options;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Models;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services;
using Mmu.Mlh.WebApiExtensions.Areas.App.Settings.Models;
using Mmu.Mlh.WebApiExtensions.Areas.App.Settings.Services;
using Mmu.Mlh.WebApiExtensions.TestApi.Infrastructure.Settings.Models;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Infrastructure.Settings.Services
{
    public class WebSettingsProvider : ISecuritySettingsProvider, IDatabaseSettingsProvider
    {
        private readonly IOptions<WebSettings> _webSettingsOptions;

        public WebSettingsProvider(IOptions<WebSettings> webSettingsOptions)
        {
            _webSettingsOptions = webSettingsOptions;
        }

        public DatabaseSettings ProvideDatabaseSettings()
        {
            return _webSettingsOptions.Value.DatabaseSettings;
        }

        public SecuritySettings ProvideSecuritySettings()
        {
            return _webSettingsOptions.Value.SecuritySettings;
        }
    }
}