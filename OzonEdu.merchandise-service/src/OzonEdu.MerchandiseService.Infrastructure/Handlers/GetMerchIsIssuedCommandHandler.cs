using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchIsIssued;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class GetMerchIsIssuedCommandHandler : IRequestHandler<GetMerchIsIssuedCommand, Unit>
    {
        private IMerchItemRepository _merchItemRepository;

        public GetMerchIsIssuedCommandHandler(IMerchItemRepository merchItemRepository)
        {
            _merchItemRepository = merchItemRepository;
        }

        public async Task<Unit> Handle(GetMerchIsIssuedCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}