using System.Collections.Generic;
using OzonEdu.merchandise_service.DomainBase.Models;

namespace OzonEdu.merchandise_service.Domain.AggregationModels.MerchItemAggregate
{
    /// <summary> Идентификатор товара на складе </summary>
    public class Sku : ValueObject
    {
        public long Value { get; }

        public Sku(long value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}