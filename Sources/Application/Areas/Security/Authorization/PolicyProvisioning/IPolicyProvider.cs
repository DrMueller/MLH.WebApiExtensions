using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Mmu.Mlh.WebApiExtensions.Areas.Security.Authorization.PolicyProvisioning
{
    public interface IPolicyProvider
    {
        Task ConfigurePoliciesAsync(AuthorizationOptions options);
    }
}