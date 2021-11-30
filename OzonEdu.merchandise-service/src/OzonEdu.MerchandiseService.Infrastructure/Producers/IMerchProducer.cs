using OzonEdu.MerchandiseService.Domain.Events;
using OzonEdu.MerchandiseService.Infrastructure.KafkaContracts;

namespace OzonEdu.MerchandiseService.Infrastructure.Producers
{
    public interface IMerchProducer
    {
        public void SendEmail(SendEmailContract contract);

    }
}