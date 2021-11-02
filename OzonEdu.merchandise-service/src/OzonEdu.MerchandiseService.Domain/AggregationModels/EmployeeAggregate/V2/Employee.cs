using System.Collections.Generic;
using System.Linq;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate.V2;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.Models;


namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.V2
{
    public class Employee : Entity
    {
        public EmployeeId EmployeeId { get; }

        List<MerchItem> GivenMerchItems { get; }
        
        List<MerchItem> AwaitingMerchItems { get; }
        
        public Employee(EmployeeId employeeId)
        {
            EmployeeId = employeeId;
            GivenMerchItems = new List<MerchItem>();
            AwaitingMerchItems = new List<MerchItem>();
        }
        
        #region methods

        /// <summary> Мерч уже выдан </summary>
        public bool AlreadyIssued(MerchItem item)
        {
            return GivenMerchItems.FirstOrDefault(m => m.sku.Value == item.sku.Value) is not null;
        }
        
        /// <summary> Мерч уже запрошен </summary>
        public bool IsResponsed(MerchItem item)
        {
            return AwaitingMerchItems.FirstOrDefault(m => m.sku.Value == item.sku.Value) is not null;
        }
        
        /// <summary> Выдать мерч </summary>
        public void Give(MerchItem item)
        {
            // если такой мерч уже выдавался, то инкрементим количество выданного мерча
            var giveItem = GivenMerchItems.FirstOrDefault(m => m.sku.Value == item.sku.Value);
            if (giveItem is not null)
            {
                giveItem.IncreaseQuantity(item.Quantity.Value);
            }
            else
            {
                // в противном случае добавляем его в полученные
                GivenMerchItems.Add(item);
            }
            

            // убираем такой мерч из листа ожидания, если он там есть
            var awaitItem = AwaitingMerchItems.FirstOrDefault(m => m.sku.Value == item.sku.Value);
            if (awaitItem is not null)
            {
                awaitItem.DecreaseQuantity(item.Quantity.Value);
                if (awaitItem.Quantity.Value == 0) AwaitingMerchItems.Remove(awaitItem);
            }
        }

        /// <summary> Добавить мерч в лист ожидания </summary>
        public void AddInQueue(int merchId)
        {
            
        }
        
        

        #endregion

    }
}