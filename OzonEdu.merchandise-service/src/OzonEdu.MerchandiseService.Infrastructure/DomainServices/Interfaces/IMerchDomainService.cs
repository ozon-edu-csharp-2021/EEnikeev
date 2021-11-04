using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.DomainServices.Interfaces
{
    public interface IMerchDomainService
    {
        Task<bool> RequestMerchIsInStockBySku(long sku, CancellationToken token);

        Task<bool> RequestMerchInStockBySku(MerchPack pack, CancellationToken token);

        Task ReserveMerchAsync(MerchItem item, CancellationToken token);

        Task ReserveMerchAsync(MerchPack pack, CancellationToken token);
    }
}