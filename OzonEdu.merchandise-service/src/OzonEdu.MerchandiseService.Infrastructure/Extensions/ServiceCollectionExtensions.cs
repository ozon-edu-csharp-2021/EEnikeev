using Jaeger;
using Jaeger.Samplers;
using Jaeger.Senders;
using Jaeger.Senders.Thrift;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTracing;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.ExternalServices;
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

            services.AddSingleton<ITracer>(sd =>
            {
                var loggerFactory = sd.GetService<ILoggerFactory>();

                Jaeger.Configuration.SenderConfiguration.DefaultSenderResolver = new SenderResolver(loggerFactory)
                    .RegisterSenderFactory<ThriftSenderFactory>();

                var sampler = new ConstSampler(true);

                var tracer = new Tracer.Builder("MerchService")
                    .WithLoggerFactory(loggerFactory)
                    .WithSampler(sampler);
                
                return tracer.Build();
            });
            
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            
            services.AddScoped<IEmployeeRepository, EmployeeRepositoryPostgres>();
            
            services.AddScoped<IStockRepository, StockRepositoryMock>();
            
            services.AddScoped<IRepository, PostgRepository>();
            
            //services.AddTransient<IMerchManagerDomainService, MerchManagerDomainServiceMock>();
            
            services.AddTransient<IMerchManagerDomainService, MerchManagerDomainService>();

            return services;

        }

        public static IServiceCollection AddExternalServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddStockGrpcServiceClient(configuration);
            
            return services;
        }
        


    }

}