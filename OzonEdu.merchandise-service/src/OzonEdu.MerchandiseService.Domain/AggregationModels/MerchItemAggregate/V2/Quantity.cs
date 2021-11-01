using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate.V2
{
    /// <summary> Количество товара </summary>
    public class Quantity : ValueObject
    {
        public int Value { get; }

        public Quantity(int value)
        {
            Value = value;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}