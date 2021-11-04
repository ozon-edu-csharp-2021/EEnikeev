using System;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Infrastructure.DomainServices.Interfaces;

namespace OzonEdu.MerchandiseService.Infrastructure.DomainServices
{
    public class EmployeeDomainService : IEmployeeDomainService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeDomainService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id, CancellationToken token)
        {
            var employee = await _employeeRepository.FindByIdAsync(id, token);
            if (employee == null)
            {
                throw new ArgumentException($"Employee with id={id} did not found");
            }

            return employee;
        }
    }
}