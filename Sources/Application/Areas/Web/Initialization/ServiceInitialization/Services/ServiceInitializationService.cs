using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.WebApiExtensions.Areas.Web.Initialization.ServiceInitialization.Models;
using Mmu.Mlh.WebApiExtensions.Areas.Web.Initialization.ServiceInitialization.Services.Servants;
using Mmu.Mlh.WebApiExtensions.Areas.Web.Initialization.ServiceInitialization.Services.Servants.Implementation;
using StructureMap;

namespace Mmu.Mlh.WebApiExtensions.Areas.Web.Initialization.ServiceInitialization.Services
{
    public static class ServiceInitializationService
    {
        public static IServiceProvider InitializeServices<TWebSettings>(ServiceConfig serviceConfig)
            where TWebSettings : class
        {
            Guard.ObjectNotNull(() => serviceConfig);

            serviceConfig.Services.AddAutoMapper();
            WebSettingsInitializationServant.InitializeWebSettings<TWebSettings>(serviceConfig);
            InitializeSecurity(serviceConfig);
            InitializeCors(serviceConfig.Services);

            serviceConfig.Services.AddMvc();

            var result = CreateServiceProvider(serviceConfig);

            return result;
        }

        private static IServiceProvider CreateServiceProvider(ServiceConfig serviceConfig)
        {
            var container = ContainerInitializationService.CreateInitializedContainer(
                AssemblyParameters.CreateFromAssembly(serviceConfig.BaseAssembly));

            container.Populate(serviceConfig.Services);
            var result = container.GetInstance<IServiceProvider>();
            return result;
        }

        private static void InitializeCors(IServiceCollection services)
        {
            services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        "All",
                        builder =>
                            builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials());
                });
        }

        private static void InitializeSecurity(ServiceConfig serviceConfig)
        {
            var servicesProvider = CreateServiceProvider(serviceConfig);
            var authenticationInitService = servicesProvider.GetService<IAuthenticationInitializationService>();
            var authorizationInitService = servicesProvider.GetService<IAuthorizationInitializationService>();

            authenticationInitService.Initialize(serviceConfig.Services);
            authorizationInitService.InitializeAsync(serviceConfig.Services);
        }
    }
}