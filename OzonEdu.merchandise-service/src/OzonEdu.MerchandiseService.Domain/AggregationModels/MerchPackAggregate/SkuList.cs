using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    public class SkuList : ValueObject
    {
        public List<Sku> Values { get; init; }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Values;
        }
    }
}