using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OzonEdu.MerchandiseService.Infrastructure.Broker.Contracts;

namespace OzonEdu.MerchandiseService.Infrastructure.Broker.Consumers
{
    public class ConsumerHostedService : BackgroundService
    {
        private readonly IConsumer<int, EmployeeEventContract> _consumer;
        private readonly ILogger<ConsumerHostedService> _logger;

        public ConsumerHostedService(IConsumer<int, EmployeeEventContract> consumer, ILogger<ConsumerHostedService> logger)
        {
            _consumer = consumer;
            _logger = logger;
        }

        // public Task StartAsync(CancellationToken cancellationToken)
        // {
        //     return Task.CompletedTask;
        // }
        //
        // public Task StopAsync(CancellationToken cancellationToken)
        // {
        //     return Task.CompletedTask;
        // }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Subscribe("employee_notification_event");
            while (!stoppingToken.IsCancellationRequested)
            {
                var message = _consumer.Consume(stoppingToken);
                _logger.LogInformation("MessageId = {Id}, Value = {Value}", message.Message.Key, message.Message.Value);
            }
            _consumer.Unsubscribe();
            return Task.CompletedTask;
        }
    }
}