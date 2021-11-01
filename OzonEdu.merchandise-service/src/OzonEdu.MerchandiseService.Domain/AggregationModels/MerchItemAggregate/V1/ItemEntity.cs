using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate.V1
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