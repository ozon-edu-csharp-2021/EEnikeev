using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    public sealed class MerchPack : Entity
    {
        #region Properties
        
        public Name Name { get; }
        
        public MerchItemList MerchItems { get; }

        #endregion

        public MerchPack(int id, Name name, MerchItemList merchItems)
        {
            Id = id;
            Name = name;
            MerchItems = merchItems;
        }
    }
}