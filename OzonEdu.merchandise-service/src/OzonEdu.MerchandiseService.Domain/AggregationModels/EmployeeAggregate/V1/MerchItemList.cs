using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate.V1;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.V1
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