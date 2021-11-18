using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchIsIssued;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories
{
    public interface IRepository
    {
        public Task<bool> GetMerchIsGivenAsync(GetMerchIsIssuedCommand request, CancellationToken token);

        public Task<bool> GiveMerchAsync(GiveMerchItemCommand request, CancellationToken token);
    }
}