using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Configuration;
using OzonEdu.MerchandiseService.Infrastructure.DomainServices;
using OzonEdu.MerchandiseService.Infrastructure.DomainServices.Interfaces;
using OzonEdu.MerchandiseService.Infrastructure.Handlers;
using OzonEdu.MerchandiseService.Infrastructure.Repo;

namespace OzonEdu.MerchandiseService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GiveOutMerchItemCommandHandler).Assembly);
            
            services.AddSingleton<IEmployeeRepository, EmployeeRepositoryMock>();
            services.AddScoped<IStockRepository, StockRepositoryMock>();
            services.AddTransient<IMerchManagerDomainService, MerchManagerDomainService>();
            return services;
        }
    }

}