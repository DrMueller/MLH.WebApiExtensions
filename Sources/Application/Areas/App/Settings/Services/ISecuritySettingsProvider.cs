using Mmu.Mlh.WebApiExtensions.Areas.App.Settings.Models;

namespace Mmu.Mlh.WebApiExtensions.Areas.App.Settings.Services
{
    public interface ISecuritySettingsProvider
    {
        SecuritySettings ProvideSecuritySettings();
    }
}