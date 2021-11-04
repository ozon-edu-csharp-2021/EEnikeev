using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public IUnitOfWork UnitOfWork { get; }
        
        Task<int> CreateAsync(Employee employee, CancellationToken cancellationToken = default);
        Task<Employee> UpdateAsync(Employee employee, CancellationToken cancellationToken = default);
        Task<Employee> FindByIdAsync(int id, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken token = default);
        Task<IEnumerable<Employee>> GetWaitingMerchEmployeesAsync(CancellationToken token = default);

    }
}