using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.Core.Lib.Enums;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem;
using OzonEdu.MerchandiseService.Infrastructure.DomainServices;
using OzonEdu.MerchandiseService.Infrastructure.Factory;
using OzonEdu.MerchandiseService.Infrastructure.Repo;

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
            var employee =
                await EmployeeMerchDomainService.GetEmployeeByIdAsync(request.EmployeeId, _employeeRepository,
                    cancellationToken);
            
            // если такой мерч уже был выдан сотруднику
            if (employee.IsGiven(request.MerchId))
                throw new ArgumentException(
                    $"Merch with id={request.MerchId} is already given to employee with id={request.EmployeeId}");

            
            // выбираем мерч
            MerchType type;
            if (Enum.IsDefined(typeof(MerchType), request.MerchId))
            {
                type = (MerchType)request.MerchId;
            }
            else
            {
                throw new ArgumentException($"Unknown merch type requested with id={request.MerchId}");
            }
            
            MerchPack pack = MerchPackFactory.GetPack(type, ClothingSize.GetById(request.SizeId));
            
            bool isInStock = await EmployeeMerchDomainService.RequestMerchInStockBySku(pack, _stockRepository, cancellationToken);
            
            // если не было нужной позиции, помещаем в ожидание, иначе выдаем
            employee.GiveMerch(pack, isInStock);
            
            //если все в наличии, резервируем
            foreach (var item in pack.MerchItems.Items)
            {
                await _stockRepository.ReserveAsync(item, cancellationToken);
            }
            
            
            await _employeeRepository.UpdateAsync(employee, cancellationToken);
            
            // пока делаем временную заглушку
            if (_employeeRepository.UnitOfWork != null)
                await _employeeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}