using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.V1
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