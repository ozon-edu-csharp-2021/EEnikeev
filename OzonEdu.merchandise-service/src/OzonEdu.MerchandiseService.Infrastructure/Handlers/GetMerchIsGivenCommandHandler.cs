using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchIsIssued;
using OzonEdu.MerchandiseService.Infrastructure.DomainServices;
using OzonEdu.MerchandiseService.Infrastructure.DomainServices.Interfaces;


namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class GetMerchIsGivenCommandHandler : IRequestHandler<GetMerchIsIssuedCommand, bool>
    {
        
        private IEmployeeDomainService _employeeDomainService;

        public GetMerchIsGivenCommandHandler(IEmployeeDomainService employeeDomainService)
        {
            _employeeDomainService = employeeDomainService;
        }

        public async Task<bool> Handle(GetMerchIsIssuedCommand request, CancellationToken cancellationToken)
        {
            var employee = await 
                _employeeDomainService.GetEmployeeByIdAsync(request.EmployeeId, cancellationToken);
            
            // если такой мерч уже был выдан сотруднику
            var result = employee.IsGiven(request.MerchId);
                
            return result;
        }
    }
}