using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WebApiExtensions.Areas.Web.Initialization.AppInitialization.Models
{
    public class AppConfig
    {
        public AppConfig(
            IApplicationBuilder applicationBuilder,
            IHostingEnvironment hostingEnvironment,
            ILoggerFactory loggerFactory)
        {
            Guard.ObjectNotNull(() => applicationBuilder);
            Guard.ObjectNotNull(() => hostingEnvironment);
            Guard.ObjectNotNull(() => loggerFactory);

            ApplicationBuilder = applicationBuilder;
            HostingEnvironment = hostingEnvironment;
            LoggerFactory = loggerFactory;
        }

        public IApplicationBuilder ApplicationBuilder { get; }
        public IHostingEnvironment HostingEnvironment { get; }
        public ILoggerFactory LoggerFactory { get; }
    }
}