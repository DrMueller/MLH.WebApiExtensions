using System;
using Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Models;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.App.Dtos
{
    public class IndividualDto : DtoBase<string>
    {
        public DateTime Birthdate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}