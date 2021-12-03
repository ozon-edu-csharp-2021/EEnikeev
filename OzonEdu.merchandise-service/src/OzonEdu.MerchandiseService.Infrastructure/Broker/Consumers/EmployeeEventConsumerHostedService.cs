using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OzonEdu.MerchandiseService.Infrastructure.Broker.Contracts;

namespace OzonEdu.MerchandiseService.Infrastructure.Broker.Consumers
{
    public class EmployeeEventConsumerHostedService : BackgroundService
    {
        private readonly IConsumer<int, EmployeeEventContract> _consumer;
        private readonly ILogger<EmployeeEventConsumerHostedService> _logger;

        public EmployeeEventConsumerHostedService(IConsumer<int, EmployeeEventContract> consumer, ILogger<EmployeeEventConsumerHostedService> logger)
        {
            _consumer = consumer;
            _logger = logger;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield();
            _consumer.Subscribe("employee_notification_event");
            
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