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

            for (int i = 0; i < 4; i++)
            {
                var item = await client.GetMerchByIdAsync(new GetMerchItemByIdRequest { ItemId = i },
                    cancellationToken: CancellationToken.None);

                var result = await client.GetMerchIsIssuedByIdAsync(new GetMerchItemByIdRequest { ItemId = i },
                    cancellationToken: CancellationToken.None);
                
                Console.WriteLine($"Мерч {item.ItemId}: {item.ItemName}");
                Console.WriteLine($"Выдан: {result.IsIssued}");
                Console.WriteLine();
            }
            
        }
    }
}