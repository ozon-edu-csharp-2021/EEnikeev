using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.V2;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.Repo
{
    public class EmployeeRepositoryMock : IEmployeeRepository
    {
        public IUnitOfWork UnitOfWork { get; }
        public Task<Employee> CreateAsync(Employee employee, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> UpdateAsync(Employee employee, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> FindByIdAsync(EmployeeId id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}