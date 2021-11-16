using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem
{
    public class GiveMerchItemCommand : IRequest
    {
        public int EmployeeId { get; }
        public int MerchId { get; }
        public int SizeId { get; }

        public GiveMerchItemCommand(int employeeId, int merchId, int sizeId)
        {
            EmployeeId = employeeId;
            MerchId = merchId;
            SizeId = sizeId;
        }
    }
}