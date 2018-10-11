using System;
using Mmu.Mlh.DomainExtensions.Areas.Factories;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Models;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Factories.Implementation
{
    public class IndividualFactory : IIndividualFactory
    {
        private readonly IEntityIdFactory<string> _entityIdFactory;

        public IndividualFactory(IEntityIdFactory<string> entityIdFactory)
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