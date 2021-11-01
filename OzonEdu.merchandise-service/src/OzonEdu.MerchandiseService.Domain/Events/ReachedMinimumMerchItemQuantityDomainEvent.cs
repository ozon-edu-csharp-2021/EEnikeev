using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate.V1;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    public class ReachedMinimumMerchItemQuantityDomainEvent : INotification
    {
        public Sku MerchItemSku { get; }

        public ReachedMinimumMerchItemQuantityDomainEvent(Sku merchItemSku)
        {
            MerchItemSku = merchItemSku;
        }
    }
}