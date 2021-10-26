using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.merchandise_service.HttpModels;

namespace OzonEdu.merchandise_service.HttpClient
{
    /// <summary> HttpClient </summary>
    public class MerchHttpClient : IMerchHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public MerchHttpClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary> Возвращает мерч по идентификатору </summary>
        /// <param name="id"> Идентификатор мерча </param>
        /// <param name="token"> Токен отмены </param>
        /// <returns> Task&lt;MerchItemResponse&gt; </returns>
        public async Task<MerchItemResponse> GetMerchById(long id, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"v1/api/merch/GetMerch/{id}", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchItemResponse>(body, 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
            
        }
        
        /// <summary> Возвращает информацию о выдаче мерча с указанным Id </summary>
        /// <param name="id"> Id мерча </param>
        /// <param name="token"> токен отмены </param>
        /// <returns> true если мерч выдан </returns>
        public async Task<bool> GetMerchIsIssuedById(long id, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"v1/api/merch/GetMerchIsIssued/{id}", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return Boolean.Parse(body);
        }
        
        /// <summary> Делает пустой запрос по указанному маршруту </summary>
        /// <param name="path"> путь </param>
        /// <param name="token"> токен отмены </param>
        /// <returns> код ответа </returns>
        public async Task<string> GetStatusCode(string path, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync(path, token);
            return response.StatusCode.ToString();
        }
        

        /// <summary> Возвращает информацию о версии </summary>
        /// <param name="token"> токен отмены </param>
        /// <returns> версия </returns>
        public async Task<string> GetVersion(CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("/version", token);
            return await response.Content.ReadAsStringAsync(token);
        }
        
        /// <summary> Возвращает информацию о жизни </summary>
        /// <param name="token"> токен отмены </param>
        /// <returns> статус </returns>
        public async Task<string> GetLive(CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("/live", token);
            return response.StatusCode.ToString();
        }
        
        /// <summary> Возвращает информацию о готовности </summary>
        /// <param name="token"> токен отмены </param>
        /// <returns> статус </returns>
        public async Task<string> GetReady(CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("/ready", token);
            return response.StatusCode.ToString();
        }
        
    }
} 