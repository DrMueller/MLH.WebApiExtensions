using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Mlh.WebApiExtensions.Areas.Initialization.ServiceInitialization.Models
{
    public class ServiceConfig
    {
        public string AppSettingsSectionKey { get; }
        public Assembly BaseAssembly { get; }
        public IConfiguration Configuration { get; }
        public Maybe<Action<Exception>> ExceptionCallback { get; }
        public IServiceCollection Services { get; }

        public ServiceConfig(
            IServiceCollection services,
            IConfiguration configuration,
            Assembly baseAssembly,
            Maybe<Action<Exception>> exceptionCallback,
            string appSettingsSectionKey = "AppSettings")
        {
            Guard.ObjectNotNull(() => services);
            Guard.ObjectNotNull(() => configuration);
            Guard.ObjectNotNull(() => baseAssembly);
            Guard.ObjectNotNull(() => exceptionCallback);
            Guard.StringNotNullOrEmpty(() => appSettingsSectionKey);

            Services = services;
            Configuration = configuration;
            BaseAssembly = baseAssembly;
            ExceptionCallback = exceptionCallback;
            AppSettingsSectionKey = appSettingsSectionKey;
        }
    }
}