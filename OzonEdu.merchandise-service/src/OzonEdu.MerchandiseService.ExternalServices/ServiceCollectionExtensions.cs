using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OzonEdu.MerchandiseService.ExternalServices.StockApi;
using OzonEdu.StockApi.Grpc;

namespace OzonEdu.MerchandiseService.ExternalServices
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStockGrpcServiceClient(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionAddress = configuration.GetSection(nameof(StockApiGrpcServiceConfiguration))
                .Get<StockApiGrpcServiceConfiguration>().ServerAddress;
            if(string.IsNullOrWhiteSpace(connectionAddress))
                connectionAddress = configuration
                    .Get<StockApiGrpcServiceConfiguration>()
                    .ServerAddress;

            services.AddScoped<StockApiGrpc.StockApiGrpcClient>(opt =>
            {
                var channel = GrpcChannel.ForAddress(connectionAddress);
                return new StockApiGrpc.StockApiGrpcClient(channel);
            });


            return services;
        }
    }
}