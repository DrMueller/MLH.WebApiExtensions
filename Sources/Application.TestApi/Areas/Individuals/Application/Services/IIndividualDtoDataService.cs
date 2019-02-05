using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Services;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Application.Dtos;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Application.Services
{
    public interface IIndividualDtoDataService : IDtoDataService<IndividualDto, string>
    {
        Task<IReadOnlyCollection<IndividualDto>> LoadMatthias2Async();
    }
}