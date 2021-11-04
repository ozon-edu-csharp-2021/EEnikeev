using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchIsIssued;
using OzonEdu.MerchandiseService.Infrastructure.DomainServices;


namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class GetMerchIsGivenCommandHandler : IRequestHandler<GetMerchIsIssuedCommand, bool>
    {
        private IEmployeeRepository _employeeRepository;

        public GetMerchIsGivenCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(GetMerchIsIssuedCommand request, CancellationToken cancellationToken)
        {
            var employee = await 
                EmployeeMerchDomainService.GetEmployeeByIdAsync(request.EmployeeId, _employeeRepository, cancellationToken);
            
            // если такой мерч уже был выдан сотруднику
            var result = employee.IsGiven(request.MerchId);
                
            return result;
        }
    }
}