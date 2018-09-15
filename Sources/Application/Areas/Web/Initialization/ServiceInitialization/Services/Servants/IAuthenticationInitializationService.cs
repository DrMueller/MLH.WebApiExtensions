using Microsoft.Extensions.DependencyInjection;

namespace Mmu.Mlh.WebApiExtensions.Areas.Web.Initialization.ServiceInitialization.Services.Servants
{
    internal interface IAuthenticationInitializationService
    {
        void Initialize(IServiceCollection services);
    }
}