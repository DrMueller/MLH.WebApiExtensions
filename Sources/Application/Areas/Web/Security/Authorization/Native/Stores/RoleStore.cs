﻿////using System;
////using System.Threading;
////using System.Threading.Tasks;
////using Microsoft.AspNetCore.Identity;
////using Mmu.Mlh.WebApiExtensions.Areas.Web.Security.Authorization.Native.Models;

////namespace Mmu.Mlh.WebApiExtensions.Areas.Web.Security.Authorization.Native.Stores
////{
////    public sealed class RoleStore : IRoleStore<Role>
////    {
////        public Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
////        {
////            throw new NotImplementedException();
////        }

////        public Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
////        {
////            throw new NotImplementedException();
////        }

////        public void Dispose()
////        {
////        }

////        public Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
////        {
////            throw new NotImplementedException();
////        }

////        public Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
////        {
////            throw new NotImplementedException();
////        }

////        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
////        {
////            throw new NotImplementedException();
////        }

////        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
////        {
////            throw new NotImplementedException();
////        }

////        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
////        {
////            throw new NotImplementedException();
////        }

////        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
////        {
////            throw new NotImplementedException();
////        }

////        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
////        {
////            throw new NotImplementedException();
////        }

////        public Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
////        {
////            throw new NotImplementedException();
////        }
////    }
////}