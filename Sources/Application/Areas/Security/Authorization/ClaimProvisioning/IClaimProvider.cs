using System.Collections.Generic;
using System.Security.Claims;

namespace Mmu.Mlh.WebApiExtensions.Areas.Security.Authorization.ClaimProvisioning
{
    public interface IClaimProvider
    {
        IReadOnlyCollection<Claim> ProvideClaims(string userId);
    }
}