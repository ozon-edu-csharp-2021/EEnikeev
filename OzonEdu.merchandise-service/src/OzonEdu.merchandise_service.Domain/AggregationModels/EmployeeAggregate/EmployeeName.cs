using System.Collections.Generic;
using OzonEdu.merchandise_service.DomainBase.Models;

namespace OzonEdu.merchandise_service.Domain.AggregationModels.EmployeeAggregate
{
    /// <summary> Имя/фамилия сотрудника </summary>
    public class EmployeeName : ValueObject
    {
        public string Value { get; }

        public EmployeeName(string value)
        {
            Value = value;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}