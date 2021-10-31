using System.Collections.Generic;
using OzonEdu.merchandise_service.DomainBase.Models;

namespace OzonEdu.merchandise_service.Domain.AggregationModels.MerchPackAggregate
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