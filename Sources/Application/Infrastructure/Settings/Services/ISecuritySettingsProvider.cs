using Mmu.Mlh.WebApiExtensions.Infrastructure.Settings.Models;

namespace Mmu.Mlh.WebApiExtensions.Infrastructure.Settings.Services
{
    public interface ISecuritySettingsProvider
    {
        SecuritySettings ProvideSecuritySettings();
    }
}