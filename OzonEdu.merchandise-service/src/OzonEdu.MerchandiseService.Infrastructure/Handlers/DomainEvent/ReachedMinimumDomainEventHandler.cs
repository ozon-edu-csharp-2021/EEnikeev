using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.Events;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.DomainEvent
{
    public class ReachedMinimumDomainEventHandler : INotificationHandler<ReachedMinimumMerchItemQuantityDomainEvent>
    {
        public Task Handle(ReachedMinimumMerchItemQuantityDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}