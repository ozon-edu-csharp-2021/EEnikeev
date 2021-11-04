using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.DomainServices.Interfaces
{
    public interface IEmployeeDomainService
    {
        Task<Employee> GetEmployeeByIdAsync(int id, CancellationToken token);
    }
}