namespace OzonEdu.MerchandiseService.Infrastructure.Commands.GetIssuedMerchesCommand
{
    public class GetIssuedMerchesCommand
    {
        public GetIssuedMerchesCommand(int employeeId)
        {
            EmployeeId = employeeId;
        }

        public int EmployeeId { get; }
    }
}