using System;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.V1
{
    /// <summary> Сотрудник </summary>
    public class Employee : Entity
    {
        #region Properties

        public EmployeeId EId { get; }
        public EmployeeName FirstName { get; }
        public EmployeeName LastName { get; }
        public PositionEntity Position { get; }
        public MerchIssued MerchIsIssued { get; }
        
        #endregion

        public Employee(EmployeeId id, EmployeeName firstName, EmployeeName lastName, PositionEntity position, MerchIssued merchIsIssued)
        {
            EId = ValidateId(id);
            FirstName = ValidateName(firstName);
            LastName = ValidateName(lastName);
            Position = ValidatePosition(position);
            MerchIsIssued = ValidateIssued(merchIsIssued);
        }
        
        #region Methods

        EmployeeId ValidateId(EmployeeId id)
        {
            if (id == null) throw new ArgumentNullException("Employee id cannot be null");
            return id;
        }

        EmployeeName ValidateName(EmployeeName name)
        {
            if (name is null || name.Value is null) throw new ArgumentNullException("Employee name cannot be null");
            if (name.Value == "") throw new ArgumentException("Employee name cannot be empty");
            return name;
        }

        PositionEntity ValidatePosition(PositionEntity position)
        {
            if (position is null || position.Position is null) throw new ArgumentNullException("Employee position cannot be null");
            return position;
        }

        MerchIssued ValidateIssued(MerchIssued merchIssued)
        {
            if (merchIssued is null) throw new ArgumentNullException("Merch issue status cannot be null");
            return merchIssued;
        }

        #endregion
    }
}