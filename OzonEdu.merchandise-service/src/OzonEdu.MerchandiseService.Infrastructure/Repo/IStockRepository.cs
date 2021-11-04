using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.Repo
{
    public interface IStockRepository: IRepository<MerchItem>
    {
        public IUnitOfWork UnitOfWork { get; }
        
        Task<bool> CheckInStockBySkuAsync(long sku, CancellationToken cancellationToken = default);

        Task ReserveAsync(MerchItem item, CancellationToken cancellationToken = default);

    }
    
}