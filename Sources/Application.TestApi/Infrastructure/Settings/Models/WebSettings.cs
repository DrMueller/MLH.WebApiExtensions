using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Models;
using Mmu.Mlh.WebApiExtensions.Areas.App.Settings.Models;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Infrastructure.Settings.Models
{
    public class WebSettings
    {
        public DatabaseSettings DatabaseSettings { get; set; }
        public SecuritySettings SecuritySettings { get; set; }
    }
}