using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mlh.DataAccess.Areas.Repositories;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.DataAccess.DataModels;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Models;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.DataAccess.Repositories
{
    public class IndividualRepository : RepositoryBase<Individual, IndividualDataModel>
    {
        public IndividualRepository(IDataModelRepository<IndividualDataModel> dataModelRepository, IDataModelAdapter<IndividualDataModel, Individual> dataModelAdapter) : base(dataModelRepository, dataModelAdapter)
        {
        }
    }
}