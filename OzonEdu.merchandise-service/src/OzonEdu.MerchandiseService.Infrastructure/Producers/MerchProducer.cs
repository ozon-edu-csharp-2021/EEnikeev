using Confluent.Kafka;
using OzonEdu.MerchandiseService.Infrastructure.KafkaContracts;

namespace OzonEdu.MerchandiseService.Infrastructure.Producers
{
    public class MerchProducer : IMerchProducer
    {
        private static int _index = 0;
        
        private readonly IProducer<int, SendEmailContract> _producer;
        
        public MerchProducer(IProducer<int, SendEmailContract> producer)
        {
            _producer = producer;
        }
        
        public void SendEmail(SendEmailContract contract)
        {
            
            var message = new Message<int, SendEmailContract>()
            {
                Key = _index++,
                Value = contract
            };
            
            _producer.Produce("employee_notification_event", message);
        }
    }
}