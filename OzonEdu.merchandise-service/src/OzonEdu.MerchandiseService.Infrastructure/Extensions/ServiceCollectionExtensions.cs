using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;
using OzonEdu.MerchandiseService.Infrastructure.Handlers;

namespace OzonEdu.MerchandiseService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service)
        {
            service.AddMediatR(typeof(GiveOutMerchItemCommandHandler).Assembly);
            service.AddScoped<IMerchItemRepository, Repo>();
            return service;
        }
    }
    
    public class Repo : IMerchItemRepository
    {
        public IUnitOfWork UnitOfWork { get; }
        public Task<MerchItem> CreateAsync(MerchItem merchItem, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchItem> UpdateAsync(MerchItem merchItem, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchItem> FindByIdAsync(Sku sku, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchItem> FindBySkuAsync(Sku sku, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}