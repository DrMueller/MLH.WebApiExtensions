using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Mmu.Mlh.WebApiExtensions.Areas.Web.Security.Authorization.PolicyProvisioning
{
    public interface IPolicyProviderResolver
    {
        Task ConfigurePoliciesAsync(AuthorizationOptions options);
    }
}