using System;
using Mmu.Mlh.DataAccess.Areas.IdGeneration;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Models;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Factories.Implementation
{
    public class IndividualFactory : IIndividualFactory
    {
        private readonly IEntityIdFactory _entityIdFactory;

        public IndividualFactory(IEntityIdFactory entityIdFactory)
        {
            _entityIdFactory = entityIdFactory;
        }

        public Individual Create(string firstName, string lastName, DateTime birthdate, string id = null)
        {
            return new Individual(
                id ?? _entityIdFactory.CreateEntityId(),
                firstName,
                lastName,
                birthdate);
        }
    }
}