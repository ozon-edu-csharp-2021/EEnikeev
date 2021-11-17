using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.Core.Lib.Enums;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchIsIssued;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem;
using OzonEdu.MerchandiseService.Infrastructure.DomainServices.Interfaces;
using OzonEdu.MerchandiseService.Infrastructure.Factory;
using OzonEdu.MerchandiseService.Infrastructure.Repo;

namespace OzonEdu.MerchandiseService.Infrastructure.DomainServices
{
    public class MerchManagerDomainService : IMerchManagerDomainService
    {
        private IEmployeeRepository _employeeRepository;
        private IStockRepository _stockRepository;

        public MerchManagerDomainService(IEmployeeRepository employeeRepository, IStockRepository stockRepository)
        {
            _employeeRepository = employeeRepository;
            _stockRepository = stockRepository;
        }

        async Task<Employee> GetEmployeeByIdAsync(int id, CancellationToken token)
        {
            var employee = await _employeeRepository.FindByIdAsync(id, token);
            if (employee == null)
            {
                throw new ArgumentException($"Employee with id={id} did not found");
            }

            return employee;
        }

        public async Task<bool> GetMerchIsIssuedAsync(GetMerchIsIssuedCommand request, CancellationToken token)
        {
            var result = await _employeeRepository.GetAllAsync(token);
            return false;

            //var employee = await GetEmployeeByIdAsync(request.EmployeeId, token);
            //return employee.IsGiven(request.MerchId);
        }
        
        public async Task<Employee> GiveMerchAsync(GiveMerchItemCommand request, CancellationToken token)
        {
            var employee =
                await GetEmployeeByIdAsync(request.EmployeeId, token);
            
            // если такой мерч уже был выдан сотруднику
            if (employee.IsGiven(request.MerchId))
                throw new ArgumentException(
                    $"Merch with id={request.MerchId} is already given to employee with id={request.EmployeeId}");

            // выбираем мерч
            MerchType type;
            if (Enum.IsDefined(typeof(MerchType), request.MerchId)) 
                type = (MerchType)request.MerchId;
            else 
                throw new ArgumentException($"Unknown merch type requested with id={request.MerchId}");
            
            // получаем мерч из фабрики
            MerchPack pack =  MerchPackFactory.GetPack(type, ClothingSize.GetById(request.SizeId));
            
            bool isInStock = await _stockRepository.CheckInStockBySkuAsync(pack.MerchItems.Items.Select(m => m.Sku.Value), token);
            
            //если все в наличии, резервируем
            if (isInStock) await _stockRepository.ReserveAsync(pack.MerchItems.Items, token);
                
            // если не было нужной позиции, помещаем в ожидание, иначе выдаем
            employee.GiveMerch(pack, isInStock);
            
            await _employeeRepository.UpdateAsync(employee, token);
            // пока делаем временную заглушку
            if (_employeeRepository.UnitOfWork != null)
                await _employeeRepository.UnitOfWork.SaveEntitiesAsync(token);

            return employee;

        }

        
        // этот метод можно будет использовать, когда придет событие о пополнении мерча
        public async Task ReorderMerchAsync(CancellationToken token)
        {
            var employeesWaitingForMerch = await _employeeRepository.GetWaitingMerchEmployeesAsync(token);

        }

    }
}