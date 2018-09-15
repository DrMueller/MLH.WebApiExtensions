﻿using Microsoft.AspNetCore.Mvc;
using Mmu.Mlh.WebApiExtensions.Areas.App.Dtos.Services;
using Mmu.Mlh.WebApiExtensions.Areas.Web.Controllers;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.App.Dtos;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Web.Controllers
{
    [Route("api/[controller]")]
    public class IndividualsController : ControllerBase<IndividualDto>
    {
        public IndividualsController(IDtoDataService<IndividualDto> dataService) : base(dataService)
        {
        }
    }
}