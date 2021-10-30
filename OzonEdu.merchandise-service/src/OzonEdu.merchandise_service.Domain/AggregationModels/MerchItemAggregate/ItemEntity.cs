using OzonEdu.merchandise_service.DomainBase.Models;

namespace OzonEdu.merchandise_service.Domain.AggregationModels.MerchItemAggregate
{
    /// <summary> Тип товара </summary>
    public class ItemEntity : Entity
    {
        public ItemType ItemType { get; }

        public ItemEntity(ItemType itemType)
        {
            ItemType = itemType;
        }
    }
}