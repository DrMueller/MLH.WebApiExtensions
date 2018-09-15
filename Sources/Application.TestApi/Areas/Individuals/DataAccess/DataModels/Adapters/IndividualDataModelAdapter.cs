using AutoMapper;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Factories;
using Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.Domain.Models;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.DataAccess.DataModels.Adapters
{
    public class IndividualDataModelAdapter : IDataModelAdapter<IndividualDataModel, Individual>
    {
        private readonly IIndividualFactory _individualFactory;
        private readonly IMapper _mapper;

        public IndividualDataModelAdapter(IIndividualFactory individualFactory, IMapper mapper)
        {
            _individualFactory = individualFactory;
            _mapper = mapper;
        }

        public Individual Adapt(IndividualDataModel dataModel)
        {
            return _individualFactory.Create(
                dataModel.FirstName,
                dataModel.LastName,
                dataModel.Birthdate,
                dataModel.Id);
        }

        public IndividualDataModel Adapt(Individual aggregateRoot)
        {
            return _mapper.Map<IndividualDataModel>(aggregateRoot);
        }
    }
}