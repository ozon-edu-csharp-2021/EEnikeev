using MediatR;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    public class MerchItemGivenDomainEvent : INotification
    {
        public string EmployeeEmail { get; }
        public string EmployeeName { get; }
        public int MerchId { get; }

        public MerchItemGivenDomainEvent(string employeeEmail, string employeeName, int merchId)
        {
            EmployeeEmail = employeeEmail;
            EmployeeName = employeeName;
            MerchId = merchId;
        }
    }
}