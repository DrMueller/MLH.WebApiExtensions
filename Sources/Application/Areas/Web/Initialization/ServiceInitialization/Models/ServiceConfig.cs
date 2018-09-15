using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WebApiExtensions.Areas.Web.Initialization.ServiceInitialization.Models
{
    public class ServiceConfig
    {
        public ServiceConfig(IServiceCollection services, IConfiguration configuration, Assembly baseAssembly, string appSettingsSectionKey = "AppSettings")
        {
            Guard.ObjectNotNull(() => services);
            Guard.ObjectNotNull(() => configuration);
            Guard.ObjectNotNull(() => baseAssembly);
            Guard.StringNotNullOrEmpty(() => appSettingsSectionKey);

            Services = services;
            Configuration = configuration;
            BaseAssembly = baseAssembly;
            AppSettingsSectionKey = appSettingsSectionKey;
        }

        public string AppSettingsSectionKey { get; }
        public Assembly BaseAssembly { get; }
        public IConfiguration Configuration { get; }
        public IServiceCollection Services { get; }
    }
}