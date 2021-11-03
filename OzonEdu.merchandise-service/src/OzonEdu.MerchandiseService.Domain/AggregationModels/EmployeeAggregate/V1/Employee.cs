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
        public EmployeeMerchPack Merch { get; private set; }
        public MerchIssued MerchIsGiven { get; private set; }
        
        #endregion

        public Employee(int id, 
            EmployeeName firstName, 
            EmployeeName lastName, 
            PositionEntity position, 
            EmployeeEmail email, 
            EmployeeMerchPack merch, 
            MerchIssued merchIsGiven)
        {
            
            //EId = ValidateId(id);
            Id = id;
            FirstName = ValidateName(firstName);
            LastName = ValidateName(lastName);
            Position = ValidatePosition(position);
            Email = ValidateEmail(email);
            Merch = merch;
            //RequestedMerch = requestedMerch;
            MerchIsGiven = ValidateIssued(merchIsGiven);
        }
        
        #region Methods

        public void GiveMerch(MerchPack pack, bool isInStock)
        {
            if (pack == null) throw new ArgumentNullException("Merch pack cannot be null");
            
            this.Merch = new EmployeeMerchPack(pack);
            this.MerchIsGiven = new MerchIssued(isInStock);
            //если мерч выдан, кидаем оповещение
            if (MerchIsGiven.Value) MerchGiven( pack);
        }
        
        public bool IsGiven(int merchId)
        {
            if (Merch is null || Merch.Value is null) return false;
            if (Merch.Value.Id != merchId) return false;
            return MerchIsGiven.Value;
        }
        
        void MerchGiven(MerchPack pack)
        {
            var merchItemGivenDomainEvent = new MerchItemGivenDomainEvent(
                this.Email.Value, this.FirstName.Value + " " + this.LastName.Value, pack.Id);
            this.AddDomainEvent(merchItemGivenDomainEvent); 
        }

        #region Validations

        
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
            if (merchIssued is null) throw new ArgumentNullException("Merch given status cannot be null");
            if (merchIssued.Value && (Merch is null || Merch.Value is null)) throw new ArgumentException("Unknown merch cannot be market as given");
            return merchIssued;
        }

        #endregion
        
        #endregion
    }
}