using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Infrastructure.Repository
{
    public class RepositoryMock : IMerchItemRepository
    {
        private List<Employee> _employees = new List<Employee>()
        {
            new Employee(new EmployeeId(1),
                new EmployeeName("Иван"),
                new EmployeeName("Иванов"),
                new PositionEntity(Position.Manager),
                new MerchIssued(true)),

            new Employee(new EmployeeId(2),
                new EmployeeName("Петр"),
                new EmployeeName("Петров"),
                new PositionEntity(Position.Manager),
                new MerchIssued(true)),

            new Employee(new EmployeeId(3),
                new EmployeeName("Сидр"),
                new EmployeeName("Сидоров"),
                new PositionEntity(Position.Manager),
                new MerchIssued(false)),
            
            new Employee(new EmployeeId(4),
                new EmployeeName("Фёдор"),
                new EmployeeName("Фёдоров"),
                new PositionEntity(Position.Manager),
                new MerchIssued(false))

        };
        
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