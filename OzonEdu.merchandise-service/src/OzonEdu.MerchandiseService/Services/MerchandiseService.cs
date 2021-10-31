using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Models.Interfaces;
using OzonEdu.MerchandiseService.Models.Mocks;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.Services
{
    /// <summary> Сервис учета выдачи мерча сотрудникам </summary>
    public class MerchandiseService : IMerchandiseService
    {
        private MerchRepositoryMock _merchRepository = new MerchRepositoryMock();
        
        public Task<IMerchItem?> GetMerchById(long itemId, CancellationToken token)
        {
            var merchItem = _merchRepository.GetMerchById(itemId);
            return Task.FromResult(merchItem);
        }

        public Task<bool?> GetMerchIsIssuedById(long itemId, CancellationToken token)
        {
            var merchItem = _merchRepository.GetMerchIsIssuedInfo(itemId);
            return Task.FromResult(merchItem);
        }
    }
}