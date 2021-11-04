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
        
        private IMerchManagerDomainService _merchManagerDomainService;

        public GetMerchIsGivenCommandHandler(IEmployeeDomainService employeeDomainService, IMerchManagerDomainService merchManagerDomainService)
        {
            _merchManagerDomainService = merchManagerDomainService;
        }

        public async Task<bool> Handle(GetMerchIsIssuedCommand request, CancellationToken cancellationToken)
        {
            
            return await _merchManagerDomainService.GetMerchIsIssuedAsync(request, cancellationToken);

        }
    }
}