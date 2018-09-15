using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mmu.Mlh.WebApiExtensions.Areas.App.Dtos.Services;

namespace Mmu.Mlh.WebApiExtensions.Areas.Web.Controllers
{
    public abstract class ControllerBase<TDto> : Controller
    {
        private readonly IDtoDataService<TDto> _dataService;

        protected ControllerBase(IDtoDataService<TDto> dataService)
        {
            _dataService = dataService;
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync([FromRoute] string id)
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
        public virtual async Task<IActionResult> GetByIdAsync(string id)
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