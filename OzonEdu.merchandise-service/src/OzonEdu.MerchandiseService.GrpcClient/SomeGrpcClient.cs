using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using OzonEdu.MerchandiseService.Grpc;

namespace OzonEdu.MerchandiseService.GrpcClient
{
    class SomeGrpcClient
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new MerchServiceGrpc.MerchServiceGrpcClient(channel);

            try
            {

                for (int i = 1; i < 4; i++)
                {
                    
                }
                
                // запрашиваем все товары и информацию о выдаче
                for (int i = 0; i < 5; i++)
                {
                    var item = await client.GetMerchByIdAsync(new GetMerchItemByIdRequest { ItemId = i },
                        cancellationToken: CancellationToken.None);
                    if (item.ItemName == null) continue;

                    var result = await client.GetMerchIsIssuedByIdAsync(new GetMerchItemByIdRequest { ItemId = i },
                        cancellationToken: CancellationToken.None);
                    if (result.IsIssued == null) continue;

                    Console.WriteLine($"Мерч {item.ItemId}: {item.ItemName}");
                    Console.WriteLine($"Выдан: {result.IsIssued}");
                    Console.WriteLine();
                }

            }
            catch (RpcException e)
            {
                Console.WriteLine("ОШИБКА " + e.StatusCode);
                Console.WriteLine(e.Message);
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}