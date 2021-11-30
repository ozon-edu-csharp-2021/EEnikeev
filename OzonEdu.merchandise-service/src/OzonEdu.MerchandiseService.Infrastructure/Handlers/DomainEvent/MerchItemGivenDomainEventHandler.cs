using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.Core.Lib.Enums;
using MediatR;
using OzonEdu.MerchandiseService.Domain.Events;
using OzonEdu.MerchandiseService.Infrastructure.KafkaContracts;
using OzonEdu.MerchandiseService.Infrastructure.Producers;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.DomainEvent
{
    public class MerchItemGivenDomainEventHandler : INotificationHandler<MerchItemGivenDomainEvent>
    {
        private IMerchProducer _merchProducer;
        
        public MerchItemGivenDomainEventHandler(IMerchProducer merchProducer)
        {
            _merchProducer = merchProducer;
        }
        
        public async Task Handle(MerchItemGivenDomainEvent notification, CancellationToken cancellationToken)
        {
            await SendEmail(notification);
        }

        async Task SendEmail(MerchItemGivenDomainEvent notification)
        {
            // отправка сотруднику емэйла
            var contract = new SendEmailContract(
                notification.EmployeeEmail,
                notification.EmployeeName,
                (int)EmployeeEventType.MerchDelivery,
                new PayloadContract(notification.MerchId)
            );
            
            _merchProducer.SendEmail(contract);
        }
        
    }
}