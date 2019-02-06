using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Services;

namespace Mmu.Mlh.WebApiExtensions.Areas.Controllers
{
    public abstract class ControllerBase<TDto, TId> : Controller
        where TDto : DtoBase<TId>
    {
        private readonly IDtoDataService<TDto, TId> _dataService;

        protected ControllerBase(IDtoDataService<TDto, TId> dataService)
        {
            _dataService = dataService;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public virtual async Task<IActionResult> DeleteAsync([FromRoute] TId id)
        {
            await _dataService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet]
        public virtual async Task<ActionResult<IReadOnlyCollection<TDto>>> GetAllAsync()
        {
            var dtos = await _dataService.LoadAllAsync();
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TDto>> GetByIdAsync(TId id)
        {
            var dto = await _dataService.LoadByIdAsync(id);
            return Ok(dto);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public virtual async Task<CreatedAtActionResult> PostAsync([FromBody] TDto dto)
        {
            dto.Id = default(TId);
            var returnedResult = await _dataService.SaveAsync(dto);
            return CreatedAtAction("GetByIdAsync", new { id = returnedResult.Id }, returnedResult);
        }

        [HttpPut]
        public virtual async Task<ActionResult<TDto>> PutAsync([FromBody] TDto dto)
        {
            var returnedResult = await _dataService.SaveAsync(dto);
            return Ok(returnedResult);
        }
    }
}