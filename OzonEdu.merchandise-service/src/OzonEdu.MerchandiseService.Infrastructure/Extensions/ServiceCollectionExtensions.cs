using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Handlers;
using OzonEdu.MerchandiseService.Infrastructure.Repo;

namespace OzonEdu.MerchandiseService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service)
        {
            service.AddMediatR(typeof(GiveOutMerchItemCommandHandler).Assembly);
            service.AddSingleton<IEmployeeRepository, EmployeeRepositoryMock>();
            service.AddScoped<IStockRepository, StockRepositoryMock>();
            return service;
        }
    }

}