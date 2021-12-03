using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OpenTracing;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchIsIssued;
using OzonEdu.MerchandiseService.Infrastructure.DomainServices.Interfaces;


namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class GetMerchIsGivenCommandHandler : IRequestHandler<GetMerchIsIssuedCommand, bool>
    {
        
        private IMerchManagerDomainService _merchManagerDomainService;
        private readonly ITracer _tracer;

        public GetMerchIsGivenCommandHandler(IMerchManagerDomainService merchManagerDomainService, ITracer tracer)
        {
            _merchManagerDomainService = merchManagerDomainService;
            _tracer = tracer;
        }

        public async Task<bool> Handle(GetMerchIsIssuedCommand request, CancellationToken cancellationToken)
        {
            using var span = _tracer.BuildSpan("GetMerchIsGivenCommandHandler.Handle").StartActive();
            
            return await _merchManagerDomainService.GetMerchIsIssuedAsync(request, cancellationToken);

        }
    }
}