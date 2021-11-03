using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.Factory;
using OzonEdu.MerchandiseService.Domain.Repo;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class GiveOutMerchItemCommandHandler : IRequestHandler<GiveMerchItemCommand>
    {
        private IEmployeeRepository _employeeRepository;
        private IStockRepository _stockRepository;

        public GiveOutMerchItemCommandHandler(IEmployeeRepository employeeRepository, IStockRepository stockRepository)
        {
            _employeeRepository = employeeRepository;
            _stockRepository = stockRepository;
        }
        
        public async Task<Unit> Handle(GiveMerchItemCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.FindByIdAsync(request.EmployeeId, cancellationToken);
            
            if (employee == null)
            {
                throw new ArgumentException($"Employee with id={request.EmployeeId} did not found");
            }
            
            // если такой мерч уже был выдан сотруднику
            if (employee.IsGiven(request.MerchId))
                throw new ArgumentException(
                    $"Merch with id={request.MerchId} is already given to employee with id={request.EmployeeId}");
            
            // выбираем мерч
            EMerchType type;
            try
            {
                type = (EMerchType)request.MerchId;
            }
            catch (InvalidCastException e)
            {
                throw new ArgumentException($"Unknown merch type requested: id={request.MerchId}");
            }

            MerchPack pack = MerchPackFactory.GetPack(type, ClothingSize.GetById(request.SizeId));

            bool isInStock = false;
            // запрашиваем позиции на складе
            foreach (var item in pack.MerchItems.Items)
            {
                isInStock = await _stockRepository.CheckInStockBySkuAsync(item.Sku.Value, cancellationToken);
                // если какой-то позиции нет, то выходим
                if (isInStock == false) break;
            }

            //если все в наличии, резервируем
            foreach (var item in pack.MerchItems.Items)
            {
                await _stockRepository.ReserveAsync(item, cancellationToken);
            }
            
            // если не было нужной позиции, помещаем в ожидание, иначе выдаем
            employee.GiveMerch(pack, isInStock);
            
            
            await _employeeRepository.UpdateAsync(employee, cancellationToken);
            //await _employeeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}