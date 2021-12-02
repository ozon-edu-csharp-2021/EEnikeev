using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OzonEdu.MerchandiseService.Infrastructure.Broker.Contracts;

namespace OzonEdu.MerchandiseService.Infrastructure.Broker.Consumers
{
    public class StockReplenishedEventConsumerHostedService: BackgroundService
    {
        private readonly IConsumer<int, StockReplenishedEventContract> _consumer;
        private readonly ILogger<StockReplenishedEventConsumerHostedService> _logger;

        public StockReplenishedEventConsumerHostedService(IConsumer<int, StockReplenishedEventContract> consumer, ILogger<StockReplenishedEventConsumerHostedService> logger)
        {
            _consumer = consumer;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield();
            _consumer.Subscribe("stock_replenished_event");

            while (!stoppingToken.IsCancellationRequested)
            {
                var message = _consumer.Consume(stoppingToken);
                _logger.LogInformation("MessageId = {Id}, Value = {Value}", message.Message.Key, message.Message.Value);
                _consumer.Commit();
            }

            _consumer.Unsubscribe();
            //return Task.CompletedTask;
        }
    }
}