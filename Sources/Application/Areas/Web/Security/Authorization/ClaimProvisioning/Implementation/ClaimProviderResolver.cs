using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Mmu.Mlh.WebApiExtensions.Areas.Web.Security.Authorization.ClaimProvisioning.Implementation
{
    internal class ClaimProviderResolver : IClaimProviderResolver
    {
        private readonly IClaimProvider[] _claimProviders;

        public ClaimProviderResolver(IClaimProvider[] claimProviders)
        {
            _claimProviders = claimProviders;
        }

        public IReadOnlyCollection<Claim> ProvideClaims(string userId)
        {
            return _claimProviders.SelectMany(f => f.ProvideClaims(userId)).ToList();
        }
    }
}