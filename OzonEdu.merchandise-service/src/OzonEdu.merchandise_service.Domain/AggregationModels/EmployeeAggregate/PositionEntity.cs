using OzonEdu.merchandise_service.DomainBase.Models;

namespace OzonEdu.merchandise_service.Domain.AggregationModels.EmployeeAggregate
{
    /// <summary> Должность сотрудника </summary>
    public class PositionEntity : Entity
    {
        public Position Position { get; }

        public PositionEntity(Position position)
        {
            Position = position;
        }
    }
}