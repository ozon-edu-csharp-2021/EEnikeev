using System;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpClient;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClientImitator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IMerchHttpClient client = new MerchHttpClient(new System.Net.Http.HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5000")
            });

            try
            {
                Console.WriteLine("Live: " + client.GetLive(CancellationToken.None).Result);
                //Console.WriteLine("LiveStatusCode: " + client.GetStatusCode("/live",CancellationToken.None).Result);
                Console.WriteLine("Version: " + client.GetVersion(CancellationToken.None).Result);
                Console.WriteLine("Ready: " + client.GetReady(CancellationToken.None).Result);
                //Console.WriteLine("ReadyStatusCode: " + client.GetStatusCode("/ready",CancellationToken.None).Result);
                Console.WriteLine();
                Console.WriteLine("Merch info: ");

                for (int i = 1; i < 5; i++)
                {
                    var result = await client.GetMerchIsIssued(new GetMerchItemIsGivenRequest() { EmployeeId = i, MerchId = 10 }, CancellationToken.None);
                    Console.WriteLine($"Проверка, выдан ли мерч сотруднику id={i}...");
                    if (result)
                    {
                        Console.WriteLine("Мерч выдан, выдача не требуется.");
                        continue;
                    }
                    Console.WriteLine("Мерч не выдан, мерч выдается...");
                    await client.GiveMerchToEmployee(new GiveMerchItemRequest() { employeeId = i, merchId = 10, sizeId = 2 },CancellationToken.None);
                    result = await client.GetMerchIsIssued(new GetMerchItemIsGivenRequest() { EmployeeId = i, MerchId = 10 }, CancellationToken.None);
                    if (result)
                    {
                        Console.WriteLine("Мерч успешно выдан!");
                    }
                    else
                    {
                        Console.WriteLine("Не удалось выдать мерч");
                    }
                    Console.WriteLine();
                }

                /*for (int i = 0; i < 5; i++)
                {
                    var item = client.GetMerchById(i, CancellationToken.None).Result;
                    var isIssued = client.GetMerchIsIssuedById(i, CancellationToken.None).Result;
                    string s = isIssued == false ? "не " : "";
                    Console.WriteLine($"{item.Id}: {item.Name} - {s}выдан");
                }*/

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}