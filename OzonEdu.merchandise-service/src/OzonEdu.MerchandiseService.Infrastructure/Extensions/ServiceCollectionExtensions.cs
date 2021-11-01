using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Handlers;

namespace OzonEdu.MerchandiseService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service)
        {
            service.AddMediatR(typeof(GiveOutMerchItemCommandHandler).Assembly);
            service.AddScoped<IMerchItemRepository, Repository.RepositoryMock>();
            return service;
        }
    }

}