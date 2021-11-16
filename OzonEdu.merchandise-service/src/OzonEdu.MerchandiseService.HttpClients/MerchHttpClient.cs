using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClient
{
    /// <summary> HttpClient </summary>
    public class MerchHttpClient : IMerchHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public MerchHttpClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GiveMerchToEmployee(GiveMerchItemRequest request, CancellationToken token)
        {
            var content = JsonSerializer.Serialize(request);
            var stringcontent = new StringContent(content, Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync("v1/api/merch/GiveMerchToEmployee", stringcontent, token);


        }
        
        public async Task<bool> GetMerchIsIssued(GetMerchItemIsGivenRequest request, CancellationToken token)
        {
            var content = JsonSerializer.Serialize(request);
            var stringcontent = new StringContent(content, Encoding.UTF8, "application/json");
            
            using var response = await _httpClient.PostAsync("v1/api/merch/GetMerchIsIssued", stringcontent, token);
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