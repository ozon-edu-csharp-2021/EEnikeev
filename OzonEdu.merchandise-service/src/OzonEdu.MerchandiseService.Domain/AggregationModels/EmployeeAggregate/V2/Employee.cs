using OzonEdu.MerchandiseService.Domain.Models;


namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.V2
{
    public class Employee : Entity
    {
        public EmployeeId EmployeeId { get; }

        public MerchItemList GivenMerchItems { get; }
        
        public MerchItemList AwaitingMerchItems { get; }
        
        public Employee(EmployeeId employeeId, MerchItemList givenMerchItems, MerchItemList awaitingMerchItems)
        {
            EmployeeId = employeeId;
            GivenMerchItems = givenMerchItems;
            AwaitingMerchItems = awaitingMerchItems;
        }
        
        #region methods

        
        
        #endregion

    }
}