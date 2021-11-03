using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class MerchList : ValueObject
    {
        public List<MerchPack> Items { get; }
        
        public MerchList(List<MerchPack> items)
        {
            Items = items;
        }

        public MerchList()
        {
            Items = new List<MerchPack>();
        }
        

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Items;
        }
    }
}