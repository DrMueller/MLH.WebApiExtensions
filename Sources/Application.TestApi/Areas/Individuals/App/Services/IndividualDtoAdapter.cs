using AutoMapper;
using Mmu.Mlh.WebApiExtensions.Areas.App.Dtos.Services.Implementation;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.App.Dtos;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Factories;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Models;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.App.Services
{
    public class IndividualDtoAdapter : DtoAdapterBase<IndividualDto, Individual>
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