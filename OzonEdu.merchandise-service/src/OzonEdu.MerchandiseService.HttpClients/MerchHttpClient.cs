using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

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

        public async Task<MerchItemResponse> GetMerchById(long id, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"v1/api/merch/GetMerch/{id}", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchItemResponse>(body, 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
            
        }
        
        public async Task<bool> GetMerchIsIssuedById(long id, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"v1/api/merch/GetMerchIsIssued/{id}", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return Boolean.Parse(body);
        }
        
        public async Task<string> GetStatusCode(string path, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync(path, token);
            return response.StatusCode.ToString();
        }
        

       public async Task<string> GetVersion(CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("/version", token);
            return await response.Content.ReadAsStringAsync(token);
        }
        
        public async Task<string> GetLive(CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("/live", token);
            return response.StatusCode.ToString();
        }
        
       public async Task<string> GetReady(CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("/ready", token);
            return response.StatusCode.ToString();
        }
        
    }
} 