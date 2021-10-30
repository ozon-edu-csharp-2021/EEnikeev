using System.Collections.Generic;
using OzonEdu.merchandise_service.DomainBase.Models;

namespace OzonEdu.merchandise_service.Domain.AggregationModels.MerchItemAggregate
{
    /// <summary> Наименование товара </summary>
    public class Name : ValueObject
    {
        public string Value { get; }

        public Name(string value)
        {
            Value = value;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}