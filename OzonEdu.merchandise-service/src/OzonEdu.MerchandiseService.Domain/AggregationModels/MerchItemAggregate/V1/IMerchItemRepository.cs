using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate.V1
{
    public interface IMerchItemRepository : IRepository<MerchItem>
    {
        Task<MerchItem> CreateAsync(MerchItem merchItem, CancellationToken cancellationToken = default);
        Task<MerchItem> UpdateAsync(MerchItem merchItem, CancellationToken cancellationToken = default);
        Task<MerchItem> FindByIdAsync(Sku sku, CancellationToken cancellationToken = default);
        Task<MerchItem> FindBySkuAsync(Sku sku, CancellationToken cancellationToken = default);
        
    }
}