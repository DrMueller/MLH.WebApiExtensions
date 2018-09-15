using System;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;

namespace Mmu.Mlh.WebApiExtensions.TestApi.Areas.Individuals.DataAccess.DataModels
{
    public class IndividualDataModel : DataModelBase
    {
        public DateTime Birthdate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}