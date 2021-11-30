using System.Text;
using System.Text.Json;
using Confluent.Kafka;

namespace OzonEdu.MerchandiseService.Infrastructure.Producers
{
    public class ProducerJsonSerializer<TMessage> : ISerializer<TMessage>
    {
        public byte[] Serialize(TMessage data, SerializationContext context)
        {
            return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data));
        }
    }
}