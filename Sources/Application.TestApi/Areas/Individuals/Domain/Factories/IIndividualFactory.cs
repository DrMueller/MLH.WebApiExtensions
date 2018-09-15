using System;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Models;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Factories
{
    public interface IIndividualFactory
    {
        Individual Create(string firstName, string lastName, DateTime birthdate, string id = null);
    }
}