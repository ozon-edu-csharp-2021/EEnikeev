using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class EmployeeDateTime : ValueObject
    {
        public  DateTime Value { get; }

        public EmployeeDateTime(DateTime value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static DateTime Parse(string s)
        {
            return DateTime.Parse(s);
        }

        public static int GetYearsBetween(DateTime startDate, DateTime endDate)
        {
            return (endDate.Year - startDate.Year - 1) +
                        (((endDate.Month > startDate.Month) ||
                          ((endDate.Month == startDate.Month) && (endDate.Day >= startDate.Day))) ? 1 : 0);
        }
        
        
    }
}