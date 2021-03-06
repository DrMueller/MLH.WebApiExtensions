﻿using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Mmu.Mlh.WebApiExtensions.Areas.Initialization.ServiceInitialization.Services.Servants
{
    internal interface IAuthorizationInitializationService
    {
        Task InitializeAsync(IServiceCollection services);
    }
}