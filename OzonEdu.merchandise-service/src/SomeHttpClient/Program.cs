using System;
using System.Net.Http;
using System.Threading;
using OzonEdu.merchandise_service.HttpClient;

namespace SomeHttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IMerchHttpClient client = new MerchHttpClient(new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5000")
            });

            Console.WriteLine("Merch info: ");
            for (int i = 0; i < 4; i++)
            {
                var item = client.GetMerchById(i, CancellationToken.None).Result;
                var isIssued = client.GetMerchIsIssuedById(i, CancellationToken.None).Result;
                string s = isIssued == false ? "не " : "";
                Console.WriteLine($"{item.Id}: {item.Name} - {s}выдан");
            }

        }
    }
}