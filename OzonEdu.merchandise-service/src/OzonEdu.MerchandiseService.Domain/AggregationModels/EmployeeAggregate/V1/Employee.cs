using System;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.Events;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.V1
{
    /// <summary> Сотрудник </summary>
    public sealed class Employee : Entity
    {
        #region Properties

        //public EmployeeId EId { get; }
        public EmployeeName FirstName { get; }
        public EmployeeName LastName { get; }
        public PositionEntity Position { get; }
        public EmployeeEmail Email { get; }
        //public MerchIssued MerchIsIssued { get; }
        public EmployeeMerchPack Merch { get; private set; }
        
        #endregion

        public Employee(int id, EmployeeName firstName, EmployeeName lastName, PositionEntity position, EmployeeEmail email)
        {
            //EId = ValidateId(id);
            Id = id;
            FirstName = ValidateName(firstName);
            LastName = ValidateName(lastName);
            Position = ValidatePosition(position);
            Email = ValidateEmail(email);
            
            //MerchIsIssued = ValidateIssued(merchIsIssued);
        }
        
        #region Methods

        public void GiveMerch(MerchPack pack)
        {
            if (pack == null) throw new ArgumentNullException("Merch pack cannot be null");
            this.Merch = new EmployeeMerchPack(pack);
            MerchGiven( pack);
        }
        
        public bool IsGiven(int merchId)
        {
            return (Merch is not null && Merch.Value.Id == merchId);
        }
        
        void MerchGiven(MerchPack pack)
        {
            var merchItemGivenDomainEvent = new MerchItemGivenDomainEvent(
                this.Email.Value, this.FirstName.Value + " " + this.LastName.Value, pack.Id);
            this.AddDomainEvent(merchItemGivenDomainEvent); 
        }

        #region Validations

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
        
        EmployeeEmail ValidateEmail(EmployeeEmail email)
        {
            if (email is null || email.Value is null) throw new ArgumentNullException("Email cannot be null");
            if (email.Value == "") throw new ArgumentException("Email name cannot be empty");
            if (!email.Value.Contains("@")) throw new ArgumentException(
                $"Incorrect email: {email.Value}. Email must contain \"@\" ");
            return email;
        }

        MerchIssued ValidateIssued(MerchIssued merchIssued)
        {
            if (merchIssued is null) throw new ArgumentNullException("Merch issue status cannot be null");
            return merchIssued;
        }

        #endregion
        
        #endregion
    }
}