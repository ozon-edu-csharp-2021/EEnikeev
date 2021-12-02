using System;
using System.IO;
using System.Reflection;
using Confluent.Kafka;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OzonEdu.MerchandiseService.Infrastructure.Broker.Consumers;
using OzonEdu.MerchandiseService.Infrastructure.Broker.Contracts;
using OzonEdu.MerchandiseService.Infrastructure.Broker.Producers;
using OzonEdu.MerchandiseService.Infrastructure.Broker.Serializers;
using OzonEdu.MerchandiseService.Infrastructure.Filters;
using OzonEdu.MerchandiseService.Infrastructure.Interceptors;
using OzonEdu.MerchandiseService.Infrastructure.StartupFilters;


namespace OzonEdu.MerchandiseService.Infrastructure.Extensions
{
    public static class HostBuilderExtensions
    {
        /// <summary> Добавляет необходмую инфраструктуру </summary>
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IStartupFilter, TerminalStartupFilter>();
                
                services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo {Title = "OzonEdu.MerchandiseService", Version = "v1"});
                
                    options.CustomSchemaIds(x => x.FullName);

                    var xmlFileName = Assembly.GetEntryAssembly()?.GetName().Name + ".xml";
                    var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                    options.IncludeXmlComments(xmlFilePath);

                });
                
                services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
                services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());
                
                #region broker
                
                services.AddHostedService<EmployeeEventConsumerHostedService>();
                services.AddHostedService<StockReplenishedEventConsumerHostedService>();
                
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
                
                services.AddSingleton<IConsumer<int, StockReplenishedEventContract>>(producer =>
                {
                    var config = new ConsumerConfig()
                    {
                        BootstrapServers = "localhost:9092",
                        GroupId = "StockEventConsumerGroup",
                        AutoOffsetReset = AutoOffsetReset.Earliest,
                        EnableAutoCommit = false 
                    };
                    var builder = new ConsumerBuilder<int, StockReplenishedEventContract>(config);
                    builder.SetValueDeserializer(new ProducerJsonSerializer<StockReplenishedEventContract>());
                
                    return builder.Build();
                });
            
                services.AddScoped<IMerchProducer, MerchProducer>();
                
                #endregion
            });
            return builder;
        }
        
        
    }
}