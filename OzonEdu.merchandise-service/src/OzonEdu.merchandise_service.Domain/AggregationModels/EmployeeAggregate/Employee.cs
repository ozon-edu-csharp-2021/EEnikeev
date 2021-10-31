using OzonEdu.merchandise_service.DomainBase.Models;

namespace OzonEdu.merchandise_service.Domain.AggregationModels.EmployeeAggregate
{
    /// <summary> Сотрудник </summary>
    public class Employee : Entity
    {
        #region Properties

        public EmployeeId Id { get; }
        public EmployeeName FirstName { get; }
        public EmployeeName LastName { get; }
        public PositionEntity Position { get; }

        #endregion

        public Employee(EmployeeId id, EmployeeName firstName, EmployeeName lastName, PositionEntity position)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Position = position;
        }
    }
}