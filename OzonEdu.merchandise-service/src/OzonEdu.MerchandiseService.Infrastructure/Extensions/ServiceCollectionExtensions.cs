using Confluent.Kafka;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Broker.Consumers;
using OzonEdu.MerchandiseService.Infrastructure.Broker.Contracts;
using OzonEdu.MerchandiseService.Infrastructure.Broker.Producers;
using OzonEdu.MerchandiseService.Infrastructure.Broker.Serializers;
using OzonEdu.MerchandiseService.Infrastructure.Configuration;
using OzonEdu.MerchandiseService.Infrastructure.DomainServices;
using OzonEdu.MerchandiseService.Infrastructure.DomainServices.Interfaces;
using OzonEdu.MerchandiseService.Infrastructure.Handlers;
using OzonEdu.MerchandiseService.Infrastructure.Repo;
using OzonEdu.MerchandiseService.Infrastructure.Repositories;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Implementation;

namespace OzonEdu.MerchandiseService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            
            services.AddMediatR(typeof(GiveOutMerchItemCommandHandler), typeof(DatabaseConnectionOptions));

            //services.AddSingleton<IEmployeeRepository, EmployeeRepositoryMock>();
            
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            
            services.AddScoped<IEmployeeRepository, EmployeeRepositoryPostgres>();
            
            services.AddScoped<IStockRepository, StockRepositoryMock>();
            
            services.AddScoped<IRepository, PostgRepository>();
            
            //services.AddTransient<IMerchManagerDomainService, MerchManagerDomainServiceMock>();
            
            services.AddTransient<IMerchManagerDomainService, MerchManagerDomainService>();
            
            return services;

        }

        public static IServiceCollection AddKafka(this IServiceCollection services)
        {
            services.AddHostedService<ConsumerHostedService>();
            
            services.AddSingleton<IProducer<int, EmployeeEventContract>>(producer =>
            {
                var config = new ProducerConfig()
                {
                    BootstrapServers = "localhost:9092"
                };
                var builder = new ProducerBuilder<int, EmployeeEventContract>(config);
                builder.SetValueSerializer(new ProducerJsonSerializer<EmployeeEventContract>());
                
                return builder.Build();
            });
            
            services.AddSingleton<IConsumer<int, EmployeeEventContract>>(producer =>
            {
                var config = new ConsumerConfig()
                {
                    BootstrapServers = "localhost:9092",
                    GroupId = "EmployeeEventConsumerGroup",
                    AutoOffsetReset = AutoOffsetReset.Earliest,
                    EnableAutoCommit = false 
                };
                var builder = new ConsumerBuilder<int, EmployeeEventContract>(config);
                builder.SetValueDeserializer(new ProducerJsonSerializer<EmployeeEventContract>());
                
                return builder.Build();
            });
            
            services.AddScoped<IMerchProducer, MerchProducer>();

            return services;
        }


    }

}