namespace Mmu.Mlh.WebApiExtensions.Infrastructure.Settings.Models
{
    public class SecuritySettings
    {
        public bool ActivateSecurity { get; set; }
        public AzureAdSettings AzureAdSettings { get; set; }
    }
}