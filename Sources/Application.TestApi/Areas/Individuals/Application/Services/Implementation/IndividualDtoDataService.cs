using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Services.Implementation;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Application.Dtos;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.DataAccess.Repositories;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Models;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Application.Services.Implementation
{
    public class IndividualDtoDataService : DtoDataServiceBase<IndividualDto, Individual, string>, IIndividualDtoDataService
    {
        private readonly IDtoAdapter<IndividualDto, Individual, string> _dtoAdapter;
        private readonly IIndividualRepository _individualRepository;

        public IndividualDtoDataService(IIndividualRepository individualRepository, IDtoAdapter<IndividualDto, Individual, string> dtoAdapter) : base(individualRepository, dtoAdapter)
        {
            _individualRepository = individualRepository;
            _dtoAdapter = dtoAdapter;
        }

        public async Task<IReadOnlyCollection<IndividualDto>> LoadMatthias2Async()
        {
            var individuals = await _individualRepository.GetMatthias2Async();
            return individuals.Select(f => _dtoAdapter.Adapt(f)).ToList();
        }
    }
}