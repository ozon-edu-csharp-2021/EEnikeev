using System.Collections.Generic;
using OzonEdu.merchandise_service.DomainBase.Models;

namespace OzonEdu.merchandise_service.Domain.AggregationModels.MerchItemAggregate
{
    /// <summary> Ограничение по минимальному количеству товара </summary>
    public class MinimalQuantity : ValueObject
    {
        public  int Value { get; }

        public MinimalQuantity(int value)
        {
            Value = value;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}