using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClient
{
    public interface IMerchHttpClient
    {
        Task<MerchItemResponse> GetMerchById(long id, CancellationToken token);

        Task<bool> GetMerchIsIssuedById(long id, CancellationToken token);

        Task<string> GetStatusCode(string path, CancellationToken token);
        
        Task<string> GetVersion(CancellationToken token);
        
        Task<string> GetLive(CancellationToken token);
        
        Task<string> GetReady(CancellationToken token);

    }
}