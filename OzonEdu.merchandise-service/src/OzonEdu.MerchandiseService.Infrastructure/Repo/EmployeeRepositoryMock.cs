using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;
using OzonEdu.MerchandiseService.Infrastructure.Factory;

namespace OzonEdu.MerchandiseService.Infrastructure.Repo
{
    public class EmployeeRepositoryMock : IEmployeeRepository
    {
        private List<Employee> _employees = new List<Employee>();
        
        public IUnitOfWork UnitOfWork { get; }

        public EmployeeRepositoryMock()
        {
            for (int i = 0; i < 10; i++)
            {
                _employees.Add(EmployeeFactory.CreateEmployee());
            }
        }
        
        public Task<int> CreateAsync(Employee employee, CancellationToken cancellationToken = default)
        {
            _employees.Add(employee);
            return Task.FromResult(employee.Id);
        }

        public Task<Employee> UpdateAsync(Employee employee, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(employee);
        }

        public Task<Employee> FindByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_employees.FirstOrDefault(e => e.Id == id));
        }
    }
}