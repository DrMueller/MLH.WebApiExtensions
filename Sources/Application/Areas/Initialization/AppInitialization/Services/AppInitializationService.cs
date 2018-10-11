using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.WebApiExtensions.Areas.Initialization.AppInitialization.Models;
using Mmu.Mlh.WebApiExtensions.Areas.Middlewares;
using NLog.Extensions.Logging;
using NLog.Web;

namespace Mmu.Mlh.WebApiExtensions.Areas.Initialization.AppInitialization.Services
{
    public static class AppInitializationService
    {
        public static void InitializeApplication(AppConfig appConfig)
        {
            Guard.ObjectNotNull(() => appConfig);

            InitializeMiddlewares(appConfig.ApplicationBuilder);
            InitializeCors(appConfig.ApplicationBuilder);
            InitializeNlog(appConfig.HostingEnvironment, appConfig.LoggerFactory);

            appConfig.ApplicationBuilder.UseAuthentication();
            appConfig.ApplicationBuilder.UseMvc();
        }

        private static void InitializeCors(IApplicationBuilder app)
        {
            app.UseCors("All");
        }

        private static void InitializeMiddlewares(IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }

        private static void InitializeNlog(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            env.ConfigureNLog("nlog.config");
        }
    }
}