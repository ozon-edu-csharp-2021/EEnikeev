using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Models.Interfaces;

namespace OzonEdu.MerchandiseService.Services.Interfaces
{
    /// <summary> Сервис учета выдачи мерча сотрудникам </summary>
    public interface IMerchandiseService
    {
        Task<IMerchItem?> GetMerchById(long itemId, CancellationToken token);
        
        Task<bool?> GetMerchIsIssuedById(long itemId, CancellationToken token);
    }
}