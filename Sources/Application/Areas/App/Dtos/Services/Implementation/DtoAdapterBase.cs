using AutoMapper;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.WebApiExtensions.Areas.App.Dtos.Models;

namespace Mmu.Mlh.WebApiExtensions.Areas.App.Dtos.Services.Implementation
{
    public abstract class DtoAdapterBase<TDto, TAggregateRoot> : IDtoAdapter<TDto, TAggregateRoot>
        where TDto : IDto
        where TAggregateRoot : AggregateRoot
    {
        private readonly IMapper _mapper;

        protected DtoAdapterBase(IMapper mapper)
        {
            _mapper = mapper;
        }

        public abstract TAggregateRoot Adapt(TDto dto);

        public TDto Adapt(TAggregateRoot aggregateRoot)
        {
            return _mapper.Map<TDto>(aggregateRoot);
        }
    }
}