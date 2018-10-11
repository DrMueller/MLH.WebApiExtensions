using Microsoft.Extensions.DependencyInjection;
using Mmu.Mlh.WebApiExtensions.Areas.Initialization.ServiceInitialization.Models;

namespace Mmu.Mlh.WebApiExtensions.Areas.Initialization.ServiceInitialization.Services.Servants.Implementation
{
    internal static class WebSettingsInitializationServant
    {
        internal static void InitializeWebSettings<TWebSettings>(ServiceConfig serviceConfig)
            where TWebSettings : class
        {
            var configSection = serviceConfig.Configuration.GetSection(serviceConfig.AppSettingsSectionKey);
            serviceConfig.Services.Configure<TWebSettings>(configSection);
            serviceConfig.Services.AddSingleton(serviceConfig.Configuration);
        }
    }
}