using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
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
            //services.AddMediatR(typeof(GiveOutMerchItemCommandHandler).Assembly);
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
    }

}