using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.merchandise_service.Models.Mocks;


namespace OzonEdu.merchandise_service.Services.Interfaces
{
    /// <summary> Сервис учета выдачи мерча сотрудникам </summary>
    public interface IMerchandiseService
    {
        /// <summary> Возвращает мерч по Id </summary>
        /// <param name="itemId"> Id мерча, который необходимо вернуть </param>
        /// <param name="token"> Токен отмены </param>
        /// <returns> Task&lt;IMerchItem&gt; </returns>
        Task<MerchItemMock> GetMerchById(long itemId, CancellationToken token);
        
        /// <summary> Возвращает информацию о выдаче мерча с указанным Id </summary>
        /// <param name="itemId"> Id мерча </param>
        /// <param name="token"> токен отмены </param>
        /// <returns> true если мерч выдан </returns>
        Task<bool?> GetMerchIsIssuedById(long itemId, CancellationToken token);
    }
}