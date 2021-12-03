using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OpenTracing;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem;
using OzonEdu.MerchandiseService.Infrastructure.DomainServices.Interfaces;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class GiveOutMerchItemCommandHandler : IRequestHandler<GiveMerchItemCommand>
    {
        private IEmployeeRepository _employeeRepository;
        
        private IMerchManagerDomainService _merchManagerDomainService;
        private readonly ITracer _tracer;

        public GiveOutMerchItemCommandHandler(IEmployeeRepository employeeRepository, IMerchManagerDomainService merchManagerDomainService, ITracer tracer)
        {
            _employeeRepository = employeeRepository;
            _merchManagerDomainService = merchManagerDomainService;
            _tracer = tracer;
        }
        
        public async Task<Unit> Handle(GiveMerchItemCommand request, CancellationToken cancellationToken)
        {
            //var employee = await _merchManagerDomainService.GiveMerchAsync(request, cancellationToken);
            
            using var span = _tracer.BuildSpan("GiveOutMerchItemCommandHandler.Handle").StartActive();
            
            await _merchManagerDomainService.GiveMerchAsync(request, cancellationToken);
            return Unit.Value;

        }
    }
}