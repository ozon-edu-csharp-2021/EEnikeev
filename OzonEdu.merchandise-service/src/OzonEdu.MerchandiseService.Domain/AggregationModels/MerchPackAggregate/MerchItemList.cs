using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate
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