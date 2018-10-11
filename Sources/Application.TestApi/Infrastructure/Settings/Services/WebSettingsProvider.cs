using Microsoft.Extensions.Options;
using Mmu.Mlh.DataAccess.MongoDb.Infrastructure.Settings.Models;
using Mmu.Mlh.DataAccess.MongoDb.Infrastructure.Settings.Services;
using Mmu.Mlh.WebApiExtensions.Infrastructure.Settings.Models;
using Mmu.Mlh.WebApiExtensions.Infrastructure.Settings.Services;
using Mmu.Mlh.WebApiExtensions.TestApi.Infrastructure.Settings.Models;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Infrastructure.Settings.Services
{
    public class WebSettingsProvider : ISecuritySettingsProvider, IMongoDbSettingsProvider
    {
        private readonly IOptions<WebSettings> _webSettingsOptions;

        public WebSettingsProvider(IOptions<WebSettings> webSettingsOptions)
        {
            _webSettingsOptions = webSettingsOptions;
        }

        public MongoDbSettings ProvideMongoDbSettings()
        {
            return _webSettingsOptions.Value.MongoDbSettings;
        }

        public SecuritySettings ProvideSecuritySettings()
        {
            return _webSettingsOptions.Value.SecuritySettings;
        }
    }
}