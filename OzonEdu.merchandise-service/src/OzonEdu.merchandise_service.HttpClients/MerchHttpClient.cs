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
        
    }
} 