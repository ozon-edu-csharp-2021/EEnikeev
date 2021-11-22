using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchIsIssued;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem;

namespace OzonEdu.MerchandiseService.Infrastructure.DomainServices.Interfaces
{
    public interface IMerchManagerDomainService
    {
        Task GiveMerchAsync(GiveMerchItemCommand request, CancellationToken token);

        Task<bool> GetMerchIsIssuedAsync(GetMerchIsIssuedCommand request, CancellationToken token);

        Task ReorderMerchAsync(CancellationToken token);
    }
}