using System;
using System.Net.Http;
using System.Threading;
using OzonEdu.merchandise_service.HttpClient;

namespace OzonEdu.merchandise_service.HttpClientImitator
{
    class Program
    {
        static void Main(string[] args)
        {
            IMerchHttpClient client = new MerchHttpClient(new System.Net.Http.HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5000")
            });

            try
            {
                Console.WriteLine("Live: " + client.GetLive(CancellationToken.None).Result);
                Console.WriteLine("Version: " + client.GetVersion(CancellationToken.None).Result);
                Console.WriteLine("Ready: " + client.GetReady(CancellationToken.None).Result);
                Console.WriteLine();
                Console.WriteLine("Merch info: ");
                for (int i = 0; i < 6; i++)
                {
                    var item = client.GetMerchById(i, CancellationToken.None).Result;
                    var isIssued = client.GetMerchIsIssuedById(i, CancellationToken.None).Result;
                    string s = isIssued == false ? "не " : "";
                    Console.WriteLine($"{item.Id}: {item.Name} - {s}выдан");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}