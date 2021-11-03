using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;

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