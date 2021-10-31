using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    /// <summary> Сотрудник </summary>
    public class Employee : Entity
    {
        #region Properties

        public EmployeeId EId { get; }
        public EmployeeName FirstName { get; }
        public EmployeeName LastName { get; }
        public PositionEntity Position { get; }

        #endregion

        public Employee(EmployeeId id, EmployeeName firstName, EmployeeName lastName, PositionEntity position)
        {
            EId = id;
            FirstName = firstName;
            LastName = lastName;
            Position = position;
        }
    }
}