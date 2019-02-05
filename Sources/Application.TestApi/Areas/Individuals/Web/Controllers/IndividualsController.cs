using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.Mlh.WebApiExtensions.Areas.Controllers;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Application.Dtos;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Application.Services;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class IndividualsController : ControllerBase<IndividualDto, string>
    {
        private readonly IIndividualDtoDataService _dataService;

        public IndividualsController(IIndividualDtoDataService dataService) : base(dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("FirstNames")]
        public async Task<IActionResult> GetAllWithFirstNameMatthiasAsync()
        {
            var dtos = await _dataService.LoadMatthias2Async();
            return Ok(dtos);
        }
    }
}