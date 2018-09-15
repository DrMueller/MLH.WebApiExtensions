using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mlh.DomainExtensions.Areas.Repositories;
using Mmu.Mlh.WebApiExtensions.Areas.App.Dtos.Services;
using Mmu.Mlh.WebApiExtensions.Areas.App.Settings.Services;
using Mmu.Mlh.WebApiExtensions.Areas.Web.Security.Authorization.ClaimProvisioning;
using Mmu.Mlh.WebApiExtensions.Areas.Web.Security.Authorization.PolicyProvisioning;
using Mmu.Mlh.WebApiExtensions.TestApi.Infrastructure.Settings.Services;
using StructureMap;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Infrastructure.DependencyInjection
{
    public class TestApiRegistry : Registry
    {
        public TestApiRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.TheCallingAssembly();
                    scanner.AddAllTypesOf(typeof(IDtoDataService<>));
                    scanner.AddAllTypesOf(typeof(IDtoAdapter<,>));
                    scanner.AddAllTypesOf(typeof(IRepository<>));
                    scanner.AddAllTypesOf(typeof(IDataModelAdapter<,>));
                    scanner.AddAllTypesOf<IClaimProvider>();
                    scanner.AddAllTypesOf<IPolicyProvider>();
                    scanner.WithDefaultConventions();
                });

            For<ISecuritySettingsProvider>().Use<WebSettingsProvider>().Singleton();
            For<IDatabaseSettingsProvider>().Use<WebSettingsProvider>().Singleton();
        }
    }
}