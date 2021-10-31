using System.Threading;
using System.Threading.Tasks;
using OzonEdu.merchandise_service.Infrastructure.Models.Interfaces;


namespace OzonEdu.merchandise_service.Services.Interfaces
{
    /// <summary> Сервис учета выдачи мерча сотрудникам </summary>
    public interface IMerchandiseService
    {
        Task<IMerchItem?> GetMerchById(long itemId, CancellationToken token);
        
        Task<bool?> GetMerchIsIssuedById(long itemId, CancellationToken token);
    }
}