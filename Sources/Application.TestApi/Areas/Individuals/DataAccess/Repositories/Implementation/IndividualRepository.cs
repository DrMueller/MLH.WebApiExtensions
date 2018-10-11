using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mlh.DataAccess.Areas.Repositories;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.DataAccess.DataModels;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Models;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.DataAccess.Repositories.Implementation
{
    public class IndividualRepository : RepositoryBase<Individual, IndividualDataModel, string>, IIndividualRepository
    {
        private readonly IDataModelAdapter<IndividualDataModel, Individual, string> _dataModelAdapter;
        private readonly IDataModelRepository<IndividualDataModel, string> _dataModelRepository;

        public IndividualRepository(IDataModelRepository<IndividualDataModel, string> dataModelRepository, IDataModelAdapter<IndividualDataModel, Individual, string> dataModelAdapter) : base(dataModelRepository, dataModelAdapter)
        {
            _dataModelRepository = dataModelRepository;
            _dataModelAdapter = dataModelAdapter;
        }

        public async Task<IReadOnlyCollection<Individual>> GetMatthias2Async()
        {
            var individualDataModels = await _dataModelRepository.LoadAsync(f => f.FirstName == "Matthias2");
            return individualDataModels.Select(dm => _dataModelAdapter.Adapt(dm)).ToList();
        }
    }
}