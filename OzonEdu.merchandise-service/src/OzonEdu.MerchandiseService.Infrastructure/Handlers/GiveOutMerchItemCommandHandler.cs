using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem;
using OzonEdu.MerchandiseService.Infrastructure.DomainServices.Interfaces;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class GiveOutMerchItemCommandHandler : IRequestHandler<GiveMerchItemCommand>
    {
        private IEmployeeRepository _employeeRepository;
        
        private IMerchManagerDomainService _merchManagerDomainService;

        public GiveOutMerchItemCommandHandler(IEmployeeRepository employeeRepository, IMerchManagerDomainService merchManagerDomainService)
        {
            _employeeRepository = employeeRepository;
            _merchManagerDomainService = merchManagerDomainService;
        }
        
        public async Task<Unit> Handle(GiveMerchItemCommand request, CancellationToken cancellationToken)
        {
            //var employee = await _merchManagerDomainService.GiveMerchAsync(request, cancellationToken);
            await _merchManagerDomainService.GiveMerchAsync(request, cancellationToken);
            return Unit.Value;

        }
    }
}