using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchIsIssued
{
    /// <summary> Проверить, выдан ли мерч </summary>
    public class GetMerchIsIssuedCommand: IRequest
    {
        public int EmployeeId { get; }
        public int MerchId { get; }

        public GetMerchIsIssuedCommand(int employeeId, int merchId)
        {
            EmployeeId = employeeId;
            MerchId = merchId;
        }
    }
}