using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem
{
    public class GiveOutMerchItemCommand : IRequest
    {
        public int EmployeeId { get; }
        public int MerchId { get; }

        public GiveOutMerchItemCommand(int employeeId, int merchId)
        {
            EmployeeId = employeeId;
            MerchId = merchId;
        }
    }
}