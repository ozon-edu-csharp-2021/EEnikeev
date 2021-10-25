using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using OzonEdu.merchandise_service.Grpc;

namespace OzonEdu.merchandise_service.GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new MerchServiceGrpc.MerchServiceGrpcClient(channel);
            
            // запрашиваем все товары и информацию о выдаче
            for (int i = 0; i < 6; i++)
            {
                var item = await client.GetMerchByIdAsync(new GetMerchItemByIdRequest { ItemId = i },
                    cancellationToken: CancellationToken.None);
                if (item.ItemName==null) continue;
                
                var result = await client.GetMerchIsIssuedByIdAsync(new GetMerchItemByIdRequest { ItemId = i },
                    cancellationToken: CancellationToken.None);
                if (result.IsIssued==null) continue;
                
                Console.WriteLine($"Мерч {item.ItemId}: {item.ItemName}");
                Console.WriteLine($"Выдан: {result.IsIssued}");
                Console.WriteLine();
            }
            
        }
    }
}