using Mmu.Mlh.DomainExtensions.Areas.Repositories;
using Mmu.Mlh.WebApiExtensions.Areas.App.Dtos.Services;
using Mmu.Mlh.WebApiExtensions.Areas.App.Dtos.Services.Implementation;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.App.Dtos;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Models;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.App.Services
{
    public class IndividualDtoDataService : DtoDataServiceBase<IndividualDto, Individual>
    {
        public IndividualDtoDataService(IRepository<Individual> repository, IDtoAdapter<IndividualDto, Individual> dtoAdapter) : base(repository, dtoAdapter)
        {
        }
    }
}