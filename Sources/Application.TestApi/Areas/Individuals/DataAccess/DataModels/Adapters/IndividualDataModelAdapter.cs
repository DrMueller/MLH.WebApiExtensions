using AutoMapper;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services.Implementation;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Factories;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Models;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.DataAccess.DataModels.Adapters
{
    public class IndividualDataModelAdapter : DataModelAdapterBase<IndividualDataModel, Individual, string>
    {
        private readonly IIndividualFactory _individualFactory;

        public IndividualDataModelAdapter(IIndividualFactory individualFactory, IMapper mapper) : base(mapper)
        {
            _individualFactory = individualFactory;
        }

        public override Individual Adapt(IndividualDataModel dataModel)
        {
            return _individualFactory.Create(
                dataModel.FirstName,
                dataModel.LastName,
                dataModel.Birthdate,
                dataModel.Id);
        }
    }
}