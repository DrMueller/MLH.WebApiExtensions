using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.DomainExtensions.Areas.Repositories;
using Mmu.Mlh.WebApiExtensions.Areas.App.Dtos.Models;

namespace Mmu.Mlh.WebApiExtensions.Areas.App.Dtos.Services.Implementation
{
    public abstract class DtoDataServiceBase<TDto, TAg> : IDtoDataService<TDto>
        where TAg : AggregateRoot
        where TDto : IDto
    {
        private readonly IDtoAdapter<TDto, TAg> _dtoAdapter;
        private readonly IRepository<TAg> _repository;

        protected DtoDataServiceBase(IRepository<TAg> repository, IDtoAdapter<TDto, TAg> dtoAdapter)
        {
            _repository = repository;
            _dtoAdapter = dtoAdapter;
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IReadOnlyCollection<TDto>> LoadAllAsync()
        {
            var aggegateRoots = await _repository.LoadAllAsync();
            return aggegateRoots.Select(aggregateRoot => _dtoAdapter.Adapt(aggregateRoot)).ToList();
        }

        public async Task<TDto> LoadByIdAsync(string id)
        {
            var aggregateRoot = await _repository.LoadByIdAsync(id);
            return _dtoAdapter.Adapt(aggregateRoot);
        }

        public async Task<TDto> SaveAsync(TDto dto)
        {
            var aggregateRoot = _dtoAdapter.Adapt(dto);
            var returnedAggregateRoot = await _repository.SaveAsync(aggregateRoot);
            var result = _dtoAdapter.Adapt(returnedAggregateRoot);
            return result;
        }
    }
}