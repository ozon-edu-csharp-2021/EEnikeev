using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.merchandise_service.Models.Mocks;
using OzonEdu.merchandise_service.Services.Interfaces;

namespace OzonEdu.merchandise_service.Services
{
    /// <summary> Сервис учета выдачи мерча сотрудникам </summary>
    public class MerchandiseService : IMerchandiseService
    {
        private MerchRepositoryMock _merchRepository = new MerchRepositoryMock();
        
        /// <summary> Возвращает мерч по Id </summary>
        /// <param name="itemId"> Id мерча, котоырй необходимо вернуть </param>
        /// <param name="token"> Токен отмены </param>
        /// <returns> Мерч </returns>
        public Task<MerchItemMock?> GetMerchById(long itemId, CancellationToken token)
        {
            var merchItem = _merchRepository.GetMerchById(itemId);
            return Task.FromResult(merchItem);
        }

        /// <summary> Возвращает информацию о выдаче мерча с указанным Id </summary>
        /// <param name="itemId"> Id мерча </param>
        /// <param name="token"> токен отмены </param>
        /// <returns> true если мерч выдан </returns>
        public Task<bool?> GetMerchIsIssuedById(long itemId, CancellationToken token)
        {
            var merchItem = _merchRepository.GetMerchIsIssuedInfo(itemId);
            return Task.FromResult(merchItem);
        }
    }
}