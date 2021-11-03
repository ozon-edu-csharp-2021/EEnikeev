using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
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