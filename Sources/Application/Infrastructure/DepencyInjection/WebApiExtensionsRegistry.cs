using Microsoft.AspNetCore.Http;
using Mmu.Mlh.WebApiExtensions.Areas.Web.Initialization.ServiceInitialization.Services.Servants;
using Mmu.Mlh.WebApiExtensions.Areas.Web.Initialization.ServiceInitialization.Services.Servants.Implementation;
using Mmu.Mlh.WebApiExtensions.Areas.Web.Security.Authorization.ClaimProvisioning;
using Mmu.Mlh.WebApiExtensions.Areas.Web.Security.Authorization.ClaimProvisioning.Implementation;
using Mmu.Mlh.WebApiExtensions.Areas.Web.Security.Authorization.PolicyProvisioning;
using Mmu.Mlh.WebApiExtensions.Areas.Web.Security.Authorization.PolicyProvisioning.Implementation;
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
            For<IPolicyProviderResolver>().Use<PolicyProviderResolver>();
            For<IClaimProviderResolver>().Use<ClaimProviderResolver>();
            For<IAuthenticationInitializationService>().Use<AuthenticationInitializationService>();
            For<IAuthorizationInitializationService>().Use<AuthorizationInitializationService>();
        }
    }
}