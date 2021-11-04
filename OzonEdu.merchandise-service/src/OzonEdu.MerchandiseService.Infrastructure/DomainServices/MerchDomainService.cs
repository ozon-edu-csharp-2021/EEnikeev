using System;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Repo;

namespace OzonEdu.MerchandiseService.Infrastructure.DomainServices
{
    public class EmployeeMerchDomainService 
    {
        public static async Task<Employee> GetEmployeeByIdAsync(int id, IEmployeeRepository repository, CancellationToken token)
        {
            var employee = await repository.FindByIdAsync(id, token);
            if (employee == null)
            {
                throw new ArgumentException($"Employee with id={id} did not found");
            }

            return employee;
        }

        public static async Task<bool> RequestMerchInStockBySku(long sku, IStockRepository stockRepository, CancellationToken token)
        {
            return await stockRepository.CheckInStockBySkuAsync(sku, token);
        }
        
        public static async Task<bool> RequestMerchInStockBySku(MerchPack pack, IStockRepository stockRepository, CancellationToken token)
        {
            bool isInStock = false;
            // запрашиваем позиции на складе
            foreach (var item in pack.MerchItems.Items)
            {
                isInStock = await RequestMerchInStockBySku(item.Sku.Value, stockRepository, token);
                // если какой-то позиции нет, то выходим
                if (isInStock == false) return false;
            }

            return isInStock;
        }

    }
}