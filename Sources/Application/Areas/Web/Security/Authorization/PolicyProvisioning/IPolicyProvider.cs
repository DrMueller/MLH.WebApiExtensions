using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Mmu.Mlh.WebApiExtensions.Areas.Web.Security.Authorization.PolicyProvisioning
{
    public interface IPolicyProvider
    {
        Task ConfigurePoliciesAsync(AuthorizationOptions options);
    }
}