using OzonEdu.merchandise_service.DomainBase.Models;

namespace OzonEdu.merchandise_service.Domain.AggregationModels.MerchItemAggregate
{
    public class MerchItem : Entity
    {
        #region Fields

        public Sku Sku { get; }
        public Name Name { get; }
        public ItemEntity Type { get; }
        public ClothingSize ClothingSize { get; }
        public int Quantity { get; }
        public string Tag { get; }

        #endregion
    }
}