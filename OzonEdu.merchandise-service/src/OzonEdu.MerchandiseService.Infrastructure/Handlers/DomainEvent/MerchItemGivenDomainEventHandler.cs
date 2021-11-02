using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.Events;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.DomainEvent
{
    public class MerchItemGivenDomainEventHandler : INotificationHandler<MerchItemGivenDomainEvent>
    {
        public async Task Handle(MerchItemGivenDomainEvent notification, CancellationToken cancellationToken)
        {
            await SendEmail();
        }

        async Task SendEmail()
        {
            
        }
        
    }
}