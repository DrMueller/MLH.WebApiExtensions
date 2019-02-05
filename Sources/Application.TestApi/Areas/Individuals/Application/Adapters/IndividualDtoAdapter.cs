using AutoMapper;
using Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Services.Implementation;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Application.Dtos;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Factories;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Models;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Application.Adapters
{
    public class IndividualDtoAdapter : DtoAdapterBase<IndividualDto, Individual, string>
    {
        private readonly IIndividualFactory _individualFactory;

        public IndividualDtoAdapter(IMapper mapper, IIndividualFactory individualFactory) : base(mapper)
        {
            _individualFactory = individualFactory;
        }

        public override Individual Adapt(IndividualDto dto)
        {
            return _individualFactory.Create(
                dto.FirstName,
                dto.LastName,
                dto.Birthdate,
                dto.Id);
        }
    }
}