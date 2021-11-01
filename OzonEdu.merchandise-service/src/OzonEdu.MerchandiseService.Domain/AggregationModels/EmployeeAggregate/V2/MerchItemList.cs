using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate.V2;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.V2
{
    public class MerchItemList : ValueObject
    {
        public List<MerchItem> Items { get; }
        
        public MerchItemList(List<MerchItem> items)
        {
            Items = items;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Items;
        }
    }
}