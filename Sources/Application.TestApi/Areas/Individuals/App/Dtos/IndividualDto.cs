using System;
using Mmu.Mlh.WebApiExtensions.Areas.App.Dtos.Models;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.App.Dtos
{
    public class IndividualDto : IDto
    {
        public string Id { get; set; }
        public DateTime Birthdate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}