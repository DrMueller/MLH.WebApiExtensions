using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Mlh.WebApiExtensions.Areas.Web.Security.Authorization.PolicyProvisioning;

namespace Mmu.Mlh.WebApiExtensions.Areas.Web.Initialization.ServiceInitialization.Services.Servants.Implementation
{
    internal class AuthorizationInitializationService : IAuthorizationInitializationService
    {
        private readonly IPolicyProviderResolver _policyProviderResolver;

        public AuthorizationInitializationService(IPolicyProviderResolver policyProviderResolver)
        {
            _policyProviderResolver = policyProviderResolver;
        }

        public async Task InitializeAsync(IServiceCollection services)
        {
            Task task = null;
            services.AddAuthorization(
                options =>
                {
                    task = _policyProviderResolver.ConfigurePoliciesAsync(options);
                });

            await task;
        }
    }
}
