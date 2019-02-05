using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;
using Mmu.Mlh.WebApiExtensions.Areas.ExceptionHandling.Services;
using Mmu.Mlh.WebApiExtensions.Areas.Initialization.ServiceInitialization.Models;
using Mmu.Mlh.WebApiExtensions.Areas.Initialization.ServiceInitialization.Services.Servants;
using Mmu.Mlh.WebApiExtensions.Areas.Initialization.ServiceInitialization.Services.Servants.Implementation;
using StructureMap;

namespace Mmu.Mlh.WebApiExtensions.Areas.Initialization.ServiceInitialization.Services
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

            var serviceProvider = CreateServiceProvider(serviceConfig);

            InitializeExceptionHandling(serviceProvider, serviceConfig.ExceptionCallback);

            return serviceProvider;
        }

        private static IServiceProvider CreateServiceProvider(ServiceConfig serviceConfig)
        {
            var container = ContainerInitializationService.CreateInitializedContainer(
                ContainerConfiguration.CreateFromAssembly(serviceConfig.BaseAssembly));

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

        private static void InitializeExceptionHandling(IServiceProvider serviceProvider, Maybe<Action<Exception>> serviceConfigExceptionCallback)
        {
            var exceptionCallbackService = serviceProvider.GetService<IExceptionCallbackService>();
            exceptionCallbackService.InitializeCallback(serviceConfigExceptionCallback);
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