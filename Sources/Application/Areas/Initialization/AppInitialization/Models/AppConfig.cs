using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WebApiExtensions.Areas.Initialization.AppInitialization.Models
{
    public class AppConfig
    {
        public IApplicationBuilder ApplicationBuilder { get; }
        public IHostingEnvironment HostingEnvironment { get; }
        public ILoggerFactory LoggerFactory { get; }
        public SwaggerAppConfig SwaggerAppConfig { get; }

        public AppConfig(
            IApplicationBuilder applicationBuilder,
            IHostingEnvironment hostingEnvironment,
            ILoggerFactory loggerFactory,
            SwaggerAppConfig swaggerAppConfig)
        {
            Guard.ObjectNotNull(() => applicationBuilder);
            Guard.ObjectNotNull(() => hostingEnvironment);
            Guard.ObjectNotNull(() => loggerFactory);
            Guard.ObjectNotNull(() => swaggerAppConfig);

            ApplicationBuilder = applicationBuilder;
            HostingEnvironment = hostingEnvironment;
            LoggerFactory = loggerFactory;
            SwaggerAppConfig = swaggerAppConfig;
        }
    }
}