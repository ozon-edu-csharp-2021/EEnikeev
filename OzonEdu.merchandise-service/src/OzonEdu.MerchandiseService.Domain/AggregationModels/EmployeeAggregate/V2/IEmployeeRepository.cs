using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.V2
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public IUnitOfWork UnitOfWork { get; }
        
        Task<Employee> CreateAsync(Employee employee, CancellationToken cancellationToken = default);
        Task<Employee> UpdateAsync(Employee employee, CancellationToken cancellationToken = default);
        Task<Employee> FindByIdAsync(EmployeeId id, CancellationToken cancellationToken = default);
        
    }
}