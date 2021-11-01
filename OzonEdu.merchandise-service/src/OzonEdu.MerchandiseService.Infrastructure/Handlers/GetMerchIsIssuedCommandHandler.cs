using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate.V1;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchIsIssued;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class GetMerchIsIssuedCommandHandler : IRequestHandler<GetMerchIsIssuedCommand, bool>
    {
        private IMerchItemRepository _merchItemRepository;

        public GetMerchIsIssuedCommandHandler(IMerchItemRepository merchItemRepository)
        {
            _merchItemRepository = merchItemRepository;
        }

        public async Task<bool> Handle(GetMerchIsIssuedCommand request, CancellationToken cancellationToken)
        {
            return false;
        }
    }
}