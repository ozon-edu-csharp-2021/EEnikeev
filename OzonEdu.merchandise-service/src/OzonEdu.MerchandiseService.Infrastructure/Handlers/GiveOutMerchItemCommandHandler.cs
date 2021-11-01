using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate.V1;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class GiveOutMerchItemCommandHandler : IRequestHandler<GiveOutMerchItemCommand>
    {
        private IMerchItemRepository _merchItemRepository;

        public GiveOutMerchItemCommandHandler(IMerchItemRepository merchItemRepository)
        {
            _merchItemRepository = merchItemRepository;
        }
        
        public async Task<Unit> Handle(GiveOutMerchItemCommand request, CancellationToken cancellationToken)
        {
            var merchItem = await _merchItemRepository.FindBySkuAsync(new Sku(request.Sku), cancellationToken);
            if (merchItem == null) throw new Exception($"Not found with sku {request.Sku}");
            merchItem.GiveOutItems(request.Quantity);
            await _merchItemRepository.UpdateAsync(merchItem, cancellationToken);
            await _merchItemRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}