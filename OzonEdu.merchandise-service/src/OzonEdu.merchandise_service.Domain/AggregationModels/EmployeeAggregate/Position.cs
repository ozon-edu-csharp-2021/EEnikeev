using OzonEdu.merchandise_service.DomainBase.Models;

namespace OzonEdu.merchandise_service.Domain.AggregationModels.EmployeeAggregate
{
    /// <summary> Должность сотрудника </summary>
    public class Position : Enumeration
    {
        public static Position Manager = new Position(1, nameof(Manager));
        
        public Position(int id, string name) : base(id, name)
        {
        }
    }
}