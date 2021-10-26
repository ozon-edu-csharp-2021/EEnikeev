using System.Threading;
using System.Threading.Tasks;
using OzonEdu.merchandise_service.HttpModels;

namespace OzonEdu.merchandise_service.HttpClient
{
    public interface IMerchHttpClient
    {
        /// <summary> Возвращает мерч по идентификатору </summary>
        /// <param name="id"> Идентификатор мерча </param>
        /// <param name="token"> Токен отмены </param>
        /// <returns> Task&lt;MerchItemResponse&gt; </returns>
        Task<MerchItemResponse> GetMerchById(long id, CancellationToken token);

        /// <summary> Возвращает информацию о выдаче мерча с указанным Id </summary>
        /// <param name="id"> Id мерча </param>
        /// <param name="token"> токен отмены </param>
        /// <returns> true если мерч выдан </returns>
        Task<bool> GetMerchIsIssuedById(long id, CancellationToken token);

        /// <summary> Возвращает статус код по указаннному маршруту </summary>
        /// <param name="path"> путь </param>
        /// <param name="token"> токен отмены </param>
        /// <returns> результат запроса </returns>
        Task<string> GetStatusCode(string path, CancellationToken token);
        
        /// <summary> Возвращает информацию о версии </summary>
        /// <param name="token"> токен отмены </param>
        /// <returns> версия </returns>
        Task<string> GetVersion(CancellationToken token);
        
        /// <summary> Возвращает информацию о жизни </summary>
        /// <param name="token"> токен отмены </param>
        /// <returns> статус </returns>
        Task<string> GetLive(CancellationToken token);
        
        /// <summary> Возвращает информацию о готовности </summary>
        /// <param name="token"> токен отмены </param>
        /// <returns> статус </returns>
        Task<string> GetReady(CancellationToken token);

    }
}