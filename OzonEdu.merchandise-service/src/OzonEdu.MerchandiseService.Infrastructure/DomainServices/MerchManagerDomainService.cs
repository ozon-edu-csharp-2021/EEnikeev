using System.Threading;
using System.Threading.Tasks;
using OpenTracing;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Broker.Contracts;
using OzonEdu.MerchandiseService.Infrastructure.Broker.Producers;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchIsIssued;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem;
using OzonEdu.MerchandiseService.Infrastructure.DomainServices.Interfaces;
using OzonEdu.MerchandiseService.Infrastructure.Repo;
using OzonEdu.MerchandiseService.Infrastructure.Repositories;
using OzonEdu.StockApi.Grpc;

namespace OzonEdu.MerchandiseService.Infrastructure.DomainServices
{
    public class MerchManagerDomainService : IMerchManagerDomainService
    {
        private IRepository _repository;
        private IMerchProducer _merchProducer;
        private readonly StockApiGrpc.StockApiGrpcClient _stockApiClient;

        public MerchManagerDomainService(IRepository repository, IMerchProducer merchProducer, StockApiGrpc.StockApiGrpcClient stockApiClient)
        {
            _repository = repository;
            _merchProducer = merchProducer;
            _stockApiClient = stockApiClient;
        }

        public async Task GiveMerchAsync(GiveMerchItemCommand request, CancellationToken token)
        {
            // тестовый запрос в сток апи
            var stockRequest = new GiveOutItemsRequest()
            {
                 // откуда я знаю sku?
            };
            var response = await _stockApiClient.GiveOutItemsAsync(stockRequest);

            if (response.Result == GiveOutItemsResponse.Types.Result.Successful)
            {
                await _repository.GiveMerchAsync(request, token);
                
                // тестовая отправка в кафку
                _merchProducer.SendEmail(new EmployeeEventContract("SomeEmail@mail", "Вася Пупкин", 400,
                    new PayloadContract(40)));
            }
            else
            {
                // поставить на ожидание
            }
        }

        public async Task<bool> GetMerchIsIssuedAsync(GetMerchIsIssuedCommand request, CancellationToken token)
        {
            var result = await _repository.GetMerchIsGivenAsync(request, token);
            return result;
        }

        public Task ReorderMerchAsync(CancellationToken token)
        {
            throw new System.NotImplementedException();
        }
    }
}