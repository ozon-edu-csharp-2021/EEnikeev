using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.V2;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate.V1;
using OzonEdu.MerchandiseService.Domain.Repo;
using OzonEdu.MerchandiseService.Infrastructure.Handlers;

namespace OzonEdu.MerchandiseService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service)
        {
            service.AddMediatR(typeof(GiveOutMerchItemCommandHandler).Assembly);
            service.AddScoped<IEmployeeRepository, EmployeeRepositoryMock>();
            return service;
        }
    }

}