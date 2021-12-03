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
                await GiveMerchesToAll(client);
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

        static async Task GiveMerches(MerchServiceGrpc.MerchServiceGrpcClient client)
        {
            for (int i = 4; i < 7; i++)
                {
                    var result = await client.GetMerchIsIssuedAsync(
                        new GetMerchItemIsGivenRequest() { EmployeeId = i, MerchId = 10 }, 
                        cancellationToken: CancellationToken.None);
                    
                    Console.WriteLine($"Проверка, выдан ли мерч сотруднику id={i}...");
                    
                    if (result.IsIssued)
                    {
                        Console.WriteLine("Мерч выдан, выдача не требуется.");
                        Console.WriteLine();
                        continue;
                    }
                    
                    Console.WriteLine("Мерч не выдан, мерч выдается...");
                    
                    await client.GiveMerchToEmployeeAsync(
                        new GiveMerchItemRequest() { EmployeeId = i, MerchId = 10, ClothingSizeId = 2 }, 
                        cancellationToken: CancellationToken.None);
                    
                    result = await client.GetMerchIsIssuedAsync(
                        new GetMerchItemIsGivenRequest() { EmployeeId = i, MerchId = 10 }, 
                        cancellationToken: CancellationToken.None);
                    
                    if (result.IsIssued)
                    {
                        Console.WriteLine("Мерч успешно выдан!");
                    }
                    else
                    {
                        Console.WriteLine("Не удалось выдать мерч");
                    }
                    Console.WriteLine();
                }
        }

        static async Task GetMerchIsIssued(MerchServiceGrpc.MerchServiceGrpcClient client, int employeeId = 1, int merchId = 10)
        {
            var result = await client.GetMerchIsIssuedAsync(
                    new GetMerchItemIsGivenRequest() { EmployeeId = employeeId, MerchId = merchId }, 
                    cancellationToken: CancellationToken.None);
        }

        static async Task GetMerchIsIssuedAll(MerchServiceGrpc.MerchServiceGrpcClient client, int merchId = 10)
        {
            Console.WriteLine();
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine($"Проверка выдачи мерча id={merchId} сотруднику id={i}" );
                var result = await client.GetMerchIsIssuedAsync(
                    new GetMerchItemIsGivenRequest() { EmployeeId = i, MerchId = merchId }, 
                    cancellationToken: CancellationToken.None);
                Console.WriteLine($"Проверка завершена: мерч id={merchId} сотруднику id={i} {(result.IsIssued?"":"НЕ ")}выдавался");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        
        static async Task GiveMerchesToAll(MerchServiceGrpc.MerchServiceGrpcClient client, int merchId = 10)
        {
            Console.WriteLine();
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine($"Проверка выдачи мерча id={merchId} сотруднику id={i}" );
                var result = await client.GetMerchIsIssuedAsync(
                    
                    new GetMerchItemIsGivenRequest() { EmployeeId = i, MerchId = merchId }, 
                    cancellationToken: CancellationToken.None);
                
                Console.WriteLine($"Проверка завершена: мерч id={merchId} сотруднику id={i} {(result.IsIssued?"":"НЕ ")}выдавался");
                
                Console.WriteLine("Все равно пытаемся вручить мерч...");
                    
                await client.GiveMerchToEmployeeAsync(
                    new GiveMerchItemRequest() { EmployeeId = i, MerchId = merchId, ClothingSizeId = 3 }, 
                    cancellationToken: CancellationToken.None);
                    
                result = await client.GetMerchIsIssuedAsync(
                    new GetMerchItemIsGivenRequest() { EmployeeId = i, MerchId = merchId }, 
                    cancellationToken: CancellationToken.None);
                    
                if (result.IsIssued)
                {
                    Console.WriteLine("Мерч успешно выдан!");
                }
                else
                {
                    Console.WriteLine("Не удалось выдать мерч");
                }
                
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}