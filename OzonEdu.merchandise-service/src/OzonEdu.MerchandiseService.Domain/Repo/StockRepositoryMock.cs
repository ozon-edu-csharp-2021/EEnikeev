using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate.V1;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.Repo
{
    /// <summary> заглушка некоего склада </summary>
    public class StockRepositoryMock : IStockRepository
    {
        public IUnitOfWork UnitOfWork { get; }
        
        public Task<bool> CheckInStockBySkuAsync(long sku, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }

        public Task ReserveAsync(MerchItem item, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}