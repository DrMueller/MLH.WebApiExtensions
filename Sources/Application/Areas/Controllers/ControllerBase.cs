using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Services;

namespace Mmu.Mlh.WebApiExtensions.Areas.Controllers
{
    public abstract class ControllerBase<TDto, TId> : Controller
    {
        private readonly IDtoDataService<TDto, TId> _dataService;

        protected ControllerBase(IDtoDataService<TDto, TId> dataService)
        {
            _dataService = dataService;
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync([FromRoute] TId id)
        {
            await _dataService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            var dtos = await _dataService.LoadAllAsync();
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetByIdAsync(TId id)
        {
            var dto = await _dataService.LoadByIdAsync(id);
            return Ok(dto);
        }

        [HttpPut]
        public virtual async Task<IActionResult> SaveAsync([FromBody] TDto dto)
        {
            var returnedResult = await _dataService.SaveAsync(dto);
            return Ok(returnedResult);
        }
    }
}