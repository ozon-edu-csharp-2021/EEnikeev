using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Infrastructure.Repo
{
    /// <summary> заглушка некоего склада </summary>
    public class StockRepositoryMock : IStockRepository
    {
        public IUnitOfWork UnitOfWork { get; }
        
        public Task<bool> CheckInStockBySkuAsync(long sku, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }

        public Task<bool> CheckInStockBySkuAsync(IEnumerable<long> skuItems, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }

        public Task ReserveAsync(MerchItem item, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task ReserveAsync(IEnumerable<MerchItem> items, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}