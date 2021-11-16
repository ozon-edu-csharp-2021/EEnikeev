using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchIsIssued;
using OzonEdu.MerchandiseService.Infrastructure.DomainServices.Interfaces;


namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class GetMerchIsGivenCommandHandler : IRequestHandler<GetMerchIsIssuedCommand, bool>
    {
        
        private IMerchManagerDomainService _merchManagerDomainService;

        public GetMerchIsGivenCommandHandler(IMerchManagerDomainService merchManagerDomainService)
        {
            _merchManagerDomainService = merchManagerDomainService;
        }

        public async Task<bool> Handle(GetMerchIsIssuedCommand request, CancellationToken cancellationToken)
        {
            
            return await _merchManagerDomainService.GetMerchIsIssuedAsync(request, cancellationToken);

        }
    }
}