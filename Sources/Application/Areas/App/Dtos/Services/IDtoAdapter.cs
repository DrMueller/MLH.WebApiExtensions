using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.WebApiExtensions.Areas.App.Dtos.Models;

namespace Mmu.Mlh.WebApiExtensions.Areas.App.Dtos.Services
{
    public interface IDtoAdapter<TDto, TAggregateRoot>
        where TDto : IDto
        where TAggregateRoot : AggregateRoot
    {
        TAggregateRoot Adapt(TDto dto);

        TDto Adapt(TAggregateRoot aggregateRoot);
    }
}