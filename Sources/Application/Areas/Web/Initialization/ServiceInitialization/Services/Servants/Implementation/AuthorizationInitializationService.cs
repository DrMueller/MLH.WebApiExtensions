using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Mlh.WebApiExtensions.Areas.Web.Security.Authorization.PolicyProvisioning;

namespace Mmu.Mlh.WebApiExtensions.Areas.Web.Initialization.ServiceInitialization.Services.Servants.Implementation
{
    internal class AuthorizationInitializationService : IAuthorizationInitializationService
    {
        private readonly IPolicyProvider[] _policyProviders;

        public AuthorizationInitializationService(IPolicyProvider[] policyProviders)
        {
            _policyProviders = policyProviders;
        }

        public async Task InitializeAsync(IServiceCollection services)
        {
            Task[] tasks = null;
            services.AddAuthorization(
                options =>
                {
                    tasks = _policyProviders.Select(p => p.ConfigurePoliciesAsync(options)).ToArray();
                });

            await Task.WhenAll(tasks);
        }
    }
}