////using System;
////using System.Collections.Generic;
////using System.Security.Claims;
////using System.Text;
////using System.Threading;
////using System.Threading.Tasks;
////using Microsoft.AspNetCore.Identity;
////using Mmu.Mlh.WebApiExtensions.Areas.Web.Security.Authorization.Native.Models;

////namespace Mmu.Mlh.WebApiExtensions.Areas.Web.Security.Authorization.Native.Stores
////{
////    public sealed class AppUserStore : IUserPasswordStore<AppUser>, IUserClaimStore<AppUser>
////    {

////        public AppUserStore()
////        {

////        }

////        public Task AddClaimsAsync(AppUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
////        {
////            throw new NotImplementedException();
////        }

////        public async Task<IdentityResult> CreateAsync(AppUser user, CancellationToken cancellationToken)
////        {
////            throw new NotImplementedException();
////        }

////        public Task<IdentityResult> DeleteAsync(AppUser user, CancellationToken cancellationToken)
////        {
////            throw new NotImplementedException();
////        }

////        public void Dispose()
////        {
////            GC.SuppressFinalize(this);
////        }

////        public async Task<AppUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
////        {
////            var maybeUser = await _appUserSearchService.SearchByIdAsync(userId);
////            return maybeUser.Reduce(() => null);
////        }

////        public async Task<AppUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
////        {
////            var maybeUser = await _appUserSearchService.SearchByNormalizedUserName(normalizedUserName);
////            return maybeUser.Reduce(() => null);
////        }

////        public Task<IList<Claim>> GetClaimsAsync(AppUser user, CancellationToken cancellationToken)
////        {
////            var claims = (IList<Claim>)_claimSearchService.SearchClaimsByUserId(user.Id).ToList();
////            return Task.FromResult(claims);
////        }

////        public Task<string> GetNormalizedUserNameAsync(AppUser user, CancellationToken cancellationToken)
////        {
////            return Task.FromResult(user.NormalizedUserName);
////        }

////        public Task<string> GetPasswordHashAsync(AppUser user, CancellationToken cancellationToken)
////        {
////            return Task.FromResult(user.PasswordHash);
////        }

////        public Task<string> GetUserIdAsync(AppUser user, CancellationToken cancellationToken)
////        {
////            return Task.FromResult(user.Id);
////        }

////        public Task<string> GetUserNameAsync(AppUser user, CancellationToken cancellationToken)
////        {
////            return Task.FromResult(user.UserName);
////        }

////        public Task<IList<AppUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
////        {
////            throw new NotImplementedException();
////        }

////        public Task<bool> HasPasswordAsync(AppUser user, CancellationToken cancellationToken)
////        {
////            throw new NotImplementedException();
////        }

////        public Task RemoveClaimsAsync(AppUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
////        {
////            throw new NotImplementedException();
////        }

////        public Task ReplaceClaimAsync(AppUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
////        {
////            throw new NotImplementedException();
////        }

////        public Task SetNormalizedUserNameAsync(AppUser user, string normalizedName, CancellationToken cancellationToken)
////        {
////            return Task.Run(
////                () =>
////                {
////                    user.NormalizedUserName = normalizedName;
////                },
////                cancellationToken);
////        }

////        public Task SetPasswordHashAsync(AppUser user, string passwordHash, CancellationToken cancellationToken)
////        {
////            return Task.Run(
////                () =>
////                {
////                    user.PasswordHash = passwordHash;
////                },
////                cancellationToken);
////        }

////        public Task SetUserNameAsync(AppUser user, string userName, CancellationToken cancellationToken)
////        {
////            throw new NotImplementedException();
////        }

////        public Task<IdentityResult> UpdateAsync(AppUser user, CancellationToken cancellationToken)
////        {
////            throw new NotImplementedException();
////        }
////    }
////}