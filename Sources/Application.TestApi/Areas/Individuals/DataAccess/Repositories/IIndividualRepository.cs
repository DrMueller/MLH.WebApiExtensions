using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.DomainExtensions.Areas.Repositories;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Models;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.DataAccess.Repositories
{
    public interface IIndividualRepository : IRepository<Individual, string>
    {
        Task<IReadOnlyCollection<Individual>> GetMatthias2Async();
    }
}