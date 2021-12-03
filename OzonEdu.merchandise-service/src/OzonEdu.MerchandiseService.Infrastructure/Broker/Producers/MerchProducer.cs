using Confluent.Kafka;
using OzonEdu.MerchandiseService.Infrastructure.Broker.Contracts;

namespace OzonEdu.MerchandiseService.Infrastructure.Broker.Producers
{
    public class MerchProducer : IMerchProducer
    {
        private static int _index = 0;
        
        private readonly IProducer<int, EmployeeEventContract> _producer;
        
        public MerchProducer(IProducer<int, EmployeeEventContract> producer)
        {
            _producer = producer;
        }
        
        public void SendEmail(EmployeeEventContract contract)
        {
            
            var message = new Message<int, EmployeeEventContract>()
            {
                Key = _index++,
                Value = contract
            };
            
            _producer.Produce("employee_notification_event", message);
        }
    }
}