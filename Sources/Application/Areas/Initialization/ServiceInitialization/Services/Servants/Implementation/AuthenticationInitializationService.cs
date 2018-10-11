using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Mlh.WebApiExtensions.Infrastructure.Settings.Models;
using Mmu.Mlh.WebApiExtensions.Infrastructure.Settings.Services;

namespace Mmu.Mlh.WebApiExtensions.Areas.Initialization.ServiceInitialization.Services.Servants.Implementation
{
    internal class AuthenticationInitializationService : IAuthenticationInitializationService
    {
        private readonly ISecuritySettingsProvider _securitySettingsProvider;

        public AuthenticationInitializationService(ISecuritySettingsProvider securitySettingsProvider)
        {
            _securitySettingsProvider = securitySettingsProvider;
        }

        public void Initialize(IServiceCollection services)
        {
            var securitySettings = _securitySettingsProvider.ProvideSecuritySettings();
            if (securitySettings.ActivateSecurity)
            {
                InitializeAzureJwtSecurity(services, securitySettings.AzureAdSettings);
            }
        }

        private static void InitializeAzureJwtSecurity(IServiceCollection services, AzureAdSettings azureAdSettings)
        {
            var authenticationBuidler = services.AddAuthentication(
                options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            );

            authenticationBuidler.AddJwtBearer(
                options =>
                {
                    options.IncludeErrorDetails = true;
                    options.Authority = $"{azureAdSettings.Instance}{azureAdSettings.TenantId}";
                    options.Audience = azureAdSettings.AudienceId;
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                });
        }
    }
}