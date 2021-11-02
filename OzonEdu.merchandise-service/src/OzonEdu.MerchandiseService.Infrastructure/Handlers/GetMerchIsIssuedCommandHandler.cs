using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.V2;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate.V1;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchIsIssued;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class GetMerchIsIssuedCommandHandler : IRequestHandler<GetMerchIsIssuedCommand>
    {
        private IEmployeeRepository _employeeRepository;

        public GetMerchIsIssuedCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Unit> Handle(GetMerchIsIssuedCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}