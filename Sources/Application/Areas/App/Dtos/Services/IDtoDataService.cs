using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mmu.Mlh.WebApiExtensions.Areas.App.Dtos.Services
{
    public interface IDtoDataService<TDto>
    {
        Task DeleteAsync(string id);

        Task<IReadOnlyCollection<TDto>> LoadAllAsync();

        Task<TDto> LoadByIdAsync(string id);

        Task<TDto> SaveAsync(TDto dto);
    }
}