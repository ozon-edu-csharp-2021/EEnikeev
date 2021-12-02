using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Broker.Contracts;
using OzonEdu.MerchandiseService.Infrastructure.Broker.Producers;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchIsIssued;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem;
using OzonEdu.MerchandiseService.Infrastructure.DomainServices.Interfaces;
using OzonEdu.MerchandiseService.Infrastructure.Repo;
using OzonEdu.MerchandiseService.Infrastructure.Repositories;

namespace OzonEdu.MerchandiseService.Infrastructure.DomainServices
{
    public class MerchManagerDomainService : IMerchManagerDomainService
    {
        private IStockRepository _stockRepository;
        private IRepository _repository;
        private IMerchProducer _merchProducer;

        public MerchManagerDomainService(IRepository repository, IMerchProducer merchProducer)
        {
            _repository = repository;
            _merchProducer = merchProducer;
        }

        public async Task GiveMerchAsync(GiveMerchItemCommand request, CancellationToken token)
        {
            _merchProducer.SendEmail(new EmployeeEventContract("SomeEmail@mail", "Вася Пупкин", 400, new PayloadContract(40)));
            await _repository.GiveMerchAsync(request, token);
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