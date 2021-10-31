using System.Collections.Generic;
using OzonEdu.merchandise_service.DomainBase.Models;

namespace OzonEdu.merchandise_service.Domain.AggregationModels.EmployeeAggregate
{
    /// <summary> Идентификатор сотрудника </summary>
    public class EmployeeId :ValueObject
    {
        public long Value { get; }

        public EmployeeId(long value)
        {
            Value = value;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}