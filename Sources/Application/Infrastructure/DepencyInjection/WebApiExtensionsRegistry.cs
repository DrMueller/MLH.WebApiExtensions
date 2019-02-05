using Microsoft.AspNetCore.Http;
using Mmu.Mlh.WebApiExtensions.Areas.ExceptionHandling.Services;
using Mmu.Mlh.WebApiExtensions.Areas.ExceptionHandling.Services.Implementation;
using Mmu.Mlh.WebApiExtensions.Areas.Initialization.ServiceInitialization.Services.Servants;
using Mmu.Mlh.WebApiExtensions.Areas.Initialization.ServiceInitialization.Services.Servants.Implementation;
using Mmu.Mlh.WebApiExtensions.Areas.Security.Authorization.ClaimProvisioning;
using Mmu.Mlh.WebApiExtensions.Areas.Security.Authorization.ClaimProvisioning.Implementation;
using StructureMap;

namespace Mmu.Mlh.WebApiExtensions.Infrastructure.DepencyInjection
{
    public class WebApiExtensionsRegistry : Registry
    {
        public WebApiExtensionsRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<WebApiExtensionsRegistry>();
                    scanner.WithDefaultConventions();
                });

            For<IHttpContextAccessor>().Use<HttpContextAccessor>().Singleton();
            For<IClaimProviderResolver>().Use<ClaimProviderResolver>();
            For<IAuthenticationInitializationService>().Use<AuthenticationInitializationService>();
            For<IAuthorizationInitializationService>().Use<AuthorizationInitializationService>();

            // Error-Handling
            For<IExceptionCallbackService>().Use<ExceptionCallbackService>().Singleton();
            For<IExceptionHandler>().Use<ExceptionHandler>().Singleton();
        }
    }
}