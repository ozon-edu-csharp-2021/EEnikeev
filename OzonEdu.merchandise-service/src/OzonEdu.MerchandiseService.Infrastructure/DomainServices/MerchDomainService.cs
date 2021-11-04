using System;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Infrastructure.DomainServices.Interfaces;
using OzonEdu.MerchandiseService.Infrastructure.Repo;

namespace OzonEdu.MerchandiseService.Infrastructure.DomainServices
{
    public class MerchDomainService : IMerchDomainService
    {
        private IStockRepository _stockRepository;

        public MerchDomainService(IStockRepository stockRepository)
        {
            this._stockRepository = stockRepository;
        }

        public async Task<bool> RequestMerchIsInStockBySku(long sku, CancellationToken token)
        {
            return await _stockRepository.CheckInStockBySkuAsync(sku, token);
        }
        
        public async Task<bool> RequestMerchInStockBySku(MerchPack pack, CancellationToken token)
        {
            bool isInStock = false;
            // запрашиваем позиции на складе
            foreach (var item in pack.MerchItems.Items)
            {
                isInStock = await RequestMerchIsInStockBySku(item.Sku.Value, token);
                // если какой-то позиции нет, то выходим
                if (isInStock == false) return false;
            }

            return isInStock;
        }
        
        public async Task ReserveMerchAsync(MerchItem item, CancellationToken token)
        {
            await _stockRepository.ReserveAsync(item, token);
        }

        public async Task ReserveMerchAsync(MerchPack pack, CancellationToken token)
        {
            foreach (var item in pack.MerchItems.Items)
            {
                await ReserveMerchAsync(item, token);
            }
        }

    }
}