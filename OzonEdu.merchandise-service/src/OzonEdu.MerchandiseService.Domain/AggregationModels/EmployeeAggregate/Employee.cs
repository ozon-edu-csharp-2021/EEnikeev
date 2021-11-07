using System;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;
using OzonEdu.MerchandiseService.Domain.Events;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    /// <summary> Сотрудник </summary>
    public sealed class Employee : Entity, IAggregateRoot
    {
        public const int MinYearsBeforeNextIssue = 1;
        
        #region Properties

        public EmployeeName FirstName { get; }
        public EmployeeName LastName { get; }
        public EmployeeDateTime HiringDate { get; } 
        public EmployeeEmail Email { get; }
        public EmployeeMerchPack Merch { get; private set; }
        public MerchIssued MerchIsGiven { get; private set; }
        public EmployeeDateTime MerchGivenDate { get; private set; }
        
        #endregion

        public Employee(int id, 
            EmployeeName firstName, 
            EmployeeName lastName, 
            EmployeeDateTime hiringDate, 
            EmployeeEmail email, 
            EmployeeMerchPack merch, 
            MerchIssued merchIsGiven,
            EmployeeDateTime merchGivenDate)
        {
            
            Id = id;
            FirstName = ValidateName(firstName);
            LastName = ValidateName(lastName);
            HiringDate = ValidateHiringDate(hiringDate);
            Email = ValidateEmail(email);
            Merch = ValidateMerch(merch);
            MerchIsGiven = ValidateIssued(merchIsGiven);
            MerchGivenDate = ValidateGivenDate(merchGivenDate);
        }
        
        #region Methods

        public void GiveMerch(MerchPack pack, bool isInStock)
        {
            if (pack == null) throw new ArgumentNullException("Merch pack cannot be null");

            if (isInStock)
            {
                // если мерч уже выдавался, то проверяем, прошло ли с момента выдачи больше года
                if (MerchIsGiven.Value && MerchGivenDate != null)
                {
                    var years = EmployeeDateTime.GetYearsBetween(MerchGivenDate.Value, DateTime.Now);
                        if (years < MinYearsBeforeNextIssue) throw new InvalidOperationException($"Cannot give merch. A {MinYearsBeforeNextIssue} year(s) has not yet passed since the last issue");
                }
                
            }

            this.Merch = new EmployeeMerchPack(pack);
            this.MerchIsGiven = new MerchIssued(isInStock);
            
            //если мерч выдан, устанавливаем дату выдачи и кидаем оповещение
            if (MerchIsGiven.Value)
            {
                MerchGivenDate = new EmployeeDateTime(DateTime.Now);
                MerchGiven(pack);
            }
        }
        
        public bool IsGiven(int merchId)
        {
            if (Merch is null || Merch.Value is null) return false;
            if (Merch.Value.Id != merchId) return false;
            
            
            return MerchIsGiven.Value;
        }
        
        public bool IsGiven()
        {
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

        
        EmployeeDateTime ValidateHiringDate(EmployeeDateTime hiringDate)
        {
            if (hiringDate == null) throw new ArgumentNullException("Hiring date cannot be null!");
            if (hiringDate.Value > System.DateTime.Now) throw new ArgumentException("Hiring date cannot be future");
            return hiringDate;
        }
        
        
        EmployeeEmail ValidateEmail(EmployeeEmail email)
        {
            if (email is null || email.Value is null) throw new ArgumentNullException("Email cannot be null");
            if (email.Value == "") throw new ArgumentException("Email name cannot be empty");
            if (!email.Value.Contains("@")) throw new ArgumentException(
                $"Incorrect email: {email.Value}. Email must contain \"@\" ");
            return email;
        }

        
        EmployeeMerchPack ValidateMerch(EmployeeMerchPack merch)
        {
            if (merch is null || merch.Value is null) return null;
            return merch;
        }

        MerchIssued ValidateIssued(MerchIssued merchIssued)
        {
            if (merchIssued is null) throw new ArgumentNullException("Merch given status cannot be null");
            if (merchIssued.Value && (Merch is null || Merch.Value is null)) throw new ArgumentException("Unknown merch cannot be market as given");
            return merchIssued;
        }

        EmployeeDateTime ValidateGivenDate(EmployeeDateTime givenDate)
        {
            if (givenDate is null)
            {
                if (MerchIsGiven.Value)
                    throw new ArgumentException("Merch is already given, given date cannot be null!");
            }
            if (givenDate is not null)
            {
                if (Merch is null || Merch.Value is null) throw new ArgumentException("Cannot set given date to unknown merch");
                if (!MerchIsGiven.Value) throw new ArgumentException("Cannot set given date to ungiven merch");
            }

            return givenDate;
        }
        

        #endregion
        
        #endregion
    }
}