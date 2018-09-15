using System;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Models
{
    public class Individual : AggregateRoot
    {
        public Individual(string id, string firstName, string lastName, DateTime birthdate)
            : base(id)
        {
            Guard.ObjectNotNull(() => firstName);
            Guard.ObjectNotNull(() => lastName);

            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
        }

        public DateTime Birthdate { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}