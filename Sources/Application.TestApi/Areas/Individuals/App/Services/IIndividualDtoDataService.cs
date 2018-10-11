using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Services;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.App.Dtos;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.App.Services
{
    public interface IIndividualDtoDataService : IDtoDataService<IndividualDto, string>
    {
        Task<IReadOnlyCollection<IndividualDto>> LoadMatthias2Async();
    }
}